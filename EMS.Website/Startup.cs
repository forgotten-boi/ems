using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EMS.Website.Data;
using EMS.Website.Models;
using EMS.Website.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using EMS.Repository.Repositories;
using EMS.Services.Interface;
using EMS.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace EMS.Website
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            

            // Add application services.
         
            services.AddScoped(typeof(IArtistInfoService), typeof(ArtistInfoService));
            services.AddScoped(typeof(IMovieInfoService), typeof(MovieInfoService));
            services.AddScoped(typeof(IProducerDetailService), typeof(ProducerDetailService));
            services.AddScoped(typeof(IDistributersDetailService), typeof(DistributersDetailService));
            services.AddScoped(typeof(IExhibitorsDetailService), typeof(ExhibitorsDetailService));
            services.AddScoped(typeof(IBannerInfoService), typeof(BannerInfoService));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
            services.AddScoped(typeof(IApprovalInfoService), typeof(ApprovalInfoService));

            services.AddScoped(typeof(IArtistInfoRepository), typeof(ArtistInfoRepository));
            services.AddScoped(typeof(IMovieInfoRepository), typeof(MovieInfoRepository));
            services.AddScoped(typeof(IProducerDetailRepository), typeof(ProducerDetailRepository));
            services.AddScoped(typeof(IDistributersDetailRepository), typeof(DistributersDetailRepository));
            services.AddScoped(typeof(IExhibitorsDetailRepository), typeof(ExhibitorsDetailRepository));
            services.AddScoped(typeof(IBannerRepository), typeof(BannerRepository));
            services.AddScoped(typeof(IEmployeeRepository), typeof(EmployeeRepository));
            services.AddScoped(typeof(IApprovalInfoRepository), typeof(ApprovalInfoRepository));

            services.AddTransient<IEmailSender, EmailSender>();

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseInMemoryDatabase("CustomDB"));
            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<EMS.DataAccess.ProjectDbContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("EMS.Website")));

            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            #region Nlog
            services.AddLogging();
            //var provider = services.BuildServiceProvider();

            //var factory = provider.GetService<ILoggerFactory>();
            //factory.AddNLog();
            ////NLog.LogManager.LoadConfiguration("nlog.config")
            //factory.ConfigureNLog("nlog.config");

            //var logger = provider.GetService<ILogger<Program>>();
            //logger.LogCritical("hello nlog");
            #endregion


            services.AddSingleton<UserContext>();
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddMvc();
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(GlobalExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));
            });
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                //c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://sobiztrend.com.np"));
            });

            services.AddResponseCompression();
            services.Configure<GzipCompressionProviderOptions>
            (options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            env.ConfigureNLog("nlog.config");
            app.UseCors(options => options.AllowAnyOrigin());
            //app.UseCors(options => options.WithOrigins("http://sobiztrend.com.np"));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        
    }
}
