using System;
using System.Collections.Generic;

namespace CykelShop
{
    public class CykelButik
    {
        public string name;
        public List<Cykler> Cykler = new List<Cykler>();

        public CykelButik(string name)
        {
            this.name = name;
        }

        public void AddCykel(Cykler cykel)
        {
            Cykler.Add(cykel);
        }

        public int CyklerAntal()
        {
            return Cykler.Count;
        }

        public List<string> CyklerModels()
        {
            List<string> array = new List<string>();
            for (int i = 0; i < CyklerAntal(); i++)
            {
                array.Add(Cykler[i].model);
            }
            return array;
        }

        public List<string> CyklerModelsRed()
        {
            List<string> array = new List<string>();
            for (int i = 0; i < CyklerAntal(); i++)
            {
                if (Cykler[i].color == "Red")
                {
                    array.Add(Cykler[i].model + " : " + Cykler[i].color);
                }
            }
            return array;
        }

        public List<double> CyklerWheelsUnder(double Size)
        {
            List<double> array = new List<double>();
            for (int i = 0; i < CyklerAntal(); i++)
            {
                if(Cykler[i].wheelsize < Size)
                {
                    array.Add(Cykler[i].wheelsize);
                }
            }
            return array;
        }
        public List<double> CyklerWheelsOver(double Size)
        {
            List<double> array = new List<double>();
            for (int i = 0; i < CyklerAntal(); i++)
            {
                if (Cykler[i].wheelsize > Size)
                {
                    array.Add(Cykler[i].wheelsize);
                }
            }
            return array;
        }
    }
}
