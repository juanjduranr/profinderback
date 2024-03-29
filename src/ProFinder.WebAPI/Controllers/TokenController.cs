﻿using Microsoft.AspNetCore.Mvc;
using ProFinder.Core.Interfaces.Services;
using ProFinder.WebAPI.DTO;
using ProFinder.WebAPI.Mappers;
using Serilog;
using System;
using System.Threading.Tasks;

namespace ProFinder.WebAPI.Controllers
{
    [Route("token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthService _authService;

        public TokenController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto dto)
        {
            try
            {
                if (dto == null || string.IsNullOrEmpty(dto.Username)
                    || string.IsNullOrEmpty(dto.Password))
                    return BadRequest("All fields are required");

                var token = await _authService.GetTokenAsync(new Core.Entities.User { Name = dto.Username, Password = dto.Password });
                if (token.IsError)
                    return BadRequest("Invalid credentials");

                var tokenDto = new TokenDto();
                TokenToDtoMapper.Map(token, tokenDto);
                return Ok(tokenDto);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"unhandled exception");
                return StatusCode(500, ex); 
            }
        }
    }
}