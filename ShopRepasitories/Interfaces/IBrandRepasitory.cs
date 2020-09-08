using Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepasitories.Interfaces
{
   public  interface IBrandRepasitory
    {
        Task<List<Brand>> GetAll();
        Task<Brand> Get(int id);
        int Create(Brand brand);
        void Delete(int id);
        void Update(Brand brand);
    }
}
