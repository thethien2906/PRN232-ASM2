// HIV_CARE.GraphQLAPIServices.ThienTTT/Program.cs

using HIV_CARE.GraphQLAPIServices.ThienTTT.GraphQLs;
using HIV_CARE.Services.ThienTTT;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddGraphQLServer()
    .AddQueryType<Queries>()
    .AddMutationType<Mutations>()
    .BindRuntimeType<DateTime, DateTimeType>();

builder.Services.AddScoped<IServiceProviders, ServiceProviders>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseRouting().UseEndpoints(endpoints => { endpoints.MapGraphQL(); });

app.UseAuthorization();

app.MapControllers();


app.Run();
