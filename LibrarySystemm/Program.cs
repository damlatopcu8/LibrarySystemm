//using MongoDB.Bson;
//using MongoDB.Bson.Serialization.Attributes;

//using LibrarySystemm.DataAccessLayer;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();

//namespace LibrarySystemm
//{
//    public class Program
//    {
//        public Program(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }
//        public IConfiguration Configuration { get; }
//        public void ConfigureServices(IServiceCollection services)
//        {
//            string mongoConnectionString = this.Configuration.GetConnectionString("MongoConnectionString");
//            services.AddTransient(s => new BookManager(mongoConnectionString, "DbLibrarySystemm", "Book"));

//            services.AddMvc();
//        }

//        public void Configure(IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseMvc(routes =>
//            {
//                routes.MapRoute(

//                name: "default",
//                    template: "{controller=Home}/{action=Index}/{id?}");
//            });
//            app.UseStaticFiles();
//            app.UseStatusCodePages();
//        }
//    }
//}



using LibrarySystemm.Models;
using LibrarySystemm.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoDBSettings>(
builder.Configuration.GetSection(nameof(MongoDBSettings)));
builder.Services.AddSingleton<IMongoDBSettings>(sp =>
sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
builder.Services.AddSingleton<BookService>();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
//builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();



var app = builder.Build();
//string mongoConnectionString = app.Configuration.GetConnectionString("MongoConnectionString");
//builder.Services.AddTransient(s => new KütüphaneSistemi(mongoConnectionString, "DbBlogTodoApp", "Todos"));


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//app.UseMvc(routes =>
//{
//    routes.MapRoute(
//        name: "default",
//        template: "{controller=Home}/{action=Index}/{id?}");
//});

//services.AddMvc(options => options.EnableEndpointRouting = false);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();



