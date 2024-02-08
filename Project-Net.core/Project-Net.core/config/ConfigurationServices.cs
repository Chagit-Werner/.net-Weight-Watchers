using AutoMapper;
using Weight_Watchers.core.interfaces_DAL;
using Weight_Watchers.core.interfaces_Service;
using Weight_Watchers.service.BL;
using Weight_Watchers.service.DAL;

namespace Project_Net.core.config
{
    public static class ConfigurationServices
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            //הזרקת תלויות
            services.AddScoped<IWeightWatchersRepository, WeightWatchersRepository>();
            services.AddScoped<IWeightWatcherService, WeightWatchersService>();
            //נותן את האפשרות של מיפוי
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WeightWatcherProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }


    }
}
