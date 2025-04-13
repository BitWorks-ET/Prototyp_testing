namespace Prototype.Models.Rights;

public abstract class Rights
{
    public Rights(){}
    public bool CreateEvent { get; set; } = true;
    public bool DeleteEvent { get; set; } = true;
    public bool ManageEvent { get; set; } = true;

    public bool CreateOrganízation { get; set; } = true;
    public bool DeleteOrganízation { get; set; } = true;
    public bool ManageOrganízation { get; set; } = true;

    public bool CreateProcess { get; set; } = true;
    public bool DeleteProcess { get; set; } = true;
    public bool ManageProcess { get; set; } = true;
}