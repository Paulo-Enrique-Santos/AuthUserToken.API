using AuthUserToken.Domain.Model.Entity;

namespace AuthUserToken.Domain.Interface.Authentication
{
    public interface ITokenGenerator
    {
        dynamic TokenGenerator(User user);
    }
}
