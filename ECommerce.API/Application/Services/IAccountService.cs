using ECommerce.API.DTOs;

namespace ECommerce.API.Application.Services;

public interface IAccountService
{
    Task<UserDTO> LoginAsync(LoginDTO loginCredentials);
    Task<UserDTO> RegisterAsync(RegisterDTO registerDto);
    Task<UserDTO> GetCurrentUserAsync(string email);
    Task<AddressDTO> GetUserAddressAsync(string email);
    Task<AddressDTO> UpdateUserAddressAsync(string userEmail, AddressDTO addressDto);
    Task<bool> CheckEmailExistsAsync(string email);
}
