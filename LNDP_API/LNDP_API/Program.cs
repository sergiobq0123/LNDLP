using System.Text;
using LNDP_API.Data;
using LNDP_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using LNDP_API.Mapping;
using System.Text.Json.Serialization;
using TTTAPI.JWT.Managers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<APIContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("APIContext") ?? throw new InvalidOperationException("Connect string 'APIContext' not found.")));

//Add auth
var configuration = builder.Configuration;
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["key"])),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
builder.Services.AddCors(options => {
    options.AddPolicy(name: MyAllowSpecificOrigins, policy => {
        policy.WithOrigins("*").WithMethods( "POST", "PUT", "DELETE").WithHeaders("content-type", "Authorization");
    });
});
//Add token service
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<IUrlEmbedService, UrlEmbedService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);
using (var scope = app.Services.CreateScope()){
    var DbContext = scope.ServiceProvider.GetRequiredService<APIContext>();
    DbContext.Database.Migrate();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();  

app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
