using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les2_2
{
    public class MusicalInstrument
    {
        private string name;
        private string description;
        private string history;
        public MusicalInstrument(string incomingName, string incomingDescription, string incomingHistory)
        {
            name = incomingName;
            description = incomingDescription;
            history = incomingHistory;
        }
        public virtual void Sound()
        {
            Console.WriteLine("Звук музичного інструменту.");
        }
        public void Show()
        {
            Console.WriteLine("Назва: " + name);
        }
        public void Desc()
        {
            Console.WriteLine("Опис: " + description);
        }
        public void HistoryInfo()
        {
            Console.WriteLine("Історія: " + history);
        }
        public void AfterShow()
        {
            Console.WriteLine("Для продовження натисніть будь-яку клавішу.");
            Console.ReadKey(true);
        }
    }
}
