namespace HRSystem.Server.Entities.Exceptions
{
    public class RefreshTokenBadRequest : BadHttpRequestException
    {
        public RefreshTokenBadRequest()
            : base("Invalid client request. The tokenDto has some invalid values.")
        { }
    }
}
