using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using GameForum.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GameForum.EFDataAccess;
using GameForum.ApplicationLogic.Model;
using GameForum.ApplicationLogic.Abstractions;
using GameForum.ApplicationLogic.Services;

namespace GameForum
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<GameForumDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddScoped<IRepository, BaseRepository>();

            services.AddScoped<IUser, UserRepository>();
            services.AddScoped(typeof(IUser), typeof(UserRepository));
            services.AddScoped<UserService>();
            services.AddScoped<GameService, GameRepository>();
            
            //services.AddScoped<GameService>();
            services.AddScoped<IComment, CommentRepository>();
            //services.AddScoped<CommentService>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            CreateRoles(services).Wait();
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var IdentityUserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var UserService = serviceProvider.GetRequiredService<UserService>();

            IdentityResult roleResult;
            //here in this line we are adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("User");
            if (!roleCheck)
            {
                //here in this line we are creating admin role and seed it to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("User"));
            }

            roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {   
                //here in this line we are creating admin role and seed it to the database
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (IdentityUserManager.FindByNameAsync("adminpaiangan@admin.com").Result == null)
            {
                var user = new IdentityUser { UserName = "adminpaiangan@admin.com", Email = "adminpaiangan@admin.com", EmailConfirmed = true };
                var result = await IdentityUserManager.CreateAsync(user, "P@ssw0rd");
                if (result.Succeeded)
                {
                    UserService.CreateNewUser(Guid.Parse(user.Id), "adminpaiangan@admin.com", "P@ssw0rd", true);
                    //UserService.GetUserByUserId(IdentityUserManager.FindByNameAsync("adminpaiangan@admin.com").Result.Id).IsAdmin = true;
                }
                //var user1 = new User { Username = "adminpaiangan@admin.com", Email = "adminpaiangan@admin.com" };
                //var result1 = await UserManager.CreateAsync(user1, "P@ssw0rd");
                await IdentityUserManager.AddToRoleAsync(user, "Admin");
                //await UserManager.AddToRoleAsync(user1, "Admin");
            }

            //here we are assigning the Admin role to the User that we have registered above 
            //Now, we are assinging admin role to this user("Ali@gmail.com"). When will we run this project then it will
            //be assigned to that user.
        }
    }
}
