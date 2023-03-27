using AutoMapper;
using BlogEngine.Repository.Contracts;
using BlogEngine.Services.Contracts;
using BlogEngine.Utilities.Entities;
using BlogEngine.Utilities.Helpers;
using BlogEngine.Utilities.PayLoad;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogEngine.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettingsDTO _appSettings;
        private readonly IMapper _mapper;

        public UserService (IUserRepository userRepository, IOptions<AppSettingsDTO> appSettings, IMapper mapper)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public async Task<UserDTO> ValidateUser(UserPayLoad userPayLoad)
        {
            try
            {
                var user = await ValidateUserDB(userPayLoad);

                if (user == null) { return null; }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.SecureKey);
                var expriringTime = _appSettings.ExpireTime;

                user.ExpiresIn = double.Parse(expriringTime.ToString());

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Email, user.Email)
                    }),
                    Expires = DateTime.UtcNow.AddSeconds(user.ExpiresIn),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> ValidateUserProfile(User user)
        {
            return await _userRepository.ValidateUserProfile(user);
        }

        private async Task<UserDTO> ValidateUserDB(UserPayLoad userPayLoad)
        {
            var user = await _userRepository.ValidateUser(userPayLoad);
            if (user == null) { return null; }
            var result = _mapper.Map<UserDTO>(user);
            return result;
        }
    }
}
