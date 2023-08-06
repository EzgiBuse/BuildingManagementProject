using BuildingManagement.Base.Response;
using BuildingManagement.Data.Uow;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BuildingManagement.Business.Generic
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork unitOfWork;
        public GenericService(IUnitOfWork unitOfWork) {
        
            this.unitOfWork = unitOfWork;
        }
        public virtual ApiResponse Delete(int Id)
        {
            var entity = unitOfWork.DynamicRepository<TEntity>().GetByID(Id);
            if(entity == null)
            {
                return new ApiResponse("Not Found");
            }

            unitOfWork.DynamicRepository<TEntity>().DeleteById(Id);
            unitOfWork.Complete();
            return new ApiResponse();
        }

        public virtual ApiResponse<List<TEntity>> GetAll(params string[] includes)
        {
            var entity = unitOfWork.DynamicRepository<TEntity>().GetAllWithInclude(includes);
            return new ApiResponse<List<TEntity>>(entity);
        }

        public virtual ApiResponse<TEntity> GetById(int id, params string[] includes)
        {
            var entity = unitOfWork.DynamicRepository<TEntity>().GetByIdWithInclude(id, includes);
            return new ApiResponse<TEntity>(entity);
        }

        public virtual ApiResponse Insert(TEntity entity)
        {
            unitOfWork.DynamicRepository<TEntity>().Insert(entity);
            unitOfWork.DynamicRepository<TEntity>().Save();
            return new ApiResponse();
        }

        public virtual ApiResponse Update(int id, TEntity entity)
        {
            var exists = unitOfWork.DynamicRepository<TEntity>().GetByID(id);
            if (exists == null)
            {
                return new ApiResponse("Not Found");
            }

            unitOfWork.DynamicRepository<TEntity>().Update(entity);
            unitOfWork.DynamicRepository<TEntity>().Save();
            return new ApiResponse();
        }
    }
}
