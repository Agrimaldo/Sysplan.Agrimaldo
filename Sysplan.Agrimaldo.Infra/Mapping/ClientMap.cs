
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sysplan.Agrimaldo.Domain.Entities;

namespace Sysplan.Agrimaldo.Infra.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("CLIENTE");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(e => e.Name).HasColumnName("Nome").HasMaxLength(100);
            builder.Property(e => e.Age).HasColumnName("Idade");
        }
    }
}
