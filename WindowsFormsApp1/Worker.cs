using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    public class Worker
    {
        public string Surname { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public decimal Hous { get; set; }
        public decimal Selery { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return
                $"Surname: {Surname};"  + Environment.NewLine +
                $" Selery: {Selery};" + Environment.NewLine +
                $" Position: {Position};" + Environment.NewLine +
                $" City: {City};" + Environment.NewLine +
                $" Street: {Street};" + Environment.NewLine +
                $" House: {Hous};" +Environment.NewLine; 
        }
    }
}
