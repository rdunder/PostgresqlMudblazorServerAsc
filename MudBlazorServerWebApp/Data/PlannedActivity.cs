using System.ComponentModel.DataAnnotations;

namespace MudBlazorServerWebApp.Data
{
    public class PlannedActivity
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string? Activity { get; set; }
    }
}
