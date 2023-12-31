using Core.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    #region Propriedades da Classe
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    #endregion

    #region Construtor
    public AuthenticateService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
    {
        _signInManager = signInManager;        
        _userManager = userManager;
    }
    #endregion

    #region Metodos

    #region Authenticate
    public async Task<bool> Authenticate(string email, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
        return result.Succeeded;
    }
    #endregion

    #region RegisterUser
    public async Task<bool> RegisterUser(string email, string password)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        var result = await _userManager.CreateAsync(applicationUser, password);

        if (result.Succeeded)
            await _signInManager.SignInAsync(applicationUser, isPersistent: false);
        

        return result.Succeeded;
    }
    #endregion

    #region Logout
    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }
    #endregion

    #endregion
}
