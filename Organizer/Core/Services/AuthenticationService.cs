using AutoMapper;
using Core.Constants;
using Core.DTOs.Authentication;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Core.Extensions;
using Core.Interfaces;

namespace Core.Services
{
    public class AuthenticationService
         : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(
            IMapper mapper,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task RegisterAsync(
            RegistrationDTO userData, string callbackUrl)
        {
            var user = _mapper.Map<User>(userData);
            var createUserResult = await _userManager.CreateAsync(user, userData.Password);

            createUserResult.NullCheck();

            var roleName = IdentityRoleNames.Client.ToString();
            var userRole = await _roleManager.FindByNameAsync(roleName);

            userRole.NullCheck();

            var addToRoleResult = await _userManager.AddToRoleAsync(user, userRole.Name);

            addToRoleResult.NullCheck();
        }
    }
}
