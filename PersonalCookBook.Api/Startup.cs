using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpOverrides;

namespace PersonalCookBook.Api
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options => { options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto; options.KnownNetworks.Clear(); options.KnownProxies.Clear(); });

            services.AddControllers();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddCors();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                });
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "ClientApp");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(p => p.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials());

            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseRouting();

            app.UseHealthChecks("/ready");
            app.UseHealthChecks("/ping");
            app.UseHealthChecks("/health");

            app.UseForwardedHeaders();

            if (env.IsProduction())
            {
                app.Use((context, next) =>
                {
                    context.Request.Scheme = "https";
                    return next();
                });
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });

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

                if (env.IsDevelopment())
                {
                    var developmentProxy = Configuration["SpaDevelopmentServerUrl"];
                    if (string.IsNullOrWhiteSpace(developmentProxy))
                    {
                        throw new Exception("No SpaDevelopmentServerUrl provided in configuration.");
                    }
                    spa.UseProxyToSpaDevelopmentServer(developmentProxy);
                }
            });
        }
    }
}
