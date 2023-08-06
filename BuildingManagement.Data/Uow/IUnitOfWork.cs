using BuildingManagement.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingManagement.Data.Domain;

namespace BuildingManagement.Data.Uow
{
    public interface IUnitOfWork
    {
        void Complete();

        IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : class;
        IGenericRepository<Admin> AdminRepository { get; }
        IGenericRepository<Tenant> TenantRepository { get; }
        IGenericRepository<House> HouseRepository { get; }


    }
}
