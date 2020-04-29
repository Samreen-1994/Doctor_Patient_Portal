using BusinessLayer.DTOModel;
using DTO;
using DTO.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Store
{
    public interface IStoreManager
    {
        List<User> FetchMedicalStoreByCity(string city);
        bool CreateMedicineRequest(MedicineRequest request);
        List<MedicineRequestResponse> FetchMedicineRequestResponse(User user);
    }
}
