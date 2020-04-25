CREATE TABLE appointment (
  appointmentId int not null primary key identity(1, 1), 
  appointmentTitle varchar(255), 
  appointmentDescription text, 
  doctorId int, 
  patientId int, 
  appointmentSchedule datetime, 
  deleted bit, 
  appointmentApproved bit, 
  appointmentCompleted bit
)


create procedure getPatientAppointments(@patientId int)
as
select 
  doctor.firstName + doctor.lastName as doctorName, 
  a.doctorId, 
  a.patientId, 
  a.appointmentTitle, 
  a.appointmentSchedule, 
  a.appointmentDescription, 
  a.appointmentCompleted, 
  a.appointmentApproved, 
  a.deleted 
from 
  Users patient 
  inner join appointment a on patient.userId = a.patientId 
  and patient.userType = 2 
  and patient.userId = @patientId
  inner join Users doctor on a.doctorId = doctor.userId 
where 
  patient.deleted = 0 
  and doctor.deleted = 0 
  and a.deleted = 0
  
  
  
 alter procedure getPatientAppointments(@patientId int) as 
select 
  a.appointmentId, 
  doctor.firstName + doctor.lastName as doctorName, 
  a.doctorId, 
  a.patientId, 
  a.appointmentTitle, 
  a.appointmentSchedule, 
  a.appointmentDescription, 
  a.appointmentCompleted, 
  a.appointmentApproved, 
  a.deleted 
from 
  Users patient 
  inner join appointment a on patient.userId = a.patientId 
  and patient.userType = 2 
  and patient.userId = @patientId 
  inner join Users doctor on a.doctorId = doctor.userId 
where 
  patient.deleted = 0 
  and doctor.deleted = 0 
  and a.deleted = 0


