using System.Collections.Generic;

namespace mySeries.Interfaces
{
    public interface RepositoryInterface<T>
    {
        List<T> List();
        T ReturnById(int id);        
        void Insert(T entity);        
        void Delete(int id);        
        void Update(int id, T entity);
        int NextId();
    }
}
