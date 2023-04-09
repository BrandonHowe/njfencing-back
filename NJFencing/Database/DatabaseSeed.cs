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

            if (!db.DualMeets.Any() && !db.Fencers.Any())
            {
                #region Fencers
                var me =         new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mhmens, FirstName = "Brandon", LastName = "Howe", GradYear = 2024 };
                var moses =      new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mhmens, FirstName = "Moses", LastName = "Yang", GradYear = 2023 };
                var joel =       new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mhmens, FirstName = "Joel", LastName = "Varghese", GradYear = 2025 };
                var adham =      new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mhmens, FirstName = "Adham", LastName = "Ibrahim", GradYear = 2023 };
                var josh =       new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mhmens, FirstName = "Joshua", LastName = "Grater", GradYear = 2023 };
                var harry =      new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mhmens, FirstName = "Harry", LastName = "Tomasco", GradYear = 2024 };
                var trudnos =    new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mc, FirstName = "Allen", LastName = "Trudnos", GradYear = 2023 };
                var dwyer =      new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mc, FirstName = "James", LastName = "Dwyer", GradYear = 2023 };
                var forrester =  new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mc, FirstName = "Michael", LastName = "Forrester", GradYear = 2024 };
                var concha =     new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mc, FirstName = "Roman", LastName = "Concha", GradYear = 2024 };
                var demarco =    new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mc, FirstName = "Dominick", LastName = "DeMarco", GradYear = 2023 };
                var ross =       new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mc, FirstName = "Peter", LastName = "Ross", GradYear = 2024 };
                var nicotra =    new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mc, FirstName = "Nicotra", LastName = "Nicotra", GradYear = 2023 };
                var kellish =    new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mc, FirstName = "Matthew", LastName = "Kellish", GradYear = 2023 };
                var richardson = new Fencer { Id = Nanoid.Nanoid.Generate(), Team = mc, FirstName = "Ethan", LastName = "Richardson", GradYear = 2023 };
                db.Fencers.Add(me);
                db.Fencers.Add(moses);
                db.Fencers.Add(joel);
                db.Fencers.Add(adham);
                db.Fencers.Add(josh);
                db.Fencers.Add(harry);
                db.Fencers.Add(trudnos);
                db.Fencers.Add(dwyer);
                db.Fencers.Add(forrester);
                db.Fencers.Add(concha);
                db.Fencers.Add(demarco);
                db.Fencers.Add(ross);
                db.Fencers.Add(nicotra);
                db.Fencers.Add(kellish);
                db.Fencers.Add(richardson);
                #endregion
                
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

                if (!db.FencerRecords.Any())
                {
                    var myRecord =        new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Sabre, Wins = 2, Losses = 1, Fencer = me };
                    var mosesRecord =     new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Sabre, Wins = 2, Losses = 1, Fencer = moses };
                    var joelRecord =      new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Sabre, Wins = 1, Losses = 2, Fencer = joel };
                    var adhamRecord =     new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Foil, Wins = 2, Losses = 0, Fencer = adham };
                    var joshRecord =      new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Foil, Wins = 1, Losses = 1, Fencer = josh };
                    var harryRecord =     new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Foil, Wins = 2, Losses = 0, Fencer = harry };
                    var trudnosRecord =   new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Sabre, Wins = 3, Losses = 0, Fencer = trudnos };
                    var dwyerRecord =     new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Sabre, Wins = 1, Losses = 2, Fencer = dwyer };
                    var forresterRecord = new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Sabre, Wins = 0, Losses = 3, Fencer = forrester };
                    var conchaRecord =    new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Foil, Wins = 2, Losses = 1, Fencer = concha };
                    var demarcoRecord =   new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Foil, Wins = 0, Losses = 3, Fencer = demarco };
                    var rossRecord =      new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Foil, Wins = 0, Losses = 2, Fencer = ross };
                    var nicotraRecord =   new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Epee, Wins = 3, Losses = 0, Fencer = nicotra };
                    var kellishRecord =   new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Epee, Wins = 3, Losses = 0, Fencer = kellish };
                    var richardRecord =   new FencerRecord { Id = Nanoid.Nanoid.Generate(), Meet = dualMeet, Weapon = Weapon.Epee, Wins = 3, Losses = 0, Fencer = richardson };
                    db.FencerRecords.Add(myRecord);
                    db.FencerRecords.Add(mosesRecord);
                    db.FencerRecords.Add(joelRecord);
                    db.FencerRecords.Add(adhamRecord);
                    db.FencerRecords.Add(joshRecord);
                    db.FencerRecords.Add(harryRecord);
                    db.FencerRecords.Add(trudnosRecord);
                    db.FencerRecords.Add(dwyerRecord);
                    db.FencerRecords.Add(forresterRecord);
                    db.FencerRecords.Add(conchaRecord);
                    db.FencerRecords.Add(demarcoRecord);
                    db.FencerRecords.Add(rossRecord);
                    db.FencerRecords.Add(nicotraRecord);
                    db.FencerRecords.Add(kellishRecord);
                    db.FencerRecords.Add(richardRecord);
                }
            }
        }

        db.SaveChanges();
    }
}