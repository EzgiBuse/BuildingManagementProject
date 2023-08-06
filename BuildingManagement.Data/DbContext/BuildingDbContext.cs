
using Microsoft.EntityFrameworkCore;
using BuildingManagement.Data;

namespace BuildingManagement.Data;

public class BuildingDbContext : DbContext
{
    public BuildingDbContext(DbContextOptions<BuildingDbContext> options) : base(options)
    {

    }


}
