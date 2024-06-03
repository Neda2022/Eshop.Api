
using Common.Application;

namespace Shop.Application.Users.AddToken;

public class AddUserTokenCommand:IBaseCommand
    {
    public AddUserTokenCommand(
        long userId,
        string hashJwtToken,
        string hashRefreshToken, 
        DateTime tokenExpiredDate,
        DateTime refreshTokenExpiredDate, 
        string device)
    {
        UserId = userId;
        HashJwtToken = hashJwtToken;
        HashRefreshToken = hashRefreshToken;
        TokenExpiredDate = tokenExpiredDate;
        RefreshTokenExpiredDate = refreshTokenExpiredDate;
        Device = device;
    }

    public long UserId { get; }
    public string HashJwtToken { get; }
    public string HashRefreshToken { get;  }
    public DateTime TokenExpiredDate { get;}
    public DateTime RefreshTokenExpiredDate { get; }
    public string Device { get; }
}

