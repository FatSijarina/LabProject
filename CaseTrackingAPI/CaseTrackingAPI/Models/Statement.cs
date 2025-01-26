using System;

namespace CaseTrackingAPI.Models
{
    public class Statement
    {
        public int Id { get; set; }
        public DateTime DateGiven { get; set; }
        public string Content { get; set; } = null!;

        // Composition requires the relationship to be exclusive, so the Person property
        // should be mandatory

        public int PersonId { get; set; }
        public Person Person { get; set; } = null!;
    }
}
