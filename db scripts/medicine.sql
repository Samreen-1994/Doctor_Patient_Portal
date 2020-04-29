create procedure fetchPatientMedicineRequest(@userid int, @usertype int) as if @usertype = 2 begin 
select 
  store.storeName as Name, 
  store.city, 
  store.phone, 
  store.email, 
  mr.requestText, 
  mr.requestImage, 
  mr.requestResponse, 
  mr.requestId 
from 
  Users patient 
  inner join medicinerequest mr on patient.userId = mr.patientId 
  and patient.userId = @userid 
  and patient.deleted = 0 
  inner join Users store on mr.medicalStoreId = store.userId 
  and store.deleted = 0 
where 
  mr.deleted = 0 end else if @usertype = 3 begin 
select 
  patient.firstName + ' ' + patient.lastName as Name, 
  patient.city, 
  patient.phone, 
  patient.email, 
  mr.requestText, 
  mr.requestImage, 
  mr.requestResponse, 
  mr.requestId 
from 
  Users patient 
  inner join medicinerequest mr on patient.userId = mr.patientId 
  and patient.deleted = 0 
  inner join Users store on mr.medicalStoreId = store.userId 
  and store.userId = @userid 
  and store.deleted = 0 
where 
  mr.deleted = 0 end
