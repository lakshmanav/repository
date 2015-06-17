using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Base
{
    public class Entity<TId> where TId : struct
    {
        public TId Id { get; set; }
    }
}
