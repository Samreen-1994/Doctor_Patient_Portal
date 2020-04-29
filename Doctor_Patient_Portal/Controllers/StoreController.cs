using BusinessLayer.Store;
using DTO;
using DTO.DBModels;
using Microsoft.AspNetCore.Mvc;

namespace Doctor_Patient_Portal.Controllers
{
    [Route("api/store")]
    [ApiController]
    [Produces("application/json")]
    public class StoreController : Controller
    {
        private readonly IStoreManager storeManager;

        public StoreController(IStoreManager _storeManager)
        {
            this.storeManager = _storeManager;
        }

        [HttpGet]
        [Route("GetMedicalStoreByCity")]
        public IActionResult GetMedicalStoreByCity(string city)
        {
            var stores = this.storeManager.FetchMedicalStoreByCity(city);
            return Ok(stores);
        }

        [HttpPost]
        [Route("CreateMedicineRequest")]
        public IActionResult CreateMedicineRequest(MedicineRequest mRequest)
        {
            var created = this.storeManager.CreateMedicineRequest(mRequest);
            return Ok(created);
        }

        [HttpPost]
        [Route("FetchMedicineRequestForUser")]
        public IActionResult FetchMedicineRequestForUser(User user)
        {
            var response = this.storeManager.FetchMedicineRequestResponse(user);
            return Ok(response);
        }
    }
}
