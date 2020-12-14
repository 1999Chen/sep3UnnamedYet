using tier1.Models;

namespace tier1.Data {
public interface IUserService {
    User ValidateUser(string userName, string password);
}
}