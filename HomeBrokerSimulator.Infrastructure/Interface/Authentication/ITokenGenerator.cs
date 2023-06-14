using HomeBrokerSimulator.Domain.Model.Entity;

namespace HomeBrokerSimulator.Infrastructure.Interface.Authentication
{
    public interface ITokenGenerator
    {
        dynamic TokenGenerator(User user);
    }
}
