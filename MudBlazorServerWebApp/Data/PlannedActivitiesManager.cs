using Microsoft.EntityFrameworkCore;

namespace MudBlazorServerWebApp.Data;

public class PlannedActivitiesManager
{
    private readonly ApplicationDbContext _context;

    public PlannedActivitiesManager(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddActivity(PlannedActivity activity)
    {
        
        _context.PlannedActivities.Add(activity);
        _context.SaveChanges();
    }

    public List<PlannedActivity> GetAllPlannedActivities()
    {
        var returnObject = _context.PlannedActivities.AsEnumerable();
        
        return returnObject.ToList();
    }
}
