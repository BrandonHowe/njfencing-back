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
            var mh = new Team
            {
                Id = Nanoid.Nanoid.Generate(),
                Abbreviation = "MH",
                Conference = Conference.Northwest,
                Coach = "Lisa Campi-Sapery",
                Icon = "https://nj.vsand-static.com/Logos/3954.png",
                Name = "Morris Hills"
            };

            var mc = new Team
            {
                Id = Nanoid.Nanoid.Generate(),
                Abbreviation = "MC",
                Conference = Conference.Northwest,
                Coach = "Michael Malecki",
                Icon = "https://nj.vsand-static.com/Logos/5829.png",
                Name = "Morris Catholic"
            };

            db.Teams.Add(mh);
            db.Teams.Add(mc);

            if (!db.DualMeets.Any())
            {
                var dualMeet = new DualMeet
                {
                    Id = Nanoid.Nanoid.Generate(),
                    Conference = true,
                    Team1 = mh,
                    Team2 = mc,
                    Date = DateTime.UtcNow,
                    Team1Score1 = 4,
                    Team2Score1 = 5,
                    Team1Score2 = 4,
                    Team2Score2 = 5,
                    Team1Score3 = 3,
                    Team2Score3 = 6,
                    Records = new List<FencerRecord>()
                };

                db.DualMeets.Add(dualMeet);
            }
        }

        db.SaveChanges();
    }
}