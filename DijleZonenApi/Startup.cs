using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DijleZonenApi.dijlezonen;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DijleZonenApi.DAL;

namespace DijleZonenApi
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
            //db context and repos
            services.AddDbContext<_1718_SPRINGDBContext>();
            services.AddScoped<BalanceTopupDAO, BalanceTopupDAOEfImpl>();
            services.AddScoped<CloseoutDAO, CloseoutDAOEfImpl>();
            services.AddScoped<CustomerDAO, CustomerDAOEfImpl>();
            services.AddScoped<EventDAO, EventDAOEfImpl>();
            services.AddScoped<EventSubscriptionDAO, EventSubscriptionDAOEfImpl>();
            services.AddScoped<OrderDAO, OrderDAOEfImpl>();
            services.AddScoped<ProductDAO, ProductDAOEfImpl>();
            services.AddScoped<RollbackDAO, RollbackDAOEfImpl>();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "dijlezonen.be",
                        ValidAudience = "dijlezonen.be",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["MySection:SecurityKey"]))
                    };
                });

            services.AddMvc();
            services.AddSingleton<IConfiguration>(Configuration);

            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DZApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
