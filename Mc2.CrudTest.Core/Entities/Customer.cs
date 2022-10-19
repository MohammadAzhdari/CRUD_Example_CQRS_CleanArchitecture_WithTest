using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Entities
{
    public class Customer : BaseEntity
    {
        [MaxLength(50)]
        public string Firstname { get; set; }
        [MaxLength(50)]
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [MaxLength(50)]
        public string BankAccountNumber { get; set; }
    }

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(t => t.Firstname)
                    .HasColumnType("varchar(50)")
                    .IsRequired();

            builder.Property(t => t.Lastname)
                    .HasColumnType("varchar(50)")
                    .IsRequired();

            builder.Property(t => t.DateOfBirth)
                    .HasColumnType("datetime")
                    .IsRequired();

            builder.Property(t => t.PhoneNumber)
                    .HasColumnType("varchar(20)")
                    .IsRequired();

            builder.Property(t => t.Email)
                    .HasColumnType("varchar(500)");

            builder.Property(t => t.BankAccountNumber)
                    .HasColumnType("varchar(50)")
                    .IsRequired();
        }
    }
}
