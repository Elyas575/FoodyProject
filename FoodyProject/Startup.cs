using FoodyProject.ActionFilters;
using FoodyProject.Helpers.Extensions;
using FoodyProject.Helpers.SettingModel;
using FoodyProject.Installer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodyProject
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
            services.InstallServicesAssembly(Configuration);

            services.AddAutoMapper(typeof(Startup));
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidateRestaurantExistsAttribute>();
            services.AddScoped<ValidateRestaurantContactForRestaurantExistsAttribute>();
            services.AddScoped<ValidateCategoryForRestaurantExistsAttribute>();
            services.AddScoped<ValidateMealForCategoryExistsAttribute>();
            services.AddScoped<ValidateCustomerExistsAttribute>();
            services.AddScoped<ValidateCustomerContactForCustomerExistsAttribute>();
            services.AddScoped<ValidateOrderForCustomerExistsAttribute>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();            
            }
            else
            {
                app.UseHsts();
            }

            app.ConfigureExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthentication();

            //Here we are bringing SwaggerSettings's fields from appsettings.json,
            //and bind them to the fields of SwaggerSettings class in the Helper folder.
            var swaggerSetting = new SwaggerSettings();
            Configuration.GetSection(/*nameof(swaggerSetting*/"SwaggerSettings").Bind(swaggerSetting);

            app.UseSwagger(options =>
            {
                options.RouteTemplate = swaggerSetting.JsonRoute;
            });

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(swaggerSetting.UiEndPoint, swaggerSetting.Description);
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
