using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        public bool Create(T entity);
        public bool Update(T entity);
        public bool Delete(T entity);
        public List<T> GetAll();
        public T GetbyId(int id);
        public bool Save();
        public int GetCount();
        public List<T> GetRecords(int page, int pageSize);


    }
}
