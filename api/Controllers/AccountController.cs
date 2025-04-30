namespace api.Controllers;

public class AccountController(IAccountRepository accountRepository) : BaseApiController
{
    [HttpPost("create")]
    public async Task<ActionResult<LoggedInDto>> Create(AppUser userInput, CancellationToken cancellationToken)
    {
        if (userInput.Password != userInput.ConfirmPassword)
            return BadRequest("Your passwords do not match!");

        LoggedInDto? loggedInDto = await accountRepository.CreateAsync(userInput, cancellationToken);

        if (loggedInDto is null)
            return BadRequest("This email is already taken.");

        return Ok(loggedInDto);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoggedInDto>> Login(LoginDto userInput, CancellationToken cancellationToken)
    {
        LoggedInDto? loggedInDto = await accountRepository.LoginAsync(userInput, cancellationToken);

        if (loggedInDto is null)
            return BadRequest("Email or Password is wrong");

        return loggedInDto;
    }

    [HttpDelete("delete/{userId}")]
    public async Task<ActionResult<DeleteResult>> DeleteById(string userId, CancellationToken cancellationToken)
    {
        DeleteResult? deleteResult = await accountRepository.DeleteByIdAsync(userId, cancellationToken);

        if (deleteResult is null)
            return BadRequest("Operation failed");

        return deleteResult;
    }
}