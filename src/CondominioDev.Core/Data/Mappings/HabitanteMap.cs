using CondominioDev.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CondominioDev.Core.Data.Mappings
{
    public class HabitanteMap : IEntityTypeConfiguration<Habitante>
    {
        public void Configure(EntityTypeBuilder<Habitante> builder)
        {
            builder.ToTable("Habitantes");

            builder.HasKey(p => p.Id); //opcional

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.Sobrenome)
                .HasColumnType("varchar(100)")
                .IsUnicode(false)
                .IsRequired();
            
            builder.Property(p => p.CPF)
                .HasColumnType("varchar(14)")
                .IsUnicode(false)
                .IsRequired();

            builder.Property(p => p.DataNascimento)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(p => p.Renda)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}