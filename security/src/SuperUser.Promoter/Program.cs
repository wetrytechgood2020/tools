using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperUser.Promoter
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var emails = Environment.GetEnvironmentVariable("SU_EMAILS").Split(",");

            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.GetApplicationDefault()
            });


            UserRecord createUser = await FirebaseAuth.DefaultInstance
                                                        .GetUserByEmailAsync("test@wetrytechforgood.be");

            var result = await FirebaseAuth.DefaultInstance.UpdateUserAsync(new UserRecordArgs()
            {
                Uid = createUser.Uid,
                Password = "test0123"
            });

            foreach (var email in emails)
            {

                UserRecord user = await FirebaseAuth.DefaultInstance
                                                        .GetUserByEmailAsync(email);

                if (user.EmailVerified)
                {
                    var claims = new Dictionary<string, object>()
                    {
                        { "role", "SU" },
                    };

                    await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(user.Uid, claims);
                }
            }

        }
    }
}
