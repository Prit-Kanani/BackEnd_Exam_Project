using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Services.User;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Exam_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles="Manager")]
public class UserController(
    IUserService userService,
    IValidator<CreateUserDTO> createUserValidator
) : ControllerBase
{
    [HttpPost]
    [Produces<OperationResultDTO>]
    public async Task<IActionResult> CreateUser(CreateUserDTO dto)
    {
        createUserValidator.ValidateAndThrow(dto);
        var response = await userService.CreateUser(dto);
        return Ok(response);
    }

    [HttpGet]
    [Produces<List<ListUsersDTO>>]
    public async Task<IActionResult> SelectUsers([FromQuery] int skip, [FromQuery] int take)
    {
        var response = await userService.SelectUsers(skip,take);
        return Ok(response);
    }
}
