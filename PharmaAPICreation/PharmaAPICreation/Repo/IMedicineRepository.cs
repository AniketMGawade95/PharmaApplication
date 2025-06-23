
﻿
using PharmaAPICreation.DTO;



﻿using PharmaAPICreation.Models;


namespace PharmaAPICreation.Repo
{
    public interface IMedicineRepository
    {

        Task<IEnumerable<BuyMedicineDTO>> GetAllMedicinesAsync();
        Task<BuyMedicineDTO> GetMedicineByIdAsync(int id);

        void AddMedicine(Medicine medicine);
        void UpdateMedicine(Medicine medicine);
        void DeleteMedicine(int id);
        Medicine GetMedicineById(int id);
        List<Medicine> GetAllMedicines();

    }
}
