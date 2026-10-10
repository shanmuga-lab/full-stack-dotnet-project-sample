using Microsoft.AspNetCore.Mvc;
using OnlineStoreModel.Models.ProductModels;
using OnlineStoreModel.ServiceContracts;

namespace OnlineStoreAdmin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ITypeService _typeService;

        public ProductController(IProductService productService, IBrandService brandService, ITypeService typeService)
        {
            _productService = productService;
            _brandService = brandService;
            _typeService = typeService;
        }

        [HttpGet]
        [Route("/")]
        public ActionResult Index()
        {
            List<ListProductModel> products = _productService.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        [Route("/CreateProduct")]
        public ActionResult CreateProduct()
        {
            ViewBag.Brands = _brandService.ListBrands();
            ViewBag.Types = _typeService.ListTypes();
            return View();
        }

        [HttpPost]
        [Route("/CreateProduct")]
        public async Task<ActionResult> CreateProduct(CreateProductModel createProductModel)
        {
            if (ModelState.IsValid)
            {
                await this._productService.CreateProductAsync(createProductModel);
                return RedirectToAction("Index");
            }
            ViewBag.Brands = _brandService.ListBrands();
            ViewBag.Types = _typeService.ListTypes();
            return View(createProductModel);
        }

        [HttpGet]
        [Route("/DeleteProduct/{id:Guid}")]
        public ActionResult DeleteProduct(Guid id)
        {
            this._productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/EditProduct/{id:Guid}")]
        public ActionResult EditProduct(Guid id)
        {
            UpdateProductModel product = this._productService.GetProductById(id);
            ViewBag.Brands = _brandService.ListBrands();
            ViewBag.Types = _typeService.ListTypes();
            return View(product);
        }

        [HttpPost]
        [Route("/EditProduct/{id:Guid}")]
        public async Task<ActionResult> EditProduct(Guid id, UpdateProductModel updateProductModel)
        {
            if (updateProductModel != null)
            {
                await this._productService.UpdateProductAsync(updateProductModel);
                return RedirectToAction("Index");
            }
            ViewBag.Brands = _brandService.ListBrands();
            ViewBag.Types = _typeService.ListTypes();
            return View(updateProductModel);
        }
    }
}
