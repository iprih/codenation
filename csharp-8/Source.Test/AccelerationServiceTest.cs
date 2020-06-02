using System;
using System.Collections.Generic;
using Xunit;
using Codenation.Challenge.Models;
using Codenation.Challenge.Services;

namespace Codenation.Challenge
{
    public class AccelerationServiceTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Should_Return_Right_User_When_Find_By_Id(int id)
        {
            var fakeContext = new FakeContext("AccelerationById");            
            fakeContext.FillWith<Acceleration>();

            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var expected = fakeContext.GetFakeData<Acceleration>().Find(x => x.Id == id);

                var service = new AccelerationService(context);                
                var actual = service.FindById(id);

                Assert.Equal(expected, actual, new AccelerationIdComparer());
            }
        }
  
        [Fact]
        public void Should_Add_New_User_When_Save()
        {
            var fakeContext = new FakeContext("SaveNewAcceleration");
            
            var fakeAcceleration = new Acceleration();
            fakeAcceleration.Id = 0;
            fakeAcceleration.Name = "name";
            fakeAcceleration.Slug = "slug";
            fakeAcceleration.ChallengeId = 2;
            fakeAcceleration.CreatedAt = DateTime.Today;
 
            using (var context = new CodenationContext(fakeContext.FakeOptions))
            {
                var service = new AccelerationService(context);
                var actual = service.Save(fakeAcceleration);

                Assert.NotEqual(0, actual.Id);
            }
        }    

    }
}
