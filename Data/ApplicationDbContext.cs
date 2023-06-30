using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrimerParcial.Models;

namespace Proyecto_PrimerParcial.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Proyecto_PrimerParcial.Models.Aeronave> Aeronave { get; set; } = default!;
    public DbSet<Proyecto_PrimerParcial.Models.Instructor> Instructor { get; set; } = default!;
    public DbSet<Proyecto_PrimerParcial.Models.Hangar> Hangar { get; set; } = default!;
    public DbSet<Proyecto_PrimerParcial.Models.Pista> Pista { get; set; } = default!;
}
