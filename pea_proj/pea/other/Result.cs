using System.Collections.Generic;

namespace pea.other
{
    public class Result
    {
        public Result()
        {
            Path = new List<int>();
        }

        public int Weight { get; set; }
        public List<int> Path { get; set; }
    }
}