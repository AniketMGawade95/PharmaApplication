using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmaAPICreation.Data;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Models;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Services
{
    public class PurchaseItemService : IPurchaseItemRepo
    {
        private readonly ApplicationDbContext db;

        public PurchaseItemService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PurchaseItem> GetAll()
        {
            return db.PurchaseItems
                     .Include(p => p.Medicine)
                     .Include(p => p.Purchase)
                     .ToList();
        }

        public PurchaseItem GetById(int id)
        {
            return db.PurchaseItems
                     .Include(p => p.Medicine)
                     .Include(p => p.Purchase)
                     .FirstOrDefault(p => p.PurchaseItemId == id);
        }

        public void Add(PurchaseItem item)
        {
            item.CreatedAt = DateTime.Now;
            db.PurchaseItems.Add(item);
            db.SaveChanges();
        }

        public void Update(PurchaseItem item)
        {
            item.UpdatedAt = DateTime.Now;
            db.PurchaseItems.Update(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = db.PurchaseItems.Find(id);
            if (item != null)
            {
                db.PurchaseItems.Remove(item);
                db.SaveChanges();
            }
        }
    }

}

