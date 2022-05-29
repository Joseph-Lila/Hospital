using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class UserInfo : IHaveId
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? Surname { get; set; }
    public string? PassportData { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? HomeNumber { get; set; }
    public string? FlatNumber { get; set; }
    public string? Sex { get; set; }
    public int? Experience { get; set; }
    public double? Salary { get; set; }
}