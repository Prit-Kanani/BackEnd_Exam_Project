using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Services.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Exam_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController(
    IRoleService roleService
) : ControllerBase
{
    [Authorize]
    [HttpPost]
    [Produces<OperationResultDTO>]
    public async Task<ActionResult<OperationResultDTO>> CreateRole([FromBody] string RoleName)
    {
        var response = await roleService.CreateRole(RoleName);
        return Ok(response);
    }
}
