using ECommerce.API.Application.Services;
using ECommerce.API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.API.Controllers;

public class AccountController : BaseECommerceController
{
    private readonly IAccountService _accountService;  
    public AccountController(IAccountService accountService) => 
        _accountService = accountService;

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetCurrentUser()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        return Ok(await _accountService.GetCurrentUserAsync(email));
    }

    [Authorize]
    [HttpGet("address")]
    public async Task<IActionResult> GetUserAddress()
    {
        var email = User.FindFirstValue(ClaimTypes.Email);

        return Ok(await _accountService.GetUserAddressAsync(email));
    }

    [Authorize]
    [HttpPut("address")]
    public async Task<IActionResult> UpdateUserAddress(AddressDTO addressDto)
    {
        var userEmail = User.FindFirstValue(ClaimTypes.Email);

        return Ok(await _accountService.UpdateUserAddressAsync(userEmail,addressDto));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginCredentials)
    {
        var user = await _accountService.LoginAsync(loginCredentials);

        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO registerDto)
    {
        var user = await _accountService.RegisterAsync(registerDto);

        return Ok(user);
    }

    [HttpGet("emailexists")]
    public async Task<IActionResult> CheckEmailExists([FromQuery] string email)
    {
        return Ok(await _accountService.CheckEmailExistsAsync(email));
    }
}
