using System.ComponentModel.DataAnnotations;

namespace NMK.Models;

public class Patient
{
    public int Id { get; set; }

    public required DateTime DateAdded { get; set; }

    public DateTime? DateModified { get; set; }
    
    public required string NameAndSurname { get; set; }
    
    [DataType(DataType.Date)]
    public required DateTime DateOfBirth { get; set; }
    
    public required string Gender { get; set; }
    public string? Address { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    public bool IsDeleted { get; set; } = false;

    public ICollection<Admission> Admissions { get; set;} = new List<Admission>();
    

}


