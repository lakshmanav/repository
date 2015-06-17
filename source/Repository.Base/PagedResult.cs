using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class PagedResult<TId, TEntity> : List<TEntity> 
        where TEntity : Entity<TId> 
        where TId : struct
    {
        public double TotalMatchingItems { get; set; }
    }
}
