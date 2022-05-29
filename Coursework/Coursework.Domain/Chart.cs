using System;
using Coursework.Domain.Interfaces;

namespace Coursework.Domain;

public class Chart : IHaveId
{
    public int Id { get; set; }
    public int ChamberId { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public int IllnessId { get; set; }
    public DateTime? Start { get; set; }
    public DateTime? Finish { get; set; }
    public string Content { get; set; } = "";
}