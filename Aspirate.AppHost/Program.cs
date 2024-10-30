var builder = DistributedApplication.CreateBuilder(args);

var keycloak = builder.AddKeycloak("keycloak", 8090)
                      .WithDataVolume()
                      .WithRealmImport("../realms");


builder.AddProject<Projects.Aspirate_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(keycloak);

builder.Build().Run();