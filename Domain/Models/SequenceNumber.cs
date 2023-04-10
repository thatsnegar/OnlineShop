namespace Models
{
    public class SequenceNumber : Domain.Base.Entity
    {
        public SequenceNumber() : base()
        {
        }

        // **********
        public string? Name { get; set; }
        // **********

        // **********
        public int Number { get; set; }
        // **********
    }
}
