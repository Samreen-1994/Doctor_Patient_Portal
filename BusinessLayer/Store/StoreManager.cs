using BusinessLayer.DTOModel;
using DTO;
using DTO.Context;
using DTO.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Store
{
    public class StoreManager : IStoreManager
    {
        public bool CreateMedicineRequest(MedicineRequest request)
        {
            using (UserContext c = new UserContext())
            {
                var req = c.MedicineRequests.Where(x => x.requestId == request.requestId && request.deleted == false).FirstOrDefault();
                if (req != null)
                {
                    req.deleted = request.deleted;
                    req.requestResponse = request.requestResponse;

                    c.Update(req);
                }
                else
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(request.requestImage);
                    string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                    request.requestImage = base64ImageRepresentation;

                    c.MedicineRequests.Add(request);
                }
                c.SaveChanges();
                return true;
            }
        }

        public List<User> FetchMedicalStoreByCity(string city)
        {
            using (UserContext c = new UserContext())
            {
                var storeList = c.Users.Where(x => x.userType == 3 && x.deleted == false && x.city.Equals(city)).ToList();
                if (storeList != null)
                {
                    return storeList;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        public List<MedicineRequestResponse> FetchMedicineRequestResponse(User user)
        {
            using (UserContext userContext = new UserContext())
            {
                var results = userContext.Query<MedicineRequestResponse>()
                     .FromSql("EXEC fetchPatientMedicineRequest {0},{1}", user.userId, user.userType)
                     .ToList();

                return results;
            }
        }
    }
}
