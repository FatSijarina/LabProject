using System;

namespace CaseTrackingAPI.Models
{
    public class BiologicalTrace
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public string Specification { get; set; } = null!;

        // Composition requires the relationship to be exclusive, so the Person property
        // should be mandatory
        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
    }

}
