using AspProjectZust.Business.Abstract;
using AspProjectZust.DataAccess.Abstract;
using AspProjectZust.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjectZust.Business.Concrete
{
    public class UserService : IUserService
    {
        private IUserDal _userDal;

        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public Task Add(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomIdentityUser>> GetAll()
        {
            return await _userDal.GetList();
        }

        public Task<List<CustomIdentityUser>> GetAllByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomIdentityUser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(CustomIdentityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
