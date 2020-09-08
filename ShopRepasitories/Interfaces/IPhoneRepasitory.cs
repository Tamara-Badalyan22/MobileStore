using Shop.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepasitories.Interfaces
{
   public  interface IPhoneRepasitory
    {
        Task<List<Phone>> GetAll();
        Task<Phone> Get(int id);
        int Create(Phone phone);
        void Delete(int id);
        void Update(Phone phone);
        List<Phone> LowToHigh();
        List<Phone> HighToLow();
    }
}
