using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Shared;

public class Insurer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set;}

    public string? Name { get; set; }

    public decimal Commission { get; set;}

    public bool IsApproved { get; set;}


}
