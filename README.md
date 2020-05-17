# tools
Deployment and monitoring tools.


## Logging & Monitoring
Elasticsearch and Kibana stack.

```
cd cluster
rio -n tools up --name logging-monitoring
```

Launch elasticsearch and kibana container under tools namespace. With stack name logging-monitoring.

Register domain in DNS before launching register command in rio.
Poiting with CNAME to domain provide by rio.
```
rio -n tools domain register els.xxxxxx.xxx elasticsearch
rio -n tools domain register kibana.xxxxxx.xxx kibana
```

### TODO
- [] map elasticsearch volume for storage (/usr/share/elasticsearch/data)
- [] launch elasticsearch as cluster not single node