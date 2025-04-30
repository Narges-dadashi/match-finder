namespace api.Controllers;

public class MemberController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<MemberDto>>> GetAll(CancellationToken cancellationToken)
    {
        List<AppUser>? appUsers = await userRepository.GetAllAsync(cancellationToken);

        if (appUsers is null)
            return NoContent();

        List<MemberDto> memberDtos = [];

        foreach (AppUser user in appUsers)
        {
            MemberDto memberDto = new(
                Email: user.Email,
                UserName: user.UserName,
                Age: user.Age,
                City: user.City,
                Country: user.Country
            );

            memberDtos.Add(memberDto);
        }

        return memberDtos;
    }
}