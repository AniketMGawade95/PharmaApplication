using Microsoft.EntityFrameworkCore;
using PharmaAPICreation.Data;
using PharmaAPICreation.DTO;
using PharmaAPICreation.Repo;

namespace PharmaAPICreation.Services
{
    public class BuyMedicineServices : IMedicineRepository
    {
        private readonly ApplicationDbContext _context;
        public BuyMedicineServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BuyMedicineDTO>> GetAllMedicinesAsync()
        {
            return await _context.Medicines
            .Select(m => new BuyMedicineDTO
            {
                MedicineId = m.MedicineId,
                Name = m.Name,
                Category = m.Category,
                GSTRate = m.GSTRate
            }).ToListAsync();
        }

        public async Task<BuyMedicineDTO> GetMedicineByIdAsync(int id)
        {
            return await _context.Medicines
           .Where(m => m.MedicineId == id)
           .Select(m => new BuyMedicineDTO
           {
               MedicineId = m.MedicineId,
               Name = m.Name,
               Category = m.Category,
               GSTRate = m.GSTRate
           }).FirstOrDefaultAsync();
        }
    }
}
