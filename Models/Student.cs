namespace StudentManagement.Models;
using System.ComponentModel.DataAnnotations;
public class Student
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter your name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your age")]
    public int Age { get; set; }
}
