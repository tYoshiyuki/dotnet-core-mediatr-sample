namespace DotNetCoreMediatrSample.Domain.Users
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool IsDuplicated(User user)
        {
            var name = user.UserName;
            var searched = _repository.Find(name);

            return searched != null;
        }
    }
}
