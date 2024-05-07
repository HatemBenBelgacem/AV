using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AV.Models;

public class Adresse
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Auftrag>? Auftrag { get; set; }
    
}