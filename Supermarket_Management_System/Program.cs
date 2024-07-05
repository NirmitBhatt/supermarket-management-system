using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases;
using UseCases.TransactionsUseCases;

namespace Supermarket_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MarketContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SupermarketManagement"));
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
            builder.Services.AddSingleton<IProductRepository, ProductsInMemoryRepository>();
            builder.Services.AddSingleton<ITransactionsRepository, TransactionsInMemoryRepository>();

            builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
            builder.Services.AddTransient<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
            builder.Services.AddTransient<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
            builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();

            builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
            builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
            builder.Services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();
            builder.Services.AddTransient<IViewProductsInCategoryUseCase, ViewProductsInCategoryUseCase>();
            builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
            builder.Services.AddTransient<IViewSelectedProductUseCase, ViewSelectedProductUseCase>();

            builder.Services.AddTransient<IAddTransactionUseCase, AddTransactionUseCase>();
            builder.Services.AddTransient<IGetTransactionsByDateAndCashierUseCase,  GetTransactionsByDateAndCashierUseCase>();
            builder.Services.AddTransient<ISearchTransactionUseCase, SearchTransactionUseCase>();

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
