using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BuildingManagement.Business.AdminS;
using BuildingManagement.Data.Domain;
using BuildingManagement.Data.Uow;
using BuildingManagement.Base.Response;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BuildingManagement.Controllers
{
    [ApiController]
    [Route("BuildingManagement/api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AdminService adminservice;
        
        public AdminController(AdminService adminService)
        {
            this.adminservice = adminService;
        }

        // HTTPPOST admin adds a house to the system
        [HttpPost("AddHouse")]
        public ApiResponse AddHouse([FromBody] House house)
        {
            var adm = adminservice.AddHouse(house);
            return adm;
        }

        // HTTPPOST admin adds a tenant to the system
        [HttpPost("AddTenant")]
        public ApiResponse AddTenant([FromBody] Tenant tenant)
        {
            var ten = adminservice.AddTenant(tenant);
            return ten;
        }

        // HTTPPOST admin adds a tenant's bill to the system
        [HttpPost("AddBillbyID")]
        public ApiResponse AddBillbyID([FromBody] Tenant tenant , int bill)
        {
            var addbill = adminservice.AddBillbyID(tenant , bill);
            return addbill;
        }

        // HTTPPOST admin adds a tenant's subscription fee to the system
        [HttpPost("AddSubscriptionFeebyID")]
        public ApiResponse AddSubscriptionFeebyID([FromBody] Tenant tenant, int fee)
        {
            var addbill = adminservice.AddBillbyID(tenant, fee);
            return addbill;
        }



        // HTTPPOST admin deletes a house from the system
        [HttpPost("DeleteHouse")]
        public ApiResponse DeleteHouse([FromBody] House house)
        {
            var hous = adminservice.DeleteHouse(house);
            return hous;
        }

        // HTTPPOST admin deletes a tenant from the system
        [HttpPost("DeleteTenant")]
        public ApiResponse DeleteTenant([FromBody] Tenant tenant)
        {
            var t = adminservice.DeleteTenant(tenant);
            return t;
        }

        
        
    }
}
