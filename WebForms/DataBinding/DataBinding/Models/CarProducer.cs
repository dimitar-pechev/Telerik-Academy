using System.Collections.Generic;

namespace DataBindinHW.Models
{
    public class CarProducer
    {
        public string Name { get; set; }

        public IList<string> Models { get; set; }
    }
}