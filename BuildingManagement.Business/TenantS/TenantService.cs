using BuildingManagement.Business.Generic;
using System;
using BuildingManagement.Data.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingManagement.Data.Uow;
using BuildingManagement.Base.Response;

namespace BuildingManagement.Business.TenantS
{
    public class TenantService : GenericService<Tenant>
    {
        private readonly IUnitOfWork unitOfWork;

        public TenantService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        //Tenant user can check his monthly bill
        public double CheckBill(Tenant tenant)
        {
            int id = tenant.TenantID;
            var tenn = unitOfWork.TenantRepository.GetByID(id);
            double bill = tenn.Bills;
            return bill;

        }

        //Tenant user can check his monthly fee
        public double CheckSubscriptionFee(Tenant tenant)
        {
            int id = tenant.TenantID;
            var tenn = unitOfWork.TenantRepository.GetByID(id);
            double fee = tenn.SubscriptionFee;
            return fee;

        }



    }
}
