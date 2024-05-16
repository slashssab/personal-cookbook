//using Microsoft.AspNetCore;
//using PersonalCookBook.Api;

//public static class Program
//{
//    /// <summary>
//    /// Main   
//    /// </summary>    
//    /// <param name="args"></param>    
//    /// 
//    public static void Main(string[] args)
//    {
//        CreateHostBuilder(args).Build().Run();
//    }

//    private static IWebHostBuilder CreateHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args)
//           .UseDefaultServiceProvider((context, options) =>
//           {
//               options.ValidateScopes = !context.HostingEnvironment.IsProduction();
//               options.ValidateOnBuild = true;
//           }).UseStartup<Startup>();
//}

using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpOverrides;
using PersonalCookBook.Application.Extensions;

const string _testEnvOrigin = "_testEnvOrigin";

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ForwardedHeadersOptions>(options => { options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto; options.KnownNetworks.Clear(); options.KnownProxies.Clear(); });

builder.Services.AddControllers();
builder.Services.AddSwaggerDocument(o =>
{
    o.Title = "My API";
    o.Version = "v1";
});
builder.Services.AddHealthChecks();
builder.Services.AddFastEndpoints();
builder.Services.AddApplicationHandlers();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: _testEnvOrigin,
                          policy =>
                          {
                              policy.WithOrigins("https://personal-cookbook-test.azurewebsites.net/",
                                                  "http://www.contoso.com");
                          });
    });
}
else
{
    builder.Services.AddCors();
}

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
builder.Services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp");

var app = builder.Build();

app.UseStaticFiles();
app.UseSpaStaticFiles();
app.UseRouting();

app.UseHealthChecks("/ready");
app.UseHealthChecks("/ping");
app.UseHealthChecks("/health");

app.UseForwardedHeaders();

if (app.Environment.IsProduction())
{
    app.Use((context, next) =>
    {
        context.Request.Scheme = "https";
        return next();
    });
}

if (app.Environment.IsDevelopment())
{

    app.UseCors(p => p.AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed((host) => true)
    .AllowCredentials());
    app.UseSwaggerGen();
}
else
{
    app.UseCors(_testEnvOrigin);
}


app.UseAuthentication();
app.UseAuthorization();

//app.UseFastEndpoints().UseSwaggerGen();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapFastEndpoints();
});

app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    if (context.User.Identity is { IsAuthenticated: false } && context.Request.Path == new PathString("/restaurant"))
    {
        await context.ChallengeAsync();
    }
    else { await next(); }
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";

    if (app.Environment.IsDevelopment())
    {
        var developmentProxy = app.Configuration["SpaDevelopmentServerUrl"];
        if (string.IsNullOrWhiteSpace(developmentProxy))
        {
            throw new Exception("No SpaDevelopmentServerUrl provided in configuration.");
        }
        spa.UseProxyToSpaDevelopmentServer(developmentProxy);
    }
});

app.Run();