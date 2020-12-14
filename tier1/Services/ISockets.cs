using tier1.Models;

namespace tier1.Services
{
    public interface ISockets
    {
        void Login(string username, string password);

        string Register(string username, string password);

        string GetUser(string username);

        string Edit(string username, string password, string firstname, string lastname, string hobbies,
            byte[] profilePicture, string sex, string hometown, string description, string major, int age);


        void Logout();

        string GetFriendList(int id);
        
        string AddRequest(int otherId);
        
        string Reject( int otherId);


        
        
        
    }
}