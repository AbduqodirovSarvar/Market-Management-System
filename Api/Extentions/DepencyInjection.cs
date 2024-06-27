using Application.Extentions;

namespace Api.Extentions
{
    public static class DepencyInjection
    {
        public static IServiceCollection AddApplicationApi(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
