namespace Entitys
{
    public class DivisorEntity
    {
        public int Number { get; set; }
        public bool Prime { get; set; }

        public DivisorEntity(int number, bool prime)
        {
            Number = number;
            Prime = prime;
        }

        public DivisorEntity()
        {
        }
    }
}
