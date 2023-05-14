namespace IndustryExperienceMain.Models;

public partial class Agency
{
    public decimal AgencyId { get; set; }

    public string AgencyName { get; set; } = null!;

    public string Link { get; set; } = null!;

    public string logo_link { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; } = new List<Job>();
}
