﻿namespace WebApplication.Models;
public class UserTokens
{
    public string Token
    {
        get;
        set;
    }
    public string UserName
    {
        get;
        set;
    }
<<<<<<< Updated upstream
    public TimeSpan Validaty
=======
    public TimeSpan Validity
>>>>>>> Stashed changes
    {
        get;
        set;
    }
    public string RefreshToken
    {
        get;
        set;
    }
    public Guid Id
    {
        get;
        set;
    }
    public string EmailId
    {
        get;
        set;
    }
    public Guid GuidId
    {
        get;
        set;
    }
    public DateTime ExpiredTime
    {
        get;
        set;
    }
}