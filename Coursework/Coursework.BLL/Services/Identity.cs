namespace Coursework.BLL.Services;

public static class Identity
{
    public static string Login { get; set; } = "";
    public static bool IsAuthorized { get; set; } = false;
    public static string Role { get; set; } = "Гость";
    public static int UserId { get; set; } = 0;
}