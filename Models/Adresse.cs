using System.ComponentModel.DataAnnotations;

namespace AV.Models;

public class Adresse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Auftrag>? Auftrag { get; set; }
}