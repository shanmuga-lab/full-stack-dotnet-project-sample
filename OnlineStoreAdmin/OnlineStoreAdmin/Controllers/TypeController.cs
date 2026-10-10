using Microsoft.AspNetCore.Mvc;
using OnlineStoreModel.Models.TypeModels;
using OnlineStoreModel.ServiceContracts;

namespace OnlineStoreAdmin.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService) // Constructor injection of the ITypeService    
        {
            _typeService = typeService;
        }
        // GET: TypeController
        [HttpGet]
        [Route("/ListType")]
        public ActionResult ListType()
        {
            List<TypeModel> types = this._typeService.ListTypes();
            return View(types);
        }

        [HttpGet]
        [Route("/AddType")]
        public ActionResult AddType()
        {
            return View();
        }

        [HttpPost]
        [Route("/AddType")]
        public ActionResult AddType(AddTypeModel addTypeModel)
        {
            if (addTypeModel == null || !ModelState.IsValid)
            {
                return View(addTypeModel);
            }

            // Call the service to add the type
            this._typeService.AddType(addTypeModel);
            return RedirectToAction("ListType");
        }

        [HttpGet]
        [Route("/ModifyType/{id:guid}")]
        public ActionResult ModifyType(Guid id)
        {
            ModifyTypeModel modifyTypeModel = this._typeService.GetTypeById(id);
            return View(modifyTypeModel);
        }

        [HttpPost]
        [Route("/ModifyType/{id:guid}")]
        public ActionResult ModifyType(ModifyTypeModel modifyTypeModel, Guid id)
        {
            if (modifyTypeModel == null || !ModelState.IsValid)
            {
                return View(modifyTypeModel);
            }

            // Call the service to modify the type
            this._typeService.ModifyType(modifyTypeModel, id);
            return RedirectToAction("ListType");
        }

        [HttpGet]
        [Route("/DeleteType/{id:guid}")]
        public ActionResult DeleteType(Guid id)
        {
            this._typeService.DeleteType(id);

            // After deletion, redirect back to the ListType action to refresh the list of types
            return RedirectToAction("ListType");
        }
    }
}
