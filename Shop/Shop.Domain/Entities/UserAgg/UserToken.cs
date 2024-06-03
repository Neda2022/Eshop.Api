

using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.Entities.UserAgg;

    public class UserToken:BaseEntity
    {
    private UserToken()
    {

    }
    public UserToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
    {
        Guard(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
        HashJwtToken = hashJwtToken;
        HashRefreshToken = hashRefreshToken;
        TokenExpireDate = tokenExpireDate;
        RefreshTokenExpireDate = refreshTokenExpireDate;
        Device = device;
    }
    public long UserId { get; set; }
    public string HashJwtToken { get;  }
    public string HashRefreshToken { get;  }
    public DateTime TokenExpireDate { get;}
    public DateTime RefreshTokenExpireDate { get;}
    public string Device { get;  }



    public void Guard(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
    {
        NullOrEmtyDomainDataException.CheckString(hashJwtToken, nameof(HashJwtToken));
        NullOrEmtyDomainDataException.CheckString(hashRefreshToken, nameof(HashRefreshToken));

        if (tokenExpireDate < DateTime.Now)
            throw new InvalidDomainDataException("Invalid Token ExpireDate");

        if (refreshTokenExpireDate < tokenExpireDate)
            throw new InvalidDomainDataException("Invalid RefreshToken ExpireDate");
    }
}

