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
    class BrandRepasitory : IBrandRepasitory
    {
        private readonly MobileShopContext _context;
        public BrandRepasitory(MobileShopContext context)
        {
            _context = context;
        }
        public int Create(Brand brand)
        {
            int result = -1;
            _context.Brand.Add(brand);
            result = _context.SaveChanges();
            return result;
        }

        public void Delete(int id)
        {
            Brand brand = _context.Brand.Find(id);
            brand.Status = false;
            _context.SaveChanges();
        }

        public async Task<Brand> Get(int id)
        {
            Brand  brand = await _context.Brand.FirstOrDefaultAsync(p => p.ID == id && p.Status == true);
            return brand;
        }

        public async Task<List<Brand>> GetAll()
        {
            return await _context.Brand.Where(p => p.Status == true).ToListAsync();
        }

        public void Update(Brand brand)
        {
            _context.Brand.Update(brand);
            _context.SaveChanges();
        }
    }
}
