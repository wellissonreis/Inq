var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Inq_ApiService>("apiservice");

builder.AddProject<Projects.Inq_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
