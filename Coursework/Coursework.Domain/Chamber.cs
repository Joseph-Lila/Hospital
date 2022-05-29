using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class Chamber : IHaveId
{
    public int Id { get; set; }
    public int ChamberNumber { get; set; }
    public int HospitalNumber { get; set; }
    public string Department { get; set; } = "";
    public bool IsFree { get; set; }
}