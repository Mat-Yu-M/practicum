var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("postgres")
                      .WithDataVolume()
                      .WithPgAdmin();

var myDb = postgres.AddDatabase("practicumdb");

var web = builder.AddExternalService("web", "http://localhost:3000");

var workers = builder.AddProject<Projects.Workers>("workers").WithReference(myDb);

builder.AddProject<Projects.Api>("api")
       .WithReference(myDb).WithReference(workers);

builder.AddProject<Projects.Migrations>("migrations")
       .WithReference(myDb)
       .WaitFor(myDb);


builder.Build().Run();