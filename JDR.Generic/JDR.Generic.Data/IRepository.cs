using JDR.Generic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Data
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
                
        TEntity Create(TEntity entity);
        List<TEntity> Read();
        TEntity ReadBy(int id);
        List<TEntity> ReadyByFilters(Dictionary<string, string> filters);
        void Update(TEntity entity);
        void Delete(int id);

        
    }
}
