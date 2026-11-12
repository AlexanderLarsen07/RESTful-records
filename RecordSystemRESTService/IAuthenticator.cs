namespace RecordSystemRESTService
{
    public enum Role
    {
        user, admin
    }
    public interface IAuthenticator
    {
        Role? Authenticate(string username, string password);
    }
}
