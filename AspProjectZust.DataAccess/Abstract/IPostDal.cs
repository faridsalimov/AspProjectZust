using AspProjectZust.Core.DataAccess;
using AspProjectZust.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.DataAccess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
    }
}
