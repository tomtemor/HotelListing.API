﻿using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace HotelListing.API.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;

        public AuthManager(IMapper mapper, UserManager<ApiUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> Login(LoginDto loginDto)
        {
            bool isValidUser = false;
            try
            {
                var user = await _userManager.FindByEmailAsync(loginDto.Email);
                if (user == null) return default;
                bool isValidCredential = await _userManager.CheckPasswordAsync(user, loginDto.Password);
                if (!isValidCredential)
                {
                    return default;
                }
            }
            catch (Exception)
            {
            }
            return isValidUser;

        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto apiUserDto)
        {
            var user = _mapper.Map<ApiUser>(apiUserDto);
            user.UserName = apiUserDto.Email;

            var result = await _userManager.CreateAsync(user, apiUserDto.Password);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, "User");

            return result.Errors;
        }
    }
}
