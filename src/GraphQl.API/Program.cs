using GraphQl.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterGraphQlDemoIServicesRegisterModules(builder.Configuration);
builder.Services.AddGraphQl();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL("/graphql");

app.Run();
