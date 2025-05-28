using Microsoft.EntityFrameworkCore;
using Presentation.Models;

namespace Presentation.Data; 

public class ProfileContext(DbContextOptions<ProfileContext>options) : DbContext(options)
{
    public DbSet<ProfileEntity> Profiles { get; set; }
}
