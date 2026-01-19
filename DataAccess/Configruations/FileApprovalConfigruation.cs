using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configruations
{
    public class FileApprovalConfigruation : IEntityTypeConfiguration<FileApproval>
    {
        public void Configure(EntityTypeBuilder<FileApproval> builder)
        {
            builder.ToTable("FileApprovals");

            // Primary Key
            builder.HasKey(a => a.ID);

            // Validation Properties
            builder.Property(a => a.EmployeeName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(a => a.Order)
                .IsRequired(); 
            builder.Property(a => a.IsApproved)
                .HasDefaultValue(false); 

            //Relations
            builder.HasOne(a => a.FileMetadata)
                .WithMany(f => f.Approvals)
                .HasForeignKey(a => a.FileMetadataId)
                .OnDelete(DeleteBehavior.Cascade);

            //Seeding data
            builder.HasData(
                new FileApproval
                {
                    ID = 1,
                    FileMetadataId = 1,
                    EmployeeName = "موظف 2 (قسم الاعتماد)",
                    Order = 1,
                    IsApproved = false
                },
                new FileApproval
                {
                    ID = 2,
                    FileMetadataId = 1,
                    EmployeeName = "موظف 3 (المدير العام)",
                    Order = 2,
                    IsApproved = false
                }
            );

        }
    }
}
