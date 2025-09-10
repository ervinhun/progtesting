using System.ComponentModel.DataAnnotations;
using Database;

namespace Service;


public class PetService (MyDbContext ctx)
{
    public async Task<Pet> CreatePet(CreatePetRequestDto dto)
    {
        Validator.ValidateObject(dto, 
            new ValidationContext(dto),
            true);
        
        var pet = new Pet()
        {
            Createdat = DateTime.UtcNow,
            Id = Guid.NewGuid().ToString(),
            Name = dto.Name
        };
        ctx.Pets.Add(pet);
        await ctx.SaveChangesAsync();
        return pet;
    }
}