using BuildingManagement.Data.Domain;
using BuildingManagement.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BuildingDbContext _dbContext;

        public UnitOfWork(BuildingDbContext dbContext)
        {
            this._dbContext = dbContext;
            AdminRepository = new GenericRepository<Admin>(dbContext);
            TenantRepository = new GenericRepository<Tenant>(dbContext);
            HouseRepository = new GenericRepository<House>(dbContext);

        }
        public IGenericRepository<Admin> AdminRepository { get; set; }

        public IGenericRepository<Tenant> TenantRepository { get; set; }

        public IGenericRepository<House> HouseRepository { get; set; }


        public void Complete()
        {
            _dbContext.SaveChanges();
        }

        public IGenericRepository<Entity> DynamicRepository<Entity>() where Entity : class
        {
            return new GenericRepository<Entity>(_dbContext);
        }
    }
}
