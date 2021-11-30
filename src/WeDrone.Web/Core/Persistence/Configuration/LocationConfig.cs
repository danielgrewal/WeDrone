using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeDrone.Web.Core.Domain;

namespace WeDrone.Web.Core.Persistence.Configuration
{
    public class LocationConfig : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .Property(l => l.Name)
                .HasMaxLength(255);

            builder
                .Property(l => l.Latitude)
                .HasColumnType("decimal(17,14)");

            builder
                .Property(l => l.Longitude)
                .HasColumnType("decimal(17,14)");

            builder
                .Property(l => l.Address)
                .HasMaxLength(255);

            builder
                .HasIndex(l => l.Address)
                .IsUnique();


            builder.HasData(
                new Location 
                { 
                    LocationId = 1, 
                    Name = "Toronto Pearson International Airport",
                    Latitude = 43.68232877980147M,
                    Longitude = -79.62661047567958M,
                    Address = "6301 Silver Dart Dr, Mississauga, ON L5P 1B2",
                    IsDroneFacility = true
                },
                new Location
                {
                    LocationId = 2,
                    Name = "Square One Shopping Centre",
                    Latitude = 43.5932704575367M,
                    Longitude = -79.6418354765629M,
                    Address = "100 City Centre Dr, Mississauga, ON L5B 2C9",
                    IsDroneFacility = true
                },
                new Location
                {
                    LocationId = 3,
                    Name = "Vaughan Mills Mall",
                    Latitude = 43.82549302652521M,
                    Longitude = -79.5381447146669M,
                    Address = "1 Bass Pro Mills Dr, Vaughan, ON L4K 5W4",
                    IsDroneFacility = true
                },
                new Location
                {
                    LocationId = 4,
                    Name = "CN Tower",
                    Latitude = 43.64272145936629M,
                    Longitude = -79.38704607234244M,
                    Address = "290 Bremner Blvd, Toronto, ON M5V 3L9",
                    IsDroneFacility = true
                },
                new Location
                {
                    LocationId = 5,
                    Name = "Ontario Science Centre",
                    Latitude = 43.71718851953277M,
                    Longitude = -79.33851344772478M,
                    Address = "770 Don Mills Rd., North York, ON M3C 1T3",
                    IsDroneFacility = true
                },
                new Location
                {
                    LocationId = 6,
                    Name = "Toronto Zoo",
                    Latitude = 43.82096417612802M,
                    Longitude = -79.1812287514316M,
                    Address = "2000 Meadowvale Rd, Toronto, ON M1B 5K7",
                    IsDroneFacility = true
                },
                new Location
                {
                    LocationId = 7,
                    Name = "Ontario Technology University",
                    Latitude = 43.94565647325994M,
                    Longitude = -78.89679613001036M,
                    Address = "2000 Simcoe St N, Oshawa, ON L1G 0C5",
                    IsDroneFacility = true
                }
                //new Location
                //{
                //    LocationId = 8,
                //    Name = "Lowes Brampton",
                //    Latitude = 43.6783549M,
                //    Longitude = -79.7233365M,
                //    Address = "370 Kennedy Rd S, Brampton, ON L6W 4V2",
                //    IsDroneFacility = false
                //},
                //new Location
                //{
                //    LocationId = 9,
                //    Name = "Lowes Whitby",
                //    Latitude = 43.9259581M,
                //    Longitude = -78.9186847M,
                //    Address = "4005 Garrard Rd, Whitby, ON L1R 0J1",
                //    IsDroneFacility = false
                //}
            );

        }
    }
}
