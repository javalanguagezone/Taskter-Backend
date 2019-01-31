using Microsoft.AspNetCore.Mvc;

public class ApplicationControllerBase : ControllerBase
{
    public int UserID { get; } = 1;
}