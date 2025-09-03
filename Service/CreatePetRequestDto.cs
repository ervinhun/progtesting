using System.ComponentModel.DataAnnotations;

namespace Service;

public class CreatePetRequestDto 
{
    public CreatePetRequestDto(string name, int age)
    {
        Name = name;
        Age = age;
    }

    [MinLength(3)]
    public string Name { get; set; }
    [Range(0, 25)]
    public int Age { get; set; }
}