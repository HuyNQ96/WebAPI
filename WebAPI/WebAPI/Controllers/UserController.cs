using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Repositories;

namespace WebAPI.ControllersUser
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Lấy danh sách all user
        /// </summary>
        /// <returns></returns>
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            try
            {
                var users = _userRepository.GetAllBranches().Take(20);
                return Ok(users);
            }
            catch (Exception exp)
            {
                return Ok(exp.Message);
            }
        }
    }
}