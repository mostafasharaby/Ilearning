using Demo1.Models;
using Demo1.Repository;
using Demo1.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Demo1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            // Add services to the container.
            builder.Services.AddControllersWithViews(
                //i=>i.Filters.Add() // pipe line filter
                ); 

            builder.Services.AddSession(); //-------------------------------------------------------//

                                           // Register the DbContext
            builder.Services.AddDbContext<MVCDbContext>(i =>{     i.UseSqlServer(builder.Configuration.GetConnectionString("cons"));         });
            builder.Services.AddDbContext<StudentDbContext>(i => { i.UseSqlServer("Data Source = . ; Database =  MVCstudent ;Integrated Security =true ; TrustServerCertificate = True"); });



            //builder.Services.AddIdentity<AppUser, IdentityRole>(op =>
            //{

            //    op.Password.RequireNonAlphanumeric = false;
            //    op.Password.RequiredLength = 4;

            //})
            //    .AddEntityFrameworkStores<MVCDbContext>();

            builder.Services.AddIdentity<StudentUser, IdentityRole>().AddEntityFrameworkStores<StudentDbContext>(); 




            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();   // Register the repository
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();

            var app = builder.Build();
            #region HTTPrequest
            // Configure the HTTP request pipeline.

            // custome middlware >> inline component

            // app.Use(async(HttpContext,next) =>
            // {
            //     await HttpContext.Response.WriteAsync("this is M1 \n");              
            //     await next.Invoke();
            //     await HttpContext.Response.WriteAsync("this is M1 \n");
            // });
            // app.Use(async (HttpContext, next) =>
            // {
            //     await HttpContext.Response.WriteAsync("this is M2\n");
            //     await next.Invoke();
            //     await HttpContext.Response.WriteAsync("this is M2\n");
            // });
            // app.Run(async (HttpContext) =>
            // {
            //     await HttpContext.Response.WriteAsync("this is Terminator\n");
            // });


            //app.Use(async (HttpContext, next) =>
            // {
            //     await HttpContext.Response.WriteAsync("this is M3\n");
            //     await next.Invoke();
            // });
            #endregion
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles(); // ------------------------------->html,css,js(wwwroot)

            app.UseRouting();

            app.UseAuthentication(); //identitfiy id ,name
            app.UseAuthorization();  // who you are (user , admin,...)
          

            app.UseSession();   //-----------------------------------------------------------------------------------//

            app.MapControllerRoute("Route1","emp/{id:int}", new { controller = "Employee",action= "Edit" });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
