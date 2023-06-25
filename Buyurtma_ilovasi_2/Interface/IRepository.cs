using Buyurtma_ilovasi_2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyurtma_ilovasi_2.Interface
{
    public interface IRepository <TModel, TViewModel>
    {
        public Task<int> CreateAsync(TModel obj);
        
        public Task<int> UpdateAsync(long obj, TModel editedObj);

        public Task<int> DeleteAsync(long id);

        public Task<IList<TViewModel>> GetAllAsync(PagenationParams @params);

        public Task<TViewModel> GetAsync(long id); 
        
    }
}
