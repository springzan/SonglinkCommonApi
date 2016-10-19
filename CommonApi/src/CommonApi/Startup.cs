
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Api.efcore;
using Api.Domain.IRepositories;
using Api.efcore.Repositories;
using Api.application.SyscodeApp;
using Api.application.FeedbackApp;
using Api.application.FeedbackSyscodeApp;

namespace CommonApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            //获取数据库连接字符串
            var sqlConnectString = Configuration.GetConnectionString("DefaultConnection");
            //添加数据上下文
            //services.AddDbContext<ApiDbContext>(options => options.UseMySQL(sqlConnectString));
            services.AddDbContext<ApiDbContext>(options => options.UseMyCat(sqlConnectString));

            //仓储及服务进行依赖注入
            services.AddScoped<ISyscodeRepository, SyscodeRepository>();
            services.AddScoped<ISyscodeAppService, SyscodeAppService>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackAppSevice, FeedbackAppSevice>();
            services.AddScoped<IFeedbackSyscodeRepository, FeedbackSyscodeRepository>();
            services.AddScoped<IFeedbackSyscodeAppService, FeedbackSyscodeAppService>();

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
