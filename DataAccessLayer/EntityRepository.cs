using ModelLogic1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DataAccessLayer
{
    public class EntityRepository<T> : IRepository<T> where T : class, IDomainObject
    {
        private DBContext _context;
        public EntityRepository(DBContext context)
        {
            _context = context;
            
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().SingleOrDefault(e => e.ID == id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> ReadAll()
        {
            return _context.Set<T>().ToList();
        }

        public T ReadById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            Player origin = _context.Set<Player>().Where(o => o.ID == entity.ID).FirstOrDefault();
            if(origin != null)
            {
                _context.Entry(origin).CurrentValues.SetValues(entity);
            }
            _context.SaveChanges();
        }
    }
}
