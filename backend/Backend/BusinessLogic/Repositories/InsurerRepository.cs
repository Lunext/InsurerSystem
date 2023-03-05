using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Concurrent;

namespace Backend.Shared;

public class InsurerRepository : IInsurerRepository
{


    //Use a static thread safe dictionary field to cache the customer 
    //It helps to have a better performance
    private static ConcurrentDictionary<int, Insurer>? insurerCache;


    /*I decided to use a data context field because
     * it shouldn't be cached due to its internal caching
       
     */

    private InsurerDbContext db;

    public InsurerRepository(InsurerDbContext db)
    {
        this.db=db;

        if (insurerCache is null)
        {
            insurerCache=new ConcurrentDictionary
                <int, Insurer>(db.Insurers
                .ToDictionary(i => i.Id));
        }
    }

    public Task<IEnumerable<Insurer>> RetrieveAllAsync()
    {
        //for performance get from cache 

        /*If its okay, it return de elements 
         * that are on the insurer Cache*/
        return Task.FromResult(insurerCache is null ? Enumerable.Empty<Insurer>() :
            insurerCache.Values);
        
    }

    public Task<Insurer?> RetrieveAsyncById(int id)
    {
        if (insurerCache is null) return null!;

        insurerCache.TryGetValue(id, out Insurer? insurer);
        return Task.FromResult(insurer);
    }

    private Insurer UpdateCache(int id, Insurer insurer)
    {
        Insurer? old; 
        if(insurerCache is not null)
        {
            if (insurerCache.TryGetValue(id, out old))
            {
                if (insurerCache.TryUpdate(id, insurer, old))
                {
                    return insurer;
                }
            }
        }
        return null!; 
    }
    public async Task<Insurer?> CreateAsync(Insurer insurer)
    {
        
       
        EntityEntry<Insurer> added = await db.Insurers.AddAsync(insurer);
        int affected = await db.SaveChangesAsync();

        if (affected==1)
        {
            if (insurerCache is null) return insurer;

            return insurerCache.AddOrUpdate(insurer.Id, insurer, UpdateCache);
        }
        else
        {
            return null; 
        }

    }

    public async Task<Insurer?> UpdateAsync(int id, Insurer insurer)
    {

        db.Insurers.Update(insurer);

        int affected = await db.SaveChangesAsync(); 

        if(affected==1)
        {
            return UpdateCache(id, insurer);
        }
        return null;
       
    }

    public async Task<bool?> DeleteAsync(int id)
    {
        Insurer? insurer = db.Insurers.Find(id);

        if (insurer is null) return null;
        db.Insurers.Remove(insurer);
        int affected = await db.SaveChangesAsync(); 

        if(affected == 1)
        {
            if (insurerCache is null) return null;
            return insurerCache.TryRemove(id, out insurer);
        }
        else
        {
            return null;
        }
    }
}

