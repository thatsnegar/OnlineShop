namespace DAL
{
    public interface ISequenceNumberRepository : Base.IRepository<Models.SequenceNumber>
    {
        // **********
        Models.SequenceNumber? GetByName(string name);

        System.Threading.Tasks.Task<Models.SequenceNumber?> GetByNameAsync(string name);

        System.Threading.Tasks.Task<Models.SequenceNumber?> GetByNamForRegisterDiscountAsync(string name);
        // **********
    }
}
