using WCF_TaskOrganizer;

namespace TaskOrganizer
{
    static class ClassUser
    {
        static public bool ConfirmUser(User user)
        {
            return Database.ConfirmUser(user);
        }

        static public bool RegistrationUser(User user)
        {
            return Database.AddUser(user);
        }
    }
}
