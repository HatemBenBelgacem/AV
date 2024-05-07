using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AV.Models;

public class Aufgabe
{
    public int Id { get; set; }
    public string? Bezeichnung { get; set; }
}

