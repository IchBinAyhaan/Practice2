namespace Medicine
{
    internal class Doctor
    {
        public string Name { get; set; }
        public List<Appointment> Appointments { get; set; }


        public Doctor(string name)
        {
            Name = name;
            Appointments = new List<Appointment>();

        }
    }
}
