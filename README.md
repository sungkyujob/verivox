
# Introduction
This is an application that provides price comparison service based on annual electricity consumption among available tariffs. This project used following framework and libraries.
 - .NET Framework 4.5.2
 - NLog 4.5.11 <https://nlog-project.org>
 - SimpleInjector 4.4.3 <https://simpleinjector.readthedocs.io/en/latest/>


## End points

### Health Check
This endpoint can be used for checking service health status from load balancer or some o**ther s**ervice monitoring tools.

*Request*
```text
GET /hc
```
*Response*
```text
200 OK
```

### Get available tariffs
This endpoint can be used for checking available tariffs.

*Request*
```text
GET /tariffs
```
*Response*
```text
200 OK
["Basic","Package"]
```

### Get electricity cost for all tariffs
This endpoint is used to compare annual electricity cost for all available tariffs.

*Request*
```text
Request
GET /tariffs/consumption/{consumption}
```
*Response*
```text
200 OK
[{"name":"Package","cost":800.0},{"name":"Basic","cost":830.00}]
```

### Get electricity cost for all tariffs
This endpoint is used to compare annual electricity cost for all available tariffs.

*Request*
```text
Request
GET /tariffs/consumption/perf/{original|suggestion}/{consumption}
```
*Response*
```text
200 OK
{"calc_name":"original","elapsed_milliseconds":484}
```

### Get electricity cost with selected tariff
This endpoint is used to calculate annual electricity cost with selected tariff.

*Request*
```text
GET /tariffs/{tariffs}/consumption/{consumption}
```
*Response*
```text
200 OK
{"name":"Basic","cost":830.00}
```

## Errors
### Forbidden
All errors return **request_id** so that developers can easily figure a datailed error message from the server log with the request_id.

*Request*
```text
GET /tariffs/whatever
```
*Response*
```text
403 Forbidden
{"error_code":"000-403-0000","message":"Forbidden","detail":"Endpoint Not Found","request_id":"d1130a6b"}
```
