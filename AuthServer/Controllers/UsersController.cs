﻿using AuthServer.Data;
using AuthServer.Dtos;
using AuthServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthServer.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser _user;
        public UsersController(IUser user)
        {
            _user = user;
        }

       
        [HttpPost]
        public async Task<ActionResult> Registration(CreateUserDto user)
        {
            try
            {
                await _user.Registration(user);
                return Ok($"Registrasi user {user.Username} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return Ok(_user.GetAllUser());
        }

        [HttpPost("Role")]
        public async Task<ActionResult> AddRole(CreateRoleDto roleDto)
        {
            try
            {
                await _user.AddRole(roleDto.RoleName);
                return Ok($"Tambah role {roleDto.RoleName} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Role")]
        public ActionResult<IEnumerable<CreateRoleDto>> GetAllRole()
        {
            return Ok(_user.GetRoles());
        }

        [HttpPost("UserInRole")]
        public async Task<ActionResult> AddUsersRole(string username, string role)
        {
            try
            {
                await _user.AddUserToRole(username, role);
                return Ok($"Update role user {username} berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("RolesByUser/{username}")]
        public async Task<ActionResult<List<string>>> GetRolesFromUser(string username)
        {
            try
            {
                var results = await _user.GetRolesFromUser(username);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("Authentication")]
        public async Task<ActionResult<User>> Authentication(CreateUserDto createUserDto)
        {
            try
            {
                var user = await _user.Authenticate(createUserDto);
                if (user == null)
                    return BadRequest("username/password tidak tepat");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
