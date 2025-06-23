using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdmin repo;
        private readonly IMapper mapper;
        public AdminController(IAdmin repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }


        [HttpPost]
        [Route("AddRoles")]
        public IActionResult AddRoles(AddRolesDTO dto)
        {

            var data = new Role
            {
                RoleName = dto.RoleName,
            };


            if (data != null)
            {
                
                repo.AddRole(data);
                return Ok("Role Added Succesfully");
            }
            else
            {
                return NotFound("Role Not Added");
            }

           
        }


        [HttpGet("FetchingRoles")]
        public async Task<IActionResult> FetchRole()
        {
            var data = await repo.FetchRolesAsync();
            if (data != null && data.Any())
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No Roles Found");
            }
        }

        [HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await repo.DeleteRoleAsync(id);
            if (result)
            {
                return Ok("Role deleted successfully.");
            }
            else
            {
                return NotFound("Role not found.");
            }
        }



        [HttpGet("GetRole/{id}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var role = await repo.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound("Role not found.");
            }

            var roleDto = new RoleGetID
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            };

            return Ok(roleDto);
        }



        [HttpPut("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedRole = new Role
            {

                RoleId = id,
                RoleName = dto.RoleName
            };

            var result = await repo.UpdateRoleAsync(id, updatedRole);
            if (result)
            {
                return Ok("Role updated successfully.");
            }
            else
            {
                return NotFound("Role not found.");
            }
        }









        [HttpPost]
        [Route("AddBranches")]
        public IActionResult AddBranches(AddBranchesDTO dto)
        {

            var data = new Branch
            {
                BranchName = dto.BranchName,
                BranchAddress = dto.BranchAddress,
            };


            if (data != null)
            {
                repo.AddBranches(data);
                return Ok("Branch Added Succesfully");
            }
            else
            {
                return NotFound("Branch Not Added");
            }

           
        }

        [HttpGet("FetchBranches")]
        public async Task<IActionResult> FetchBranches()
        {
            var data=await repo.FetchBranchesAsync();

            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No Roles Found");
            }

        }





        [HttpDelete("DeleteBranch/{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var result = repo.DeleteBranches(id);
            if (result)
            {
                return Ok("Role deleted successfully.");
            }
            else
            {
                return NotFound("Role not found.");
            }
        }


        [HttpGet("GetBranch/{id}")]
        public async Task<IActionResult> GetBranch(int id)
        {
            var branch = await repo.GetBranchByIdAsync(id);
            if (branch == null)
                return NotFound("Branch not found.");

            var dto = new BranchGetDTO
            {
                BranchId = branch.BranchId,
                BranchName = branch.BranchName,
                BranchAddress = branch.BranchAddress
            };

            return Ok(dto);
        }

        [HttpPut("UpdateBranch/{id}")]
        public async Task<IActionResult> UpdateBranch(int id, BranchUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedBranch = new Branch
            {
                BranchName = dto.BranchName,
                BranchAddress = dto.BranchAddress
            };

            var result = await repo.UpdateBranchAsync(id, updatedBranch);
            if (result)
                return Ok("Branch updated successfully.");
            else
                return NotFound("Branch not found.");
        }
















        [HttpPost]
        [Route("AddSupplier")]
        public IActionResult AddSuppliers(AddSupplierDTO dto)
        {

            var data = new Supplier
            {
                Name = dto.Name,
                Address = dto.Address,
                Contact =dto.Contact,
                CreatedBy = dto.CreatedBy,
                CreatedAt = DateTime.Now,
                UpdatedBy= dto.UpdatedBy,
                UpdatedAt = DateTime.Now
            };


            if (data != null)
            {
                repo.AddSupplier(data);
                return Ok("Supplier Added Succesfully");
            }
            else
            {
                return NotFound("Supplier Not Added");
            }

           
        }

        [HttpGet("FetchSupplier")]
        public async Task<IActionResult> fetchsupplers()
        {
            var data = await repo.FetchSuppliersAsync();

            if (data != null)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("No Supplier Found");
            }
        }



        [HttpDelete("DeleteSuppliers/{id}")]
        public async Task<IActionResult> DeleteSuppliers(int id)
        {
            var result = await repo.DeleteSupplier(id);

            if (result)
            {
                return Ok("Supplier deleted successfully.");
            }
            else
            {
                return NotFound("Supplier not found.");
            }
        }


        [HttpGet("GetSupplier/{id}")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            var supplier = await repo.GetSupplierByIdAsync(id);
            if (supplier == null)
                return NotFound("Supplier not found.");

            var dto = new SupplierGetDTO
            {
                SupplierId = supplier.SupplierId,
                Name = supplier.Name,
                Contact = supplier.Contact,
                Address = supplier.Address
            };

            return Ok(dto);
        }

        [HttpPut("UpdateSupplier/{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedSupplier = new Supplier
            {
                Name = dto.Name,
                Contact = dto.Contact,
                Address = dto.Address,
                UpdatedBy = dto.UpdatedBy
            };

            var result = await repo.UpdateSupplierAsync(id, updatedSupplier);
            if (result)
                return Ok("Supplier updated successfully.");
            else
                return NotFound("Supplier not found.");
        }







        //[HttpGet("FetchUsers")]
        //public async Task<IActionResult> FetchUsers()
        //{
        //    var data = await repo.fetchusers();

        //    if (data != null)
        //    {
        //        return Ok(data);
        //    }
        //    else
        //    {
        //        return NotFound("No User Found");
        //    }
        //}









        [HttpPost("AddUser")]
        public IActionResult AddUser(UserCreateDTO dto)
        {
            var user = new User
            {
                Username = dto.Username,
                UserEmail = dto.UserEmail,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash),
                RoleId = dto.RoleId,
                BranchId = dto.BranchId,
                CreatedBy = dto.CreatedBy,
                CreatedDate = DateTime.Now,
                UpdatedBy = dto.UpdatedBy,
                UpdatedAt = DateTime.Now
            };
            repo.AddUser(user);
            return Ok("User added successfully");
        }

        [HttpGet("FetchUsers")]
        public async Task<IActionResult> FetchUsers()
        {
            var data = await repo.FetchUsersAsync();
            return Ok(data);
        }

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await repo.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            var dto = new UserDetailDTO
            {
                UserId = user.UserId,
                Username = user.Username,
                UserEmail = user.UserEmail,
                PasswordHash = user.PasswordHash,
                RoleId = user.RoleId,
                RoleName = user.Role.RoleName,
                BranchId = user.BranchId,
                BranchName = user.Branch.BranchName,
                CreatedBy = user.CreatedBy,
                CreatedDate = user.CreatedDate,
                UpdatedBy = user.UpdatedBy,
                UpdatedAt = user.UpdatedAt
            };
            return Ok(dto);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserCreateDTO dto)
        {
            var updated = new User
            {

                Username = dto.Username,
                UserEmail = dto.UserEmail,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash),
                RoleId = dto.RoleId,
                BranchId = dto.BranchId,
                UpdatedBy = dto.UpdatedBy,
                UpdatedAt = DateTime.Now
            };
            var result = await repo.UpdateUserAsync(id, updated);
            return result ? Ok("Updated") : NotFound();
        }








        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await repo.DeleteUserAsync(id);
            return result ? Ok("Deleted") : NotFound();
        }




        //[HttpPost("AddUser")]
        //public async Task<IActionResult> AddUser(AddUserDTOnew dto)
        //{
        //    var user = new User
        //    {
        //        Username = dto.Username,
        //        UserEmail = dto.UserEmail,
        //        PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash),
        //        RoleId = dto.RoleId,
        //        BranchId = dto.BranchId,
        //        CreatedDate = DateTime.Now,
        //        CreatedBy = dto.CreatedBy,
        //        UpdatedBy = dto.CreatedBy  
        //    };

        //    await repo.AddUserAsync(user);
        //    return Ok("User Added");
        //}


        //[HttpGet("FetchUsers")]
        //public async Task<IActionResult> FetchUsers()
        //{
        //    var data = await repo.GetAllUsersAsync();
        //    return Ok(data);
        //}

        //[HttpGet("GetUser")]
        //public async Task<IActionResult> GetUser(int id)
        //{
        //    var data = await repo.GetUserByIdAsync(id);
        //    return Ok(data);
        //}

        //[HttpPost("UpdateUser")]
        //public async Task<IActionResult> UpdateUser(UpdateUserDTOnew dto)
        //{
        //    await repo.UpdateUserAsync(dto);
        //    return Ok("User Updated");
        //}



        //[HttpDelete("DeleteUser")]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    await repo.DeleteUserAsync(id);
        //    return Ok("User Deleted");
        //}






    }
}
