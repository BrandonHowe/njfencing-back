using NJFencing.Models;

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
        if (db.Accounts.Any()) return;

        var myAcc = new Account
        {
            Id = Nanoid.Nanoid.Generate(),
            CreatedAt = DateTime.UtcNow,
            Email = "swag@money.com"
        };

        db.Accounts.Add(myAcc);
        db.SaveChanges();
    }
}