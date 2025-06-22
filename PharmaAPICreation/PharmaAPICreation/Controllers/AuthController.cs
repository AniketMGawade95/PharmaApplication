using AutoMapper;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;
using PharmaAPICreation.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthorization repo;
        public IMapper mapper;
        IConfiguration con;
        public AuthController(IAuthorization repo, IMapper mapper, IConfiguration con)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.con = con;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginDTO dto)
        {
            var user = repo.AuthenticateUser(dto.Username, dto.Password);

            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }


            var response = new LoginResponseDTO
            {
                UserId=user.UserId,
               Username=user.Username,
                RoleName= user.Role.RoleName,
                BranchId= user.BranchId,
                UserEmail = user.UserEmail,
                PasswordHash=user.PasswordHash, 
                CreatedBy=user.CreatedBy,
                CreatedDate=user.CreatedDate,
                UpdatedBy=user.UpdatedBy,
                UpdatedAt=user.UpdatedAt
                
            };

            //var userDto = mapper.Map<LoginResponseDTO>(user);

            return Ok(response);
        }





        [HttpGet]
        [Route("FetchBranch")]
        public IActionResult FindAllBranches()
        {
            var data = repo.fetchbranch();
            return Ok(data);
        }


        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(AddUserDTO dtoo)
        {
            var data = new User()
            {
                Username = dtoo.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dtoo.PasswordHash),
                UserEmail=dtoo.UserEmail,
                RoleId = 2,
                CreatedDate = DateTime.Now,
                CreatedBy="System",
                UpdatedBy="System",
                UpdatedAt=DateTime.Now,
                BranchId= dtoo.BranchId
            };

            if (data != null)
            {
                repo.AddUser(data);
                return Ok("User Added Succesfully");
            }
            else
            {
                return NotFound("User Not Added");
            }

        }



    }
}
