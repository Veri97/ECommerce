using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.API.Exceptions;
using ECommerce.Core.Entities.Identity;
using ECommerce.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Application.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        ITokenService tokenService, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task<UserDTO> LoginAsync(LoginDTO loginCredentials)
    {
        var user = await _userManager.FindByEmailAsync(loginCredentials.Email);

        if (user is null)
            throw new UnauthorizedException("You are not authorized!");

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginCredentials.Password, lockoutOnFailure: false);

        if (!result.Succeeded)
            throw new UnauthorizedException("You are not authorized!");

        return new UserDTO
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.DisplayName,
        };
    }

    public async Task<UserDTO> RegisterAsync(RegisterDTO registerDto)
    {
        var user = new AppUser
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email,
            UserName = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
            throw new BadRequestException(string.Join(" | ", result.Errors.Select(x => x.Description)));

        return new UserDTO
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.DisplayName,
        };
    }

    public async Task<UserDTO> GetCurrentUserAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            throw new NotFoundException($"User '{email}' not found!");

        return new UserDTO
        {
            Email = user.Email,
            Token = _tokenService.CreateToken(user),
            DisplayName = user.DisplayName,
        };
    }

    public async Task<bool> CheckEmailExistsAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        return user is not null;
    }

    public async Task<AddressDTO> GetUserAddressAsync(string email)
    {
        var user = await _userManager.Users.Include(x => x.Address)
                                     .SingleOrDefaultAsync(x => x.Email == email);

        if (user is null)
            throw new NotFoundException($"User '{email}' not found!");

        if (user.Address is null)
            throw new NotFoundException($"Address not found for user '{email}'!");

        var addressDto = _mapper.Map<AddressDTO>(user.Address);

        return addressDto;
    }

    public async Task<AddressDTO> UpdateUserAddressAsync(string userEmail, AddressDTO addressDto)
    {
        var user = await _userManager.Users.Include(x => x.Address)
                                     .SingleOrDefaultAsync(x => x.Email == userEmail);

        if (user is null)
            throw new NotFoundException($"User '{userEmail}' not found!");

        user.Address = _mapper.Map<Address>(addressDto);

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            throw new BadRequestException("An error occurred while updating the user!");

        var updatedAddressDto = _mapper.Map<AddressDTO>(user.Address);

        return updatedAddressDto;
    }
}
