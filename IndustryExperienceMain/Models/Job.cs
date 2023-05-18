namespace IndustryExperienceMain.Models;

public partial class Job
{
    public decimal JobId { get; set; }

    public decimal AgencyId { get; set; }

    public string TypeOfWork { get; set; } = null!;

    public string Commitment { get; set; } = null!;

    public string TimeSection { get; set; } = null!;

    public string Workplace { get; set; } = null!;

    public string Link { get; set; } = null!;
    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual Agency Agency { get; set; } = null!;
}
