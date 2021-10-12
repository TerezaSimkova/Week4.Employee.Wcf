using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week4.Library.Core.Models;

namespace Week4.Library.EF.Repositories
{
    internal class PrestitoConfiguration : IEntityTypeConfiguration<Prestito>
    {
        public void Configure(EntityTypeBuilder<Prestito> modelBuilder)
        {
            modelBuilder.ToTable("Prestito");
        }
    }
}