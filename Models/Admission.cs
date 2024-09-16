using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NuGet.Protocol;

namespace NMK.Models;

public class Admission
{
    public int Id { get; set; }

    public required DateTime DateAdded { get; set; } 

    public DateTime? DateModified { get; set; } 
    [DataType(DataType.Date)]
    public required DateTime DateAdmitted { get; set; } 
    [ForeignKey("Patient")]
    public int? PatientId { get; set; }
    
    public Patient? Patient { get; set; }
    [ForeignKey("Doctor")]  
    public int? DoctorId { get; set; }
    
    public Doctor? Doctor { get; set; } 
    
    public bool Emergency { get; set; } = true;

    public DateTime ReportDate { get; set; }
    public string ReportText { get; set; } = string.Empty;

    public bool IsDeleted { get; set; } = false;
}


