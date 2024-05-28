using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Models;
using Talabat.Core.Models.OrederAggrigation;

namespace Talabat.Repository.Data.DataSeed
{
    public static class StoreContextSeed 
    {

      public async static Task SeedAsync (StoreContext storeContext)
        {
            if (storeContext.productBrands.Count()==0)   // لو الداتا بيز فاضيى اعمل سييد غير كده لا يعني هعمل السييد مرة واحدة
            {
                var brandsdata = File.ReadAllText("../Talabat.Repository/Data/DataSeed/brands.json");  //بقرا الفايل الجيسون كسترينج
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata); // بحول لسي شارب على هيئة ليست علشان هو عبارة عن مجموعة من برودكت

                // deserialize (convert from json to c#) ..  serailize (convert from x# to json).



                if (brands is not null && brands.Count() > 0)  //  لو الليسته عندى مش فاضية
                {
                    foreach (var item in brands)  // ابدا ضيف كل عنصر عندى بقا
                    {
                        await storeContext.Set<ProductBrand>().AddAsync(item);
                    }
                    await storeContext.SaveChangesAsync();

                } 
            }

            if (storeContext.productCategories.Count() == 0)   // لو الداتا بيز فاضيى اعمل سييد غير كده لا يعني هعمل السييد مرة واحدة
            {
                var Categorydata = File.ReadAllText("../Talabat.Repository/Data/DataSeed/categories.json");  //بقرا الفايل الجيسون كسترينج
                var Categories = JsonSerializer.Deserialize<List<ProductCategory>>(Categorydata); // بحول لسي شارب على هيئة ليست علشان هو عبارة عن مجموعة من برودكت

                // deserialize (convert from json to c#) ..  serailize (convert from x# to json).



                if (Categories is not null && Categories.Count() > 0)  //  لو الليسته عندى مش فاضية
                {
                    foreach (var item in Categories)  // ابدا ضيف كل عنصر عندى بقا
                    {
                        await storeContext.Set<ProductCategory>().AddAsync(item);
                    }
                    await storeContext.SaveChangesAsync();

                }
            }

            if (storeContext.products.Count() == 0)
            {

                var productData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/Products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);

                if(products?.Count() > 0)
                {
                    foreach (var item in products)
                    {

                       await storeContext.Set<Product>().AddAsync(item);
                        
                    }

                    await storeContext.SaveChangesAsync();
                }


            }

            if (storeContext.DeliveryMethods.Count() == 0)
            {

                var DeliveryMethodData = File.ReadAllText("../Talabat.Repository/Data/DataSeed/delivery.json");
                var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethodData);

                if (DeliveryMethods?.Count() > 0)
                {
                    foreach (var item in DeliveryMethods)
                    {

                        await storeContext.Set<DeliveryMethod>().AddAsync(item);

                    }

                    await storeContext.SaveChangesAsync();
                }


            }


        }


    }
}
