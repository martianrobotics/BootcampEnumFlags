using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampEnumFlags
{
    class Program
    {
        //http://www.codeproject.com/Articles/396851/Ending-the-Great-Debate-on-Enum-Flags
        // [Flags] so far, only difference detected is when watching the ApptDays variable, it shows Monday|Wednesday|Friday as value. 
        // if commented out, ApptDays show 42
        // HasFlag works the same either way
        [Flags]  
        enum DaysOfTheWeek // increment by power of 2 for flag purposes (ie, can be ORed to get individual weekday names)
        {
            Sunday = 1,
            Monday = 1<<1,     // 2
            Tuesday = 1<<2,    // 4
            Wednesday = 1<<3,  // 8
            Thursday = 1<<4,   // 16
            Friday = 1<<5,     // 32
            Saturday = 1<<6    // 64
        }
        static void Main(string[] args)
        {
            DaysOfTheWeek ApptDays = DaysOfTheWeek.Monday | DaysOfTheWeek.Wednesday | DaysOfTheWeek.Friday;

            // loop and HasFlag using list
            List<string> ldows = Enum.GetNames(typeof(DaysOfTheWeek)).ToList();// convert enum elements to list of string

            ldows = Enum.GetNames(typeof(DaysOfTheWeek)).ToList();

            foreach (string dow in ldows)
            {
                DaysOfTheWeek edow;
                Enum.TryParse(dow, out edow);
                Console.WriteLine("{0} is {1}included", dow, ApptDays.HasFlag(edow) ? "" : "NOT ");
            }

            // loop and HasFlag using Class.Array
            //Array dows = Enum.GetValues(typeof(DaysOfTheWeek));                // convert enum elements to Class.Array, simpler for HasFlag
            //foreach (DaysOfTheWeek dow in dows)
            //    Console.WriteLine("{0} is {1}included", dow, ApptDays.HasFlag(dow) ? "" : "NOT ");
            
            // alt to HasFlag: if((daysOfTheWeek & DaysOfTheWeek.Monday) == DaysOfTheWeek.Monday)
            Console.WriteLine();
            Console.WriteLine(String.Join(",", ldows));
            Console.ReadKey();
        }
    }
}
