using System;
using System.Collections.Generic;
using Dtos;
using Entitys;
using Infra.Util;
using Interfaces;

namespace Services
{
    public class DivisorService : IDivisorService
    {   
        public DivisorDto CalcDivisor(DivisorEntity divisor)
        {
            DivisorDto divisorDto = new DivisorDto();
            try
            {
                for (int i = 1; i <= divisor.Number; i++)
                {
                    if (Util.CheckDivisor(divisor.Number, i))
                    {
                        divisorDto.Divisors.Add(i);
                    }
                }

                if (divisor.Prime)
                {
                    List<int> primeDivisors = new List<int>();

                    for (int i = 0; i < divisorDto.Divisors.Count; i++)
                    {
                        if (Util.CheckPrime(divisorDto.Divisors[i]))
                            primeDivisors.Add(divisorDto.Divisors[i]);
                    }

                    divisorDto.Divisors = primeDivisors;
                }

                divisorDto.Ok = true;
            }
            catch (Exception ex)
            {
                divisorDto.Error = ex.Message;
                divisorDto.Ok = false;
            }

            return divisorDto;
        }       
    }
}
