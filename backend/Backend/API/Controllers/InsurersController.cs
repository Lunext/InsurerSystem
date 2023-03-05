using API.Extensions;
using Backend.Shared;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InsurersController : ControllerBase
{
    private readonly IInsurerRepository repo;
    private readonly IValidator<Insurer> validator;
    
    public InsurersController(IInsurerRepository repo, IValidator<Insurer> validator)
    {
        this.validator= validator;
        this.repo=repo;
    }

    [HttpGet]
    
    [ProducesResponseType(200, Type = typeof(IEnumerable<Insurer>))]
    public async Task<IEnumerable<Insurer>> GetInsurers()
    {
        
        return await repo.RetrieveAllAsync();
    }

    //GET: api/insurers[id]
    [HttpGet("{id}", Name = nameof(GetInsurerById))]
    [ProducesResponseType(200, Type = typeof(Insurer))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetInsurerById(int id)
    {

        Insurer? insurer = await repo.RetrieveAsyncById(id);
        

        return insurer is null ? NotFound() : Ok(insurer);

    }

    //POST: api/insurers
    //Body: Insurer(JSON,XML)
    [HttpPost]
    [ProducesResponseType(201, Type=typeof(Insurer))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> Create([FromBody] Insurer insurer)
    {
        ValidationResult vadResult = await validator.ValidateAsync(insurer);

        if (insurer is null) return BadRequest();
        if (!vadResult.IsValid)
        {
            vadResult.AddToModelState(ModelState);
            return BadRequest(ModelState); 
        }
        
        Insurer? addedInsurer = await repo.CreateAsync(insurer);
       
        return addedInsurer is null ?
            BadRequest("Error to save Insurer.")
            : CreatedAtRoute(routeName: nameof(GetInsurerById),
            routeValues: new { id = addedInsurer.Id },
            value: addedInsurer);

    }

    //PUT: api/insurers/[id]
    //BODY:Insurer(JSON,XML)
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Update(int id, [FromBody] Insurer insurer)
    {
        ValidationResult vadResult= await validator.ValidateAsync(insurer);


        if (insurer is null||insurer.Id!=id) return BadRequest();

        if (!vadResult.IsValid)
        {
            vadResult.AddToModelState(ModelState);
            return BadRequest(ModelState); 
        }

        Insurer? existing = await repo.RetrieveAsyncById(id);

        if (existing is null) return NotFound();
        await repo.UpdateAsync(id, insurer);

        return new NoContentResult(); 
    }

    //DELETE:api/insurers/[[id]
    [HttpDelete("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Delete(int id)
    {
        Insurer? existing = await repo.RetrieveAsyncById(id);
        if (existing is null) return NotFound();

        bool? deleted = await repo.DeleteAsync(id);

        return deleted.HasValue &&deleted.Value ?
             new NoContentResult()
             : BadRequest($"Insurer {id} was found but failed to delete"); 
    }




}

