using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class Illness : IHaveId
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Treatment { get; set; } = "";
    public string Description { get; set; } = "";
}