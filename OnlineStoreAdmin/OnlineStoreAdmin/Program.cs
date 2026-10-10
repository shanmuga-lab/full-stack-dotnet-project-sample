using Microsoft.EntityFrameworkCore;
using OnlineStoreModel.ServiceContracts;
using OnlineStoreRepository;
using OnlineStoreService;

var builder = WebApplication.CreateBuilder(args);

// Register the BrandService with the dependency injection container
// Inversion of Control (IoC) is a design principle that helps to decouple the components of an application. 
// In this case, we are using dependency injection to inject the BrandService into the BrandController. 
// This allows us to easily swap out the implementation of the IBrandService interface without having to modify the BrandController class.
// Control of creation and management of the BrandService is inverted from the BrandController to the dependency injection container, 
// which is responsible for creating and managing the lifetime of the BrandService instance.
// Having object created in one place and injected into the controller is a good practice because it promotes loose coupling,
// which makes the code more maintainable and testable. 
//It also allows for easier unit testing of the BrandController class, as we can easily mock the IBrandService interface and inject it into the controller for testing purposes.
builder.Services.Add(new ServiceDescriptor(
    typeof(IBrandService), 
    typeof(BrandService),
    ServiceLifetime.Transient));

builder.Services.Add(new ServiceDescriptor(
    typeof(ITypeService), 
    typeof(TypeService),
    ServiceLifetime.Transient));

builder.Services.Add(new ServiceDescriptor(
    typeof(IProductService), 
    typeof(ProductService),
    ServiceLifetime.Transient));

builder.Services.Add(new ServiceDescriptor(typeof(IAzureBlobService), typeof(AzureBlobService),
    ServiceLifetime.Transient));

builder.Services.AddDbContext<BrandRepository>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<TypeRepository>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ProductRepository>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
