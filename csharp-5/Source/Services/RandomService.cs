using System;

namespace Codenation.Challenge.Services
{
    public class RandomService: IRandomService
    {

        public int RandomInteger(int max)
        {
            var random = new Random();
            return random.Next(max);
        }
    }
}