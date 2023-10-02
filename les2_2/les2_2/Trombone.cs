using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les2_2
{
    public class Trombone : MusicalInstrument
    {
        public Trombone(string name, string description, string history) : base(name, description, history)
        {
        }
        public override void Sound()
        {
            Console.WriteLine("Звук тромбона: бархатний і глибокий.");
        }
    }
}
