using BuildingManagement.Base.Response;
using BuildingManagement.Business.TenantS;
using Microsoft.AspNetCore.Mvc;
using BuildingManagement.Data.Domain;

namespace BuildingManagement.Controllers
{
    [ApiController]
    [Route("BuildingManagement/api/[controller]")]
    public class TenantController : ControllerBase
    {
        private readonly TenantService tenantservice;
        public TenantController(TenantService tenantservice)
        {
            this.tenantservice = tenantservice;
        }

        //Tenant user checks his monthly bill
        [HttpGet("CheckBill")]
        public double CheckBill([FromBody] Tenant tenant) 
        {
            var bill = tenantservice.CheckBill(tenant);
            return bill;

        
        }

        //Tenant user checks his monthly bill
        [HttpGet("CheckSubscriptionFee")]
        public double CheckSubscriptionFee([FromBody] Tenant tenant)
        {
            var fee = tenantservice.CheckSubscriptionFee(tenant);
            return fee;


        }



    }
}
