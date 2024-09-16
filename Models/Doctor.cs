using System.ComponentModel.DataAnnotations;

namespace NMK.Models;

public class Doctor
{
    public int Id { get; set; }

    public required DateTime DateAdded { get; set; } 

    public DateTime? DateModified { get; set; }
    
    public required string Name { get; set; }
    
    public required string Surname { get; set; }

    public required string Title { get; set; }
    
    public int DoctorCode { get; set; }
    public bool IsDeleted { get; set; } = false;

    public ICollection<Admission> Admissions { get; set; } = new List<Admission>();
    

}

