using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AV.Models;

public class Position
{
    public int Id { get; set; }
    public int AuftragId { get; set; }
    public Auftrag? Auftrag { get; set; }
    public int ProduktId { get; set; }
    public Produkt? Produkt { get; set; }
}