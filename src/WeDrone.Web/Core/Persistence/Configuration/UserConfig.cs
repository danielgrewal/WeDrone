using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Core.Persistence.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .HasIndex(u => u.Username)
                .IsUnique();

            builder
                .Property(u => u.Password)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(u => u.Name)
                .HasMaxLength(255)
                .IsRequired();

            //INSERT INTO Users VALUES
            //    ('usman', 'password', 'Usman', 'Mahmood'),
            //    ('daniel', 'password', 'Daniel', 'Grewal'),
            //    ('adnan', 'password', 'Mohammed Adnan', 'Hashmi'),
            //    ('karanvir', 'password', 'Karanvir', 'Bhogal');
            
            builder.HasData(
                new User { UserId = 1, Username = "usman", Password = "password", Name = "Usman Mahmood" },
                new User { UserId = 2, Username = "daniel", Password = "password", Name = "Daniel Grewal" },
                new User { UserId = 3, Username = "adnan", Password = "password", Name = "Mohammed Adnan Hashmi" },
                new User { UserId = 4, Username = "karanvir", Password = "password", Name = "Karanvir Bhogal" }
            );
        }
    }
}
