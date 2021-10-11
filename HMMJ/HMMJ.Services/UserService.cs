using HMMJ.Data;


namespace HMMJ.Services
{
    public class UserService : IUserService
    {
        private readonly IProjectRepository _repository;
        
        public UserService(IProjectRepository repository)
        {
            this._repository = repository;
        }
        public User GetUserEmail(string email)
        {
            return this._repository.GetUser(email);
        }

    }

    public interface IUserService
    {
        User GetUserEmail(string email);
    }
}
