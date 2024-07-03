using Plugins.DataStore.InMemory;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;

namespace Supermarket_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();

            builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
            builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            builder.Services.AddTransient<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
            builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}");

            app.Run();
        }
    }
}
