using Microsoft.AspNetCore.Mvc;
using OnlineStoreModel.Models.BrandModels;
using OnlineStoreModel.ServiceContracts;

namespace OnlineStoreAdmin
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService) // Constructor injection of the IBrandService
        {
            _brandService = brandService;
        }
        // GET: BrandController
        [HttpGet]
        [Route("/ListBrand")]
        public ActionResult ListBrand()
        {
            List<BrandModel> brandModels = this._brandService.ListBrands();
            return View(brandModels);
        }

        [HttpGet]
        [Route("/DeleteBrand/{id:guid}")]
        public ActionResult DeleteBrand(Guid id)
        {
            // Implement the logic to delete the brand with the specified id
            // For example, you can call a method in the IBrandService to perform the deletion
            this._brandService.DeleteBrand(id);

            // After deletion, redirect back to the ListBrand action to refresh the list of brands
            return RedirectToAction("ListBrand");
        }

        [HttpGet]
        [Route("/AddBrand")]
        public ActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        [Route("/AddBrand")]
        public ActionResult AddBrand(AddBrandModel addBrandModel)
        {
            if (addBrandModel == null || !ModelState.IsValid)
            {
                return View(addBrandModel);
            }

            // Call the service to add the brand
            this._brandService.AddBrand(addBrandModel);
            return RedirectToAction("ListBrand");
        }

        [HttpGet]
        [Route("/ModifyBrand/{id:guid}")]
        public ActionResult ModifyBrand(Guid id)
        {
            // Implement the logic to retrieve the brand with the specified id
            // For example, you can call a method in the IBrandService to fetch the brand
            if (id == Guid.Empty)
            {
                return RedirectToAction("ListBrand");
            }
            ModifyBrandModel modifyBrand = this._brandService.GetBrandById(id);
            if (modifyBrand == null)
            {
                return RedirectToAction("ListBrand");
            }
            return View(modifyBrand);
        }

        [HttpPost]
        [Route("/ModifyBrand/{id:guid}")]
        public ActionResult ModifyBrand(ModifyBrandModel modifyBrandModel, Guid id)
        {
            if (modifyBrandModel == null || !ModelState.IsValid)
            {
                return View(modifyBrandModel);
            }

            // Call the service to modify the brand
            this._brandService.ModifyBrand(modifyBrandModel, id);
            return RedirectToAction("ListBrand");
        }
    }
}

