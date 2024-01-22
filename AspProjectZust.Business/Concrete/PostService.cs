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
    public class PostService : IPostService
    {
        private IPostDal _postDal;

        public PostService(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public async Task Add(Post post)
        {
            await _postDal.Add(post);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Post>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
