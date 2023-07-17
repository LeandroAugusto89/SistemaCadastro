
using Microsoft.EntityFrameworkCore;
using SistemaCadastro.Data;
using SistemaCadastro.Repositorio;

namespace ControleDeContatos
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
            //Configurando Entity Framework para conectar com Sql server
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BDContext>(o => o.UseSqlServer(Configuration.GetConnectionString("Data Source=LAPTOP-MFTL06NT;Initial Catalog=SistemaCadastro;Integrated Security=False;User ID=sa;Password=Latl3742;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")));

            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
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
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
