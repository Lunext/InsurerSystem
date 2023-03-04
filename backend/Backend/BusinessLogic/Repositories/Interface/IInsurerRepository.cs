namespace Backend.Shared; 

public interface IInsurerRepository
{
    Task<Insurer?> CreateAsync(IInsurerRepository insurer);
    Task<IEnumerable<Insurer>> RetrieveAllAsync();
    Task<Insurer?> RetrieveAsyncById(int id);
    Task<Insurer?> UpdateAsync(int id, Insurer insurer);
    Task<bool?> DeleteAsync(int id);
    


}
