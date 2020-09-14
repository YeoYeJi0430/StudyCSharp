using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingException
{
    class InvalidArgumentExcepion : Exception
    {
        public InvalidArgumentExcepion()
        {
        }

        public InvalidArgumentExcepion(string message) : base(message)
        {
        }

        public object Argument{ get; set; }

        public string Range { get; set; }

    }
    class Program
    {
        static uint MergeARGB(uint alpha, uint red, uint green, uint blue)
        {
            uint[] args = new uint[] { alpha, red, green, blue };

            foreach (var item in args)
            {
                if(item > 255)
                {
                    throw new InvalidArgumentExcepion()
                    {
                        Argument = item,
                        Range = "0-255",
                    };
                }
            }
            return (alpha << 24 & 0xFF000000) |
                (red << 16 & 0x00ff0000) |
                (green << 8 & 0x0000ff00) |
                (blue & 0x000000ff);
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"0x{MergeARGB(255, 111, 111, 111):X}");
                Console.WriteLine($"0x{MergeARGB(255, 255, 257, 255):X}");
            }
            catch(InvalidArgumentExcepion ex)
            {
                Console.WriteLine($"예외 발생 {ex.Message}");
                Console.WriteLine($"예외 발생 입력범위 : {ex.Range}");
                Console.WriteLine("!!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
