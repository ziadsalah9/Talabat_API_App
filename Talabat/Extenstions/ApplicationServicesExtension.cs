using Microsoft.AspNetCore.Mvc;
using Talabat.Core.IRepositories;
using Talabat.Error;
using Talabat.Helper;
using Talabat.Repository;

namespace Talabat.Extenstions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {




            #region resolve Dependancies
            //services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MappingProfile));
            //  builder.Services.AddAutoMapper(p => p.AddProfile(new MappingProfile() )) ;
            //  


            #endregion
            #region Validation error


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actioncontext) =>
                {
                    var errors = actioncontext.ModelState.Where(p => p.Value.Errors.Count() > 0).SelectMany(p => p.Value.Errors)
                     .Select(p => p.ErrorMessage).ToArray();


                    var ValidationResponseErrors = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };



                    return new BadRequestObjectResult(ValidationResponseErrors);

                };
            });
            #endregion


            return services;
        }


    }
}
