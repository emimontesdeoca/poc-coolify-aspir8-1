var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloak("keycloak", 8080)
                      .WithDataVolume()
                      .WithRealmImport("../realms");


builder.AddProject<Projects.Aspirate_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(keycloak);

builder.Build().Run();