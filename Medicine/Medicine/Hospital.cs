namespace Medicine
{
    internal class Hospital
    {
        private List<Doctor> doctors = new List<Doctor>();
        private List<Appointment> appointments = new List<Appointment>();

        public void AddDoctor(string name)
        {
            doctors.Add(new Doctor(name));
            Console.WriteLine($"Doctor {name} added successfully.");
        }

        public void ViewAllDoctors()
        {
            Console.WriteLine("List of doctors:");
            foreach (var doctor in doctors)
            {
                Console.WriteLine(doctor.Name);
            }
        }
        public void ScheduleAppointment(string doctorName, string patientName, DateTime date)
        {
            Doctor doctor = null;
            foreach (Doctor d in doctors)
            {
                if (d.Name == doctorName)
                {
                    doctor = d;
                    break;
                }
            }
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }
            bool slotAvailable = true;
            foreach (var existingAppointment in doctor.Appointments)
            {
                if (date >= existingAppointment.Date && date < existingAppointment.Date.AddHours(1))
                {
                    slotAvailable = false;
                    break;
                }
            }
            if (slotAvailable)
            {
                doctor.Appointments.Add(new Appointment(patientName, date));
                Console.WriteLine($"Appointment scheduled for {patientName} with {doctorName} on {date}.");
            }
            else
            {
                Console.WriteLine("Another appointment already scheduled in this time slot.");
            }
        }

        public void ViewAppointmentsOfDoctor(string doctorName)
        {
            Doctor doctor = null;
            foreach (Doctor d in doctors)
            {
                if (d.Name == doctorName)
                {
                    doctor = d;
                    break;
                }
            }
            if (doctor == null)
            {
                Console.WriteLine("Doctor not found.");
                return;
            }

            Console.WriteLine($"Appointments for Doctor {doctorName}:");
            foreach (var appointment in doctor.Appointments)
            {
                Console.WriteLine($"- {appointment.Date}");
            }
        }
    }
}

