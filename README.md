# tools
Deployment and monitoring tools.


## Logging & Monitoring
Elasticsearch and Kibana stack. 
Added APM for monitoring and uptime.

```
cd cluster
rio -n tools up --name logging-monitoring
```

Launch elasticsearch and kibana container under tools namespace. With stack name logging-monitoring.
Launch with a APM Server.

Register domain in DNS before launching register command in rio.
Poiting with CNAME to domain provide by rio.
```
rio -n tools domain register els.xxxxxx.xxx elasticsearch
rio -n tools domain register kibana.xxxxxx.xxx kibana
rio -n tools domain register apm.xxxxxx.xxx apm-server
```


Url for logger (.NET/...)
```
els.xxxxxx.xxx
```

Url for APM (.NET/...)
```
apm.xxxxxx.xxx
```

## Add montoring source
Edit heartbeat.docker.yml
```
heartbeat.monitors:
- type: http
  schedule: '@every 5s'
  urls:
    - http://elasticsearch:9200
    - http://kibana:5601
    - https://myservice.xxxxx.xxx/health
```
=> Wait volume to file work during rio up.

### TODO
- [ ] map elasticsearch volume for storage (/usr/share/elasticsearch/data)
- [ ] launch elasticsearch as cluster not single node
- [ ] add authentification (basic)
- [X] add apm-server
- [X] add heartbeat monitoring