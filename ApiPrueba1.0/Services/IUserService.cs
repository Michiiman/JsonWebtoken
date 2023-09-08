using ApiPrueba1._0.Dtos;

namespace ApiPrueba1._0.Services;

    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDto model);
        Task<DataUserDto> GetTokenAsync(LoginDto model);
        Task<string> AddRoleAsync(AddRoleDto model);
        
    }
