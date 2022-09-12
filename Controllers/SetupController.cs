using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using library_management_system.Data;

namespace library_management_system.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SetupController : ControllerBase
{
    private readonly DataContext _context;

    public SetupController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("initializeDB")]
    public void InitializeDB() 
    {
        DbInitializer.Initialize(_context);
    }

    
}
