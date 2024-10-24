var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.Example_ApiService>("apiservice");

builder.AddProject<Projects.Example_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.AddProject<Projects.OpenAI_Api>("open-ai-api");

builder.Build().Run();
