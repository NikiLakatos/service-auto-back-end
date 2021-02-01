
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ServiceAuto.DataRepo.Repository;
using ServiceAutoApp.DataRepo;
using ServiceAutoApp.DataRepo.Interface;
using ServiceAutoApp.DataRepo.Repository;
using ServiceAutoApp.HelpUs;



namespace ServiceAutoApp
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
            services.AddControllersWithViews();
            services.AddCors();
            services.AddControllers();
            var addSection = Configuration.GetSection("Database");
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddDbContext<ServiceAutoContext>(options => options.UseSqlServer(addSection.Get<AddSection>().ConnectionString), ServiceLifetime.Scoped);
            
            // In production, the React files will be served from this directory
            services.AddScoped<IUserRepo ,UserRepo>();
            services.AddScoped<IClientRepo ,ClientRepo>();
            services.AddScoped<ICarRepo, CarRepo>();
            services.AddScoped<IVisitRepo, VisitRepo>();
            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseAuthorization();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());
        }

    }
}
