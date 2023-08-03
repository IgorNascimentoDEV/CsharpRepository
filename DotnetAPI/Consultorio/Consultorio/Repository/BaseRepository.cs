using Consultorio.Context;
using Consultorio.Repository.Interfaces;

namespace Consultorio.Repository
{
    public class BaseRepository : IBaseRepository
    {
        public readonly ConsultorioContext _context;
        public BaseRepository(ConsultorioContext context)
        {
            this._context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
