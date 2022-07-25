using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Caching
{

    public interface ICacheService<T> 
    {   
         Task<T> GetAsync(string cacheKey);

        Task SetAsync (string cacheKey, T value, TimeSpan duration);

        void DeleteAsync(string cacheKey);

    }
}
