using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Services.Role;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Exam_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController(
    IRoleService roleService,
    IValidator<CreateRoleDTO> createRoleValidator
) : ControllerBase
{
    [Authorize]
    [HttpPost]
    [Produces<OperationResultDTO>]
    public async Task<ActionResult<OperationResultDTO>> CreateRole([FromBody] CreateRoleDTO dto)
    {
        createRoleValidator.ValidateAndThrow(dto);
        var response = await roleService.CreateRole(dto.RoleName);
        return Ok(response);
    }

    [Authorize]
    [HttpGet]
    [Produces<List<ListRoleDTO>>]
    public async Task<ActionResult<List<ListRoleDTO>>> SelectRoles()
    {
        var response = await roleService.SelectRoles();
        return Ok(response);
    }
}
