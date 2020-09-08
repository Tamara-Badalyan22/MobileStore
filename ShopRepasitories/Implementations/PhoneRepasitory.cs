using Microsoft.EntityFrameworkCore;
using MobileShop.Data.Data;
using Shop.Models;
using ShopRepasitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRepasitories.Implementations
{
    class PhoneRepasitory:IPhoneRepasitory
    {
        private readonly MobileShopContext _context;

        public PhoneRepasitory(MobileShopContext context)
        {
            _context = context;
        }

        public int Create(Phone phone)
        {
            int result = -1;
            _context.Phone.Add(phone);
            result = _context.SaveChanges();
            return result;
        }

        public async Task<List<Phone>> GetAll()
        {
            return await _context.Phone.Where(p=>p.Status==true).ToListAsync();
        }

        public async Task<Phone> Get(int id)
        {
            Phone phone = await _context.Phone.FirstOrDefaultAsync(p => p.ID == id && p.Status==true);
            return phone;
        }

        public void Delete(int id)
        {
            Phone product = _context.Phone.Find(id);
             product.Status = false;
            _context.SaveChanges();
        }
        public void Update(Phone phone)
        {
            // Phone newphone = _context.Phone.Find(phone.ID);
            _context.Phone.Update(phone);
            _context.SaveChanges();
            //_context.Phone.up;
        }

        public List<Phone> LowToHigh()
        {
          List<Phone> res= _context.Phone.OrderBy(p => p.Price).Where(p => p.Status == true).ToList();
        //  _context.SaveChanges();
            return res;
        }

        public List<Phone> HighToLow()
        {
            //IEnumerable<Phone> res = _context.Phone.OrderByDescending(p => p.Price);
            //return res;
            List<Phone> res = _context.Phone.OrderByDescending(p => p.Price ).Where(p=>p.Status==true).ToList();

           // _context.SaveChanges();
            return res;
        }
    }
}
