### Introduction 
Demo of using MediatR in creating pipelines to run related processes 
in a similar way to .Net Core MVC middleware.

https://github.com/jbogard/MediatR

https://medium.com/pragmatic-programming/net-things-pipeline-design-pattern-bb27e65e741e

### Build and Test
There are two test methods - one for hand-rolled pipline and one for MediatR.

### High level Architecture of Pipeline approach

Features of this approach if used for Release 2 or 3

1. There is just one command handled by a group of steps in a pipeline linked with MediatR.
2. Provides a structure to refactor and break out some or all of the bordereau service into pipeline steps.
3. If same pattern implemented on DelegatedAuthority API and DASH API then this provides mechanism to move handlers in a pluggable manner.

The below basic diagram illustrates how the request is passed down the left side and returns a response back up the right side. The pipline can be short circuited at any point. For example, if process in ModelValidationHandler fails then returns a response immediately instead of continuing down the pipeline.

```
↓ Client Coverholder sends Bordereau Request to APIM API
```
------------------ HTTP request to Miller API -------------------------------

    ↓ APIM sends Http Request to endpoint with bdx data  | ↑ Http Response with Url Location and/or validation results
```    
Miller.API.DelegatedAuthority with Pipeline application layer (instead of Service layer)
CreateLocationHandler
  createGUID 
  ↓ send request(bdx) | ↑ return response (Location url)
```

------------------ HTTP request to internal DASH API -------------------


```
DASH API BordereaXPipeline in application layer - (replaces BordereauXService)
API Controller create 
      ↓ send command to pipeline
```

```
PropertyValidationHandler 
      do processing    |
      ↓ next()         |    ↑ return response
```

```
ModelValidationHandler 
      do processing    |
      ↓ next()         |    ↑ return response
```

```
SectionAllocationHandler
      do processing    |
      ↓ next()         |    ↑ return response
```

```
GPILimitValidationHandler
      do processing    |
      ↓ next()         |    ↑ return response
```

```
WhatEverElseHandler
      do processing    |
      ↓ next()         |    ↑ return response

```