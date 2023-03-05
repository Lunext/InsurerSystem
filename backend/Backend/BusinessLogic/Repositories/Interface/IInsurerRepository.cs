namespace Backend.Shared; 

public interface IInsurerRepository
{

    
    /*
     * These are the methods that will be
     * implemented on the repository 
     * The first is to create a Insurer, 
     * The second one is to bring the list of insurers, 
     * The third is to get one by the id, 
     * The fourth one is to update it, 
     * and the last one is to delete it
     */
    Task<Insurer?> CreateAsync(Insurer insurer);
    Task<IEnumerable<Insurer>> RetrieveAllAsync();
    Task<Insurer?> RetrieveAsyncById(int id);
    Task<Insurer?> UpdateAsync(int id, Insurer insurer);
    Task<bool?> DeleteAsync(int id);
    


}
