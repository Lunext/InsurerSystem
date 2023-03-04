namespace Backend.Shared;

public class InsurerRepository : IInsurerRepository
{

    /// <summary>
    /// This method return a list of Insurers
    /// </summary>
    /// <returns>It returns a Task of IEnumerable<Insurer></returns>
  
    public Task<IEnumerable<Insurer>> RetrieveAllAsync()
    {

        
    }

    public Task<Insurer?> RetrieveAsyncById(int id)
    {
        throw new NotImplementedException();
    }


    public Task<Insurer?> CreateAsync(IInsurerRepository insurer)
    {
        throw new NotImplementedException();
    }

    public Task<Insurer?> UpdateAsync(int id, Insurer insurer)
    {
        throw new NotImplementedException();
    }

    public Task<bool?> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

   

   

    
}

