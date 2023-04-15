using MarketplaceProject.Domain.ViewModels.Account;
using MarketplaceProject.Domain.Response;
using System.Security.Claims;

namespace Marketplace.Service.Interfaces
{
    public interface IAccountService
    {
        BaseResponse<ClaimsIdentity> Register(RegisterViewModel model);

        BaseResponse<ClaimsIdentity> Login(LoginViewModel model);

    }
}
