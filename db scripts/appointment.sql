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
  patient.firstName +' '+ patient.lastName as doctorName, 
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
  
  
  CREATE procedure getDoctorAppointments(@doctorId int) as 
select 
  a.appointmentId, 
  patient.firstName +' '+ patient.lastName as doctorName, 
  a.doctorId, 
  a.patientId, 
  a.appointmentTitle, 
  a.appointmentSchedule, 
  a.appointmentDescription, 
  a.appointmentCompleted, 
  a.appointmentApproved, 
  a.deleted 
from 
  Users doctor 
  inner join appointment a on doctor.userId = a.doctorId 
  and doctor.userType = 1 
  and doctor.userId = @doctorId 
  inner join Users patient on a.patientId = patient.userId 
where 
  patient.deleted = 0 
  and doctor.deleted = 0 
  and a.deleted = 0


