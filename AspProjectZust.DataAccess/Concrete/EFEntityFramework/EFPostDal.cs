using AspProjectZust.Core.DataAccess.EntityFramework;
using AspProjectZust.DataAccess.Abstract;
using AspProjectZust.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.DataAccess.Concrete.EFEntityFramework
{
    public class EFPostDal : EFEntityFrameworkRepositoryBase<Post, CustomIdentityDbContext>, IPostDal
    {
    }
}
