using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;

namespace VKBFrequencyAPI
{
    public class Startup
    {

        private string _connectionString;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(opt =>
            {
                opt.AddPolicy("DevPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

#if DEBUG
            //_connectionString = Configuration["scString"];
            _connectionString = ConfigurationManager.AppSettings["dev"];
#else
            //_connectionString = Configuration["scStringProd"];
            _connectionString = ConfigurationManager.AppSettings["prod"];
#endif

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<FeedbackContext>(
                opt => opt.UseNpgsql(_connectionString));

            services.AddTransient<DataSeed>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataSeed seed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("DevPolicy"); // Allow all origins
            app.UseMvc(routes => routes.MapRoute("default", "api/{controller}/{action}/{id?}"));

            // seed.SeedData(); // Development only
        }
    }
}

// build test