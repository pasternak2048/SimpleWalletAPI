using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Persistence.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid? UserId =>
            Guid.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirstValue("Id"),
                out var result)
                ? result
                : default(Guid?);
    }
}
