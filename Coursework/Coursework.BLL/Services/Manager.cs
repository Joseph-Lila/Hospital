namespace Coursework.BLL.Services;

public class Manager
{
    public RoleManager RoleManager;
    public UserInfoManager UserInfoManager;
    public UserManager UserManager;
    public Manager(string connectionString)
    {
        RoleManager = new RoleManager(connectionString);
        UserInfoManager = new UserInfoManager(connectionString);
        UserManager = new UserManager(connectionString);
    }
}