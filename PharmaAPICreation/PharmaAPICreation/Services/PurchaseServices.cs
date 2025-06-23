using Microsoft.EntityFrameworkCore;
using PharmaAPICreation.Data;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;

public class PurchaseServices : IPurchaseRepo
{
    private readonly ApplicationDbContext db;

    public PurchaseServices(ApplicationDbContext db)
    {
        this.db = db;
    }

    public IEnumerable<Purchase> GetAll()
    {
        return db.Purchases
            .Include(p => p.Supplier)
            .Include(p => p.Branch)
            .ToList();
    }

    public Purchase GetById(int id)
    {
        return db.Purchases
            .Include(p => p.Supplier)
            .Include(p => p.Branch)
            .FirstOrDefault(p => p.PurchaseId == id);
    }

    public void Add(Purchase purchase)
    {
        db.Purchases.Add(purchase);
        db.SaveChanges();
    }

    public void Update(Purchase purchase)
    {
        db.Purchases.Update(purchase);
        db.SaveChanges();
    }

    public void Delete(int id)
    {
        var purchase = db.Purchases.Find(id);
        if (purchase != null)
        {
            db.Purchases.Remove(purchase);
            db.SaveChanges();
        }
    }
}
