using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class Role : IHaveId
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Duties { get; set; } = "";
    public string Requirements { get; set; } = "";
    public string Description { get; set; } = "";
}