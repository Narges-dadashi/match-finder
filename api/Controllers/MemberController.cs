namespace api.Controllers;

[Authorize]
public class MemberController(IMemberRepository memberRepository) : BaseApiController
{
    [HttpGet("get-all")]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetAll(CancellationToken cancellationToken)
    {
        var userId = User.GetUserId();

        if (userId is null)
            return Unauthorized("You are not logged in. Please login again");

        IEnumerable<AppUser>? appUsers = await memberRepository.GetAllAsync(cancellationToken);

        if (appUsers is null)
            return NoContent();

        List<MemberDto> memberDtos = [];

        foreach (AppUser user in appUsers)
        {
            // MemberDto memberDto = new(
            //     Email: user.Email,
            //     UserName: user.UserName,
            //     Age: user.Age,
            //     City: user.City,
            //     Country: user.Country
            // );

            MemberDto memberDto = Mappers.ConvertAppUserToMemberDto(user);

            memberDtos.Add(memberDto);
        }

        return memberDtos;
    }

    public async Task<ActionResult<MemberDto?>> GetByUserName(string userName, CancellationToken cancellationToken)
    {
        MemberDto? memberDto = await memberRepository.GetByUserNameAsync(userName, cancellationToken);

        if (memberDto is null)
            return BadRequest("User not found");

        return memberDto;
    }
}