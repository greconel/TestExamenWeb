using Microsoft.EntityFrameworkCore;

namespace TestExamenWeb.Models
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {

       
        }
    }
}
