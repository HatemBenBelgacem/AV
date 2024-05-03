using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AV.Models;

public class Auftrag
{
    public int Id { get; set; }
    public string? Beschreibung { get; set; }
    public int? AdresseId { get; set; }
    public Adresse? Adresse { get; set; }
    public ICollection<Position> Position { get; set; }
  
}