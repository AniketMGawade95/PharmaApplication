
using PharmaAPICreation.DTO;



namespace PharmaAPICreation.Repo
{
    public interface IMedicineRepository
    {
        Task<IEnumerable<BuyMedicineDTO>> GetAllMedicinesAsync();
        Task<BuyMedicineDTO> GetMedicineByIdAsync(int id);
    }
}
