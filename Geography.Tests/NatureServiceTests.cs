using Geography.Data.Data;
using Geography.Data.Data.Models;
using Geography.Services;
using Microsoft.EntityFrameworkCore;

namespace Geography.Tests
{
    public class NatureServiceTests
    {
        [Fact]
        public void TestingAll()
        {
            var options = new DbContextOptionsBuilder<GeographyDbContext>()
            .UseInMemoryDatabase(databaseName: "Find_Nature")
            .Options;


            using (var dbContext = new GeographyDbContext(options)) 
            {

                var user = new Data.Models.GeographyUser()
                {
                    UserName = "Denkata",
                    Email = "dmgdenka7a@abv.bg",
                    Balance = 1000,
                };

                var natureType = new NatureType()
                {
                    Type = "Mountain",
                    User = user,
                };

                dbContext.Users.Add(user);
                dbContext.NatureTypes.Add(natureType);

                dbContext.NatureObjects.Add(new Data.Data.Models.NatureObject()
                {
                    Name = "Old mountain",
                    Information = "some info",
                    URL = "https://decanaplanina.com/wp-content/uploads/2019/07/20190723_082257646.jpeg",
                    NatureType = natureType
                });

                dbContext.SaveChanges();

                var natureService = new NatureService(dbContext);
                var result = natureService.All();

                Assert.True(result != null, "All method works");
                Assert.Equal(result.Count, 1);
            }
        }
    }
}