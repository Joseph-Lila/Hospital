using System;

namespace Coursework.BLL.DtoModels;

public class ChartDto
{
    public int ChanberNumber { get; set; }
    public string DocFIO { get; set; } = "";
    public string IllnessTitle { get; set; } = "";
    public DateTime? Start { get; set; }
    public DateTime? Finish { get; set; }
    public string Content { get; set; } = "";
}