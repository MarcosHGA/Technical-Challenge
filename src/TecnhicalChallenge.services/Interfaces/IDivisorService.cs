using Dtos;
using Entitys;

namespace Interfaces
{   
    public interface IDivisorService
    {
        DivisorDto CalcDivisor(DivisorEntity divisor);
    }
}
