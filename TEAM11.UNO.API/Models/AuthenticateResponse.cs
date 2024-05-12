namespace WebApi.Models;
public class AuthenticateResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(TEAM11.UNO.BL.Models.User user, string token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        UserName = user.Username; // TODO: Remember that BL.Models.User has lowercase n "Username" | The new authenticator has Uppercase N "UserName"
        Token = token;
    }
}