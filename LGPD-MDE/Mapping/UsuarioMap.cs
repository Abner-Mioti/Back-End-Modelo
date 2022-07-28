﻿
using LGPD_MDE.Entities.Generated;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LGPD.MDE.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USER");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CompanyId)
           .HasColumnType("INT")
           .HasColumnName("COMPANY_ID").IsRequired(true);

            builder.Property(x => x.AreaId)
           .HasColumnType("INT")
           .HasColumnName("AREA_ID").IsRequired(true);

            builder.Property(x => x.Name)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("NAME");

            builder.Property(x => x.Email)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("EMAIL");

            builder.Property(x => x.JobTitle)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("JOB_TITLE");

            builder.Property(x => x.Mobile)
            .HasColumnType("VARCHAR(150)")
            .HasColumnName("MOBILE");

            builder.Property(x => x.Users)
           .HasColumnType("VARCHAR(150)")
           .HasColumnName("USER");

            builder.Property(x => x.Password)
           .HasColumnType("VARCHAR(60)")
           .HasColumnName("PASSWORD");

            builder.Property(x => x.IsActive)
           .HasColumnType("BIT")
           .HasColumnName("IS_ACTIVE");

        }
    }
}
