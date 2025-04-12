using Azure;
using Core.Entity;
using Core.Service;
using Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DbService
{
    public class DbCoreService<T> : ICoreService<T> where T : CoreEntity
    {

        private readonly EdemyDbContext _db;

        public DbCoreService(EdemyDbContext db)
        {
            _db = db;
        }
        public bool Create(T entity)
        {
            try
            {
                _db.Set<T>().Add(entity);
                return Save();
                
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(T entity)
        {
            try
            {
                _db.Set<T>().Remove(entity);
                return Save();
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Update(T entity)
        {
            try
            {
                _db.Set<T>().Update(entity);
                return Save();
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<T> GetAll() => _db.Set<T>().ToList();

        public T GetbyId(int id) => _db.Set<T>().FirstOrDefault(x => x.ID == id)!;

        public bool Save() => _db.SaveChanges() > 0 ? true : false;

        public int GetCount() => GetAll().Count;

        public List<T> GetRecords(int page, int pageSize)
        {
          return GetAll().Skip((page -1) * pageSize).Take(pageSize).ToList();
        }
    }
}
