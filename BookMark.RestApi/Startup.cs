using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BookMark.OrmData.Databases;
using BookMark.OrmData.Services;

namespace BookMark.RestApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            // services.AddDbContext<BookMarkDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("main")));
            services.AddDbContext<BookMarkDbContext>(opt => opt.UseSqlServer("server=localhost;database=bookmarkdb;user id=sa;password=Password12345"));
            services.AddScoped<BookMarkService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, BookMarkDbContext context) {
            context.Database.Migrate();
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
