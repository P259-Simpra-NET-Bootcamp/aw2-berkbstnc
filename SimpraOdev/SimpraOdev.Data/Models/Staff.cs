using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace SimpraOdev.Data.Models
{
    [Table("Staff", Schema = "dbo")]
    public class Staff
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        [NotMapped]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique(true);
        }
    }

    public class StaffFluentValidation : AbstractValidator<Staff>
    {
        public StaffFluentValidation()
        {
            RuleFor(c => c.Email).NotEmpty().NotNull().MaximumLength(10);
            RuleFor(c => c.FirstName).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(c => c.LastName).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(c => c.Phone).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(c => c.DateOfBirth).NotEmpty().NotNull();
            RuleFor(c => c.CreatedAt).NotEmpty().NotNull();
            RuleFor(c => c.CreatedBy).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(c => c.AddressLine1).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(c => c.City).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(c => c.Country).NotEmpty().NotNull().MaximumLength(30);
            RuleFor(c => c.Province).NotEmpty().NotNull().MaximumLength(30);


        }
    }
}
