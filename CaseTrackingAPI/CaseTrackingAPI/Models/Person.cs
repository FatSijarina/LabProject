namespace CaseTrackingAPI.Models
{
    public class Person
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string Name { get; set; } = null!;
        public char Gender { get; set; }
        public string Profession { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Residence { get; set; } = null!;
        public string MentalState { get; set; } = null!;
        public string Background { get; set; } = null!;

        // Establish relationships between the Person class and other necessary classes
        public List<Statement>? Statements { get; set; }
        public List<BiologicalTrace>? BiologicalTraces { get; set; }
        public List<Evidence> Evidences { get; set; } = null!;
    }
}
