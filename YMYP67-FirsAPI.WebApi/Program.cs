
using YMYP67_FirstAPI.Business.Abstract;
using YMYP67_FirstAPI.Business.Concrete;
using YMYP67_FirstAPI.DataAccess.Abstract;
using YMYP67_FirstAPI.DataAccess.Concrete.AdoNet;
using YMYP67_FirstAPI.DataAccess.Concrete.EntityFramework;
using YMYP67_FirstAPI.DataAccess.Concrete.NHibernate;

namespace YMYP67_FirsAPI.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        // Dependency Injection Lifecycle (Ya�am D�ng�s�)

        // AddScoped() : Her istek i�in yeni bir �rnek olu�turulur. (Web uygulamalar�nda genellikle kullan�l�r). Response d�nd�kten sonra nesnenin �mr� tamamlan�r.

        // AddSingleton() : Uygulama ba�lat�ld���nda tek bir �rnek olu�turulur ve bu �rnek t�m isteklerde kullan�l�r. Uygulama kapat�lana kadar bu �rnek ya�amaya devam eder.

        // AddTransient() : Her istek i�in yeni bir �rnek olu�turulur. Ancak, bu �rnekler istek tamamland���nda hemen yok edilir. Genellikle k�sa �m�rl� nesneler i�in kullan�l�r.


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddDbContext<FirstApiContext>();
        builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
        builder.Services.AddScoped<ICategoryService, CategoryManager>();
        builder.Services.AddScoped<IProductDal, EfProductDal>();
        builder.Services.AddScoped<IProductService, ProductManager>();
        builder.Services.AddScoped<ICustomerService,CustomerManager>();
        builder.Services.AddScoped<ICustomerDal,EfCustomerDal>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
