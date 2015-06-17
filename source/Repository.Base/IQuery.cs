using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public interface IEntityQuery<TId, TEntity> 
        where TEntity : Entity<TId> 
        where TId : struct
    {

    }
}
