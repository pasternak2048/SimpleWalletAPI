using WebAPI.MappingProfiles;

namespace WebAPI.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void ConfigureAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
        }
    }
}
