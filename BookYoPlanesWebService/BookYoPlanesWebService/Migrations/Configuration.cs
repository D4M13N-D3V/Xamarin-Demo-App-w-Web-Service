
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using BookYoPlanesWebService.Models;

internal sealed class Configuration : DbMigrationsConfiguration<BookYoPlanesWebService.Models.ApplicationDbContext>
{
    public Configuration()
    {
        AutomaticMigrationsEnabled = true;
    }

    protected override void Seed(BookYoPlanesWebService.Models.ApplicationDbContext context)
    {
        context.Planes.AddOrUpdate(new Plane()
        {
            Name = "THE ENCORE",
            Description = "The Encore delivers an excellent light jet experience, flying longer distances, carrying a larger passenger count, and efficiently getting in and out of smaller destinations. Maximize quick business trips or weekend getaways with the Encore with terrific affordability.",
            GolfSets = 2,
            Luggage = 6,
            Seats = 7,
            Pets = true,
            Wifi = true,
            ImageFile = "encorenew.png"
        });
        context.Planes.AddOrUpdate(new Plane()
        {
            Name = "CITATION EXCEL/XLS",
            Description = "The Excel/XLS is the staple of the fleet, providing ample cabin and storage space combined with excellent range. Ideal for business meetings while in the air, and leisure travel to the mountains or islands. The Excel/XLS meets the majority of most private jet travel needs.",
            GolfSets = 2,
            Luggage = 6,
            Seats = 8,
            Pets = true,
            Wifi = true,
            ImageFile = "excelxls.png"
        });
        context.Planes.AddOrUpdate(new Plane()
        {
            Name = "THE CITATION SOVEREIGN",
            Description = "The Sovereign blends comfort, style and performance with its longer cabin, expansive luggage capacity, and extended range. This aircraft is ideal for long range trips and flights to the mountains with outstanding high elevation performance. ",
            SkiSets = 4,
            Luggage = 8,
            Seats = 9,
            Pets = true,
            Wifi = true,
            ImageFile = "citationsovereign.png"
        });
        context.Planes.AddOrUpdate(new Plane()
        {
            Name = "THE CITATION X",
            Description = "The Citation X is the most versatile aircraft in the fleet with an impressive combination of range, amenities, and speed. When time and comfort are at a premium, like for longer trips from coast to coast, the Citation X is perfect with its coast-to-coast capability and spacious cabin.",
            SkiSets = 2,
            Luggage = 6,
            Seats = 8,
            Pets = true,
            Wifi = true,
            ImageFile = "citationsovereign.png"
        });
    }
}