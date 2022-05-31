using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class User : IHaveId
{
    public int Id { get; set; } = 0;
    public int UserInfoId { get; set; }
    public int RoleId { get; set; }
    public string Login { get; set; } = "";
    public string Password { get; set; } = "";
}