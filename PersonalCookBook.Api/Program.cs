using Microsoft.AspNetCore;
using PersonalCookBook.Api;

public static class Program
{
    /// <summary>
    /// Main   
    /// </summary>    
    /// <param name="args"></param>    
    /// 
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IWebHostBuilder CreateHostBuilder(string[] args) => WebHost.CreateDefaultBuilder(args)
           .UseDefaultServiceProvider((context, options) =>
           {
               options.ValidateScopes = !context.HostingEnvironment.IsProduction();
               options.ValidateOnBuild = true;
           }).UseStartup<Startup>();
}
