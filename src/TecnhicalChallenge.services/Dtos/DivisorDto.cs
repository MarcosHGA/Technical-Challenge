using System.Collections.Generic;

namespace Dtos
{
    public class DivisorDto
    {
        public bool Ok { get; set; }
        public List<int> Divisors { get; set; }
        public string Error { get; set; }

        public DivisorDto()
        {
            Divisors = new List<int>();
        }
    }
}
