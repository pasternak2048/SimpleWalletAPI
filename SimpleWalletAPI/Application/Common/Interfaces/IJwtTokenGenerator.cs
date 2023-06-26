namespace Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string userName, string firstName, string lastName, string email, string role);
    }
}
