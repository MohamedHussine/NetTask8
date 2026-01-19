using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configruations
{
    public class FileMetadataConfigruation : IEntityTypeConfiguration<FileMetadata>
    {
        public void Configure(EntityTypeBuilder<FileMetadata> builder)
        {
            builder.ToTable("FileMetadatas");

            // Primary Key
            builder.HasKey(f => f.ID);

            // Properties Validation
            builder.Property(f => f.FileNumber)
                .IsRequired()
                .HasMaxLength(50); 

            builder.Property(f => f.Subject)
                .IsRequired()
                .HasMaxLength(500); 

            builder.Property(f => f.ResponsibleEmployee)
                .IsRequired()
                .HasMaxLength(200);

            // Relations
            builder.HasMany(f => f.Approvals)
                .WithOne(a => a.FileMetadata)
                .HasForeignKey(a => a.FileMetadataId)
                .OnDelete(DeleteBehavior.Cascade);

            //Seeding data
            builder.HasData(
                new FileMetadata
                {
                    ID = 1,
                    FileNumber = "FILE-2024-001",
                    Subject = "طلب شراء أجهزة لابتوب للموظفين الجدد",
                    SubmitterId = 101, 
                    Status = FileStatus.Pending,
                    CreatedAt = new DateTime(2024, 5, 20),
                    CategoryId = 1,
                    ResponsibleEmployee = "أحمد علي",
                    AttachmentPath = "uploads/files/req_001.pdf"
                }
            );


        }
    }
}
