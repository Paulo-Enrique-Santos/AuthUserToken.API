using HomeBrokerSimulator.Domain.Model.Entity;

namespace HomeBrokerSimulator.Domain.Interface.Authentication
{
    public interface ITokenGenerator
    {
        dynamic TokenGenerator(User user);
    }
}
