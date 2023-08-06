using BuildingManagement.Base.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Business.Generic
{
    public interface IGenericService<TEntity>
    {
        ApiResponse<List<TEntity>> GetAll(params string[] includes);
        ApiResponse<TEntity> GetById(int id, params string[] includes);
        ApiResponse Insert(TEntity entity);
        ApiResponse Update(int id, TEntity entity);
        ApiResponse Delete(int Id);
    }
}
