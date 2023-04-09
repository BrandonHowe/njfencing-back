using NJFencing.Models;
using NJFencing.Utilities;

namespace NJFencing.Database;

public class DatabaseSeed
{
    private readonly DatabaseContext db;

    public DatabaseSeed(DatabaseContext db)
    {
        this.db = db;
    }

    public void Seed()
    {
        if (!db.Accounts.Any())
        {
            var myAcc = new Account
            {
                Id = Nanoid.Nanoid.Generate(),
                CreatedAt = DateTime.UtcNow,
                Email = "swag@money.com"
            };

            db.Accounts.Add(myAcc); 
        }

        if (!db.Teams.Any())
        {
            var mhmens = new Team
            {
                Id = Nanoid.Nanoid.Generate(),
                Abbreviation = "MH",
                Conference = Conference.Northwest,
                Coach = "Lisa Campi-Sapery",
                Icon = "https://nj.vsand-static.com/Logos/3954.png",
                Name = "Morris Hills",
                Town = "Rockaway",
                Mascot = "Scarlet Knights",
                Gender = Gender.Mens
            };
            
            var mhwomens = new Team
            {
                Id = Nanoid.Nanoid.Generate(),
                Abbreviation = "MH",
                Conference = Conference.Northwest,
                Coach = "John Nugent",
                Icon = "https://nj.vsand-static.com/Logos/3954.png",
                Name = "Morris Hills",
                Town = "Rockaway",
                Mascot = "Scarlet Knights",
                Gender = Gender.Womens
            };

            var mc = new Team
            {
                Id = Nanoid.Nanoid.Generate(),
                Abbreviation = "MC",
                Conference = Conference.Northwest,
                Coach = "Michael Malecki",
                Icon = "https://nj.vsand-static.com/Logos/5829.png",
                Name = "Morris Catholic",
                Town = "Denville",
                Mascot = "Crusaders",
                Gender = Gender.Mens
            };

            db.Teams.Add(mhmens);
            db.Teams.Add(mhwomens);
            db.Teams.Add(mc);

            if (!db.DualMeets.Any())
            {
                var dualMeet = new DualMeet
                {
                    Id = Nanoid.Nanoid.Generate(),
                    Conference = true,
                    Team1 = mhmens,
                    Team2 = mc,
                    Date = DateTime.UtcNow,
                    Team1Score1 = 4,
                    Team2Score1 = 5,
                    Team1Score2 = 4,
                    Team2Score2 = 5,
                    Team1Score3 = 3,
                    Team2Score3 = 6,
                    Team1Score = 11,
                    Team2Score = 16,
                    Records = new List<FencerRecord>()
                };

                db.DualMeets.Add(dualMeet);
            }
        }

        db.SaveChanges();
    }
}