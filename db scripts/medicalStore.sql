create table medicinerequest (
  requestId int primary key not null identity(1, 1), 
  patientId int, 
  medicalStoreId int, 
  requestText text, 
  requestResponse text, 
  requestImage varchar(255), 
  deleted bit
)
