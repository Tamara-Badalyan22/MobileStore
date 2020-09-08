using Microsoft.Extensions.DependencyInjection;
using ShopRepasitories.Implementations;
using ShopRepasitories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopRepasitories.Injections
{
    public static class PhoneExtentions
    {
        public static  void AddPhoneInjection(this IServiceCollection service)
        {
            service.AddTransient<IPhoneRepasitory, PhoneRepasitory>();
            service.AddTransient<IBrandRepasitory, BrandRepasitory>();
        }
    }
}
