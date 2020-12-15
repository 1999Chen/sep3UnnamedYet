using tier1.Models;

namespace tier1.Data {
public interface IUserService {
    string ValidateUser(string userName, string password);
    User RegisterUser(string username, string password);
}
}