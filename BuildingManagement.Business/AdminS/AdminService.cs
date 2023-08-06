using BuildingManagement.Business.Generic;
using BuildingManagement.Data.Domain;
using BuildingManagement.Data.Uow;
using BuildingManagement.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingManagement.Base.Response;

namespace BuildingManagement.Business.AdminS
{
    public class AdminService : GenericService<Admin>
    {
        private readonly IUnitOfWork unitOfWork;
        public AdminService(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {
            this.unitOfWork = unitOfWork;
        
        
        }

        //admin user adds a new house to the system
        public ApiResponse AddHouse(House house)
        {
            unitOfWork.HouseRepository.Insert(house);
            return new ApiResponse();
        }

        //admin user adds a tenant to the system
        public ApiResponse AddTenant(Tenant tenant)
        {
            unitOfWork.TenantRepository.Insert(tenant);
            return new ApiResponse();
        }

        //admin user updates monthly bill of a specific user
        public ApiResponse AddBillbyID(Tenant tenant, int bill)
        {
            int id = tenant.TenantID;
            var thtenant = unitOfWork.TenantRepository.GetByID(id);
            thtenant.Bills = bill;
            unitOfWork.TenantRepository.Update(thtenant);
            return new ApiResponse();
        }

        //admin user updates monthly subscription fee of a specific user
        public ApiResponse AddSubscriptipnFeebyID(Tenant tenant, int fee)
        {
            int id = tenant.TenantID;
            var thtenant = unitOfWork.TenantRepository.GetByID(id);
            thtenant.SubscriptionFee = fee;
            unitOfWork.TenantRepository.Update(thtenant);
            return new ApiResponse();
        }

        //admin user can delet a house from the system
        public ApiResponse DeleteHouse(House house)
        {
            
            unitOfWork.HouseRepository.Delete(house);
            return new ApiResponse();
        }

        //admin user can delete a tenant from the system
        public ApiResponse DeleteTenant(Tenant tenant)
        {

            unitOfWork.TenantRepository.Delete(tenant);
            return new ApiResponse();
        }

        //admin user can update a house from the system
        public ApiResponse UpdateHouse(House house)
        {
            int id = house.HouseID;
            var h = unitOfWork.HouseRepository.GetByID(id);
           unitOfWork.HouseRepository.Update(h);
            
            return new ApiResponse();
        }

        //admin user can update a tenant from the system
        public ApiResponse UpdateTenant(Tenant tenant)
        {
            int id = tenant.TenantID;
            var t = unitOfWork.TenantRepository.GetByID(id);
            unitOfWork.TenantRepository.Update(t);

            return new ApiResponse();
        }


    }
}
