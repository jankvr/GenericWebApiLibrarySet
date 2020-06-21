namespace Cz.Bkk.Generic.IdentityManagement.Interfaces
{
    public interface ICurrentlyLoggedUser
    {
        string UserName { get; }

        string Id { get; }

        string Roles { get; }
    }
}
