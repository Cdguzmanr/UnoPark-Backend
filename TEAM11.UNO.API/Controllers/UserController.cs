using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TEAM11.UNO.BL.Models;
using TEAM11.UNO.BL;
using TEAM11.UNO.PL.Data;
using WebApi.Models;
using WebApi.Services;
using WebApi.Helpers;
using Microsoft.AspNetCore.Identity;

namespace TEAM11.UNO.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    private readonly DbContextOptions<UNOEntities> options;
    private readonly ILogger<UserController> logger;

    public UserController(ILogger<UserController> logger, DbContextOptions<UNOEntities> options)
    {
        this.options = options;
        this.logger = logger;
        logger.LogWarning("User Controller Check");
    }


    // ------------

    private IUserService _userService;


/*    public UserController(IUserService userService, 
                          ILogger<UserController> logger, 
                          DbContextOptions<UNOEntities> options)
    {
        this._userService = userService;
        this.options = options;
        this.logger = logger;
        logger.LogWarning("User Controller Check");
    }*/
/*
    [HttpPost("login")]
    public IActionResult Login(User model)
    {
        try
        {
            var response = new UserManager(options).Login(model);

            if (response == null)
            {
                logger.LogWarning("Authentication unsuccessful for {UserId}", model.Username);
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            logger.LogWarning("Authentication successful for {UserId}", model.Username);
            return Ok(response);
        }
        catch (Exception ex)
        {

            logger.LogWarning("Authentication unsuccessful for {UserId}:{1}", model.Username, ex.Message);
            return BadRequest(new { message = ex.Message });
        }
    }*/

    [HttpPost("login")]
    public IActionResult Login(UserLoginDto userDto)
    {
        try
        {
            bool isLoggedIn = new UserManager(options).Login(userDto.Username, userDto.Password);
            if (isLoggedIn)
            {
                return Ok(new { Message = "Login successful" });
            }
            else
            {
                return Unauthorized(new { Error = "Invalid username or password" });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }







    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
        {
            logger.LogWarning("Authentication unsuccessful for {UserId}", model.Username);
            return BadRequest(new { message = "Username or password is incorrect" });
        }
        logger.LogWarning("Authentication successful for {UserId}", model.Username);
        return Ok(response);
    }

    [Authorize]
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }



    // ----------------------

    [HttpGet]
    public IEnumerable<User> Get()
    {
        try
        {
            return new UserManager(options).Load();
        }
        catch (Exception ex)
        {
            StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            throw;
        }
    }

    [HttpGet("{id}")]
    public User Get(Guid id)
    {
        try
        {
            return new UserManager(options).LoadById(id);
        }
        catch (Exception ex)
        {
            StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            throw;
        }

    }

    [HttpPost("{rollback?}")]
    public int Post([FromBody] User user, bool rollback = false)
    {
        try
        {
            return new UserManager(options).Insert(user, rollback);
        }
        catch (Exception ex)
        {
            StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            throw;
        }
    }

    [HttpPut("{id}/{rollback?}")]
    public int Put(Guid id, [FromBody] User user, bool rollback = false)
    {
        try
        {
            return new UserManager(options).Update(user, rollback);
        }
        catch (Exception ex)
        {
            StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            throw;
        }
    }

    [HttpDelete("{id}/{rollback?}")]
    public int Delete(Guid id, bool rollback = false)
    {
        try
        {
            return new UserManager(options).Delete(id, rollback);
        }
        catch (Exception ex)
        {
            StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            throw;
        }
    }

}

