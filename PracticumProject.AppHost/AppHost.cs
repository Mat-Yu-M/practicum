var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      .WithPgAdmin();

var myDb = postgres.AddDatabase("practicumdb");

var web = builder.AddExternalService("web", "http://localhost:3000");

builder.AddProject<Projects.Api>("api").WithReference(myDb).WaitFor(myDb);

builder.AddProject<Projects.Migrations>("migrations")
    .WithReference(myDb) 
    .WaitFor(myDb);

builder.Build().Run();