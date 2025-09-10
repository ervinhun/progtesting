using Database;
using Service;
using Xunit;

namespace Test;

public class UnitTest1 (PetService service, MyDbContext ctx)
{
    
    
    
    //Happy test
    [Fact]
    public void Test1()
    {
        Assert.Equal(0, ctx.Sellers.Count());
        ctx.Sellers.Add(new Seller()
        {
            Id = "1",
            Name = "Test",
            Address = "Test",
            Pets = new List<Pet>()
            {
                new Pet()
                {
                    Name = "TestPet",
                    Breed = "TestBreed",
                    Price = 100,
                    Seller = "1",
                    SoldDate = new DateOnly(2022, 1, 1),
                    Createdat = DateTime.UtcNow,
                    Id = Guid.NewGuid().ToString()
                }
            }
        });
        ctx.SaveChanges();
        Assert.Equal(1, ctx.Sellers.Count());
        Assert.Equal("1", ctx.Sellers.First().Id);
        Assert.Equal("Test", ctx.Sellers.First().Name);
        Assert.Equal("Test", ctx.Sellers.First().Address);
        Assert.Equal(1, ctx.Sellers.First().Pets.Count());
        Assert.Equal("TestPet", ctx.Sellers.First().Pets.First().Name);
        Assert.Equal("TestBreed", ctx.Sellers.First().Pets.First().Breed);
        Assert.Equal(100, ctx.Sellers.First().Pets.First().Price);
        Assert.Equal("1", ctx.Sellers.First().Pets.First().Seller);
        Assert.Equal(new DateOnly(2022, 1, 1), ctx.Sellers.First().Pets.First().SoldDate);
        Assert.Equal(DateTime.UtcNow, ctx.Sellers.First().Pets.First().Createdat);
        Assert.Equal(Guid.NewGuid().ToString(), ctx.Sellers.First().Pets.First().Id);
    }
}