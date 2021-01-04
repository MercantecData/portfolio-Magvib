using System;
using System.Collections.Generic;

namespace Biblioteksobjekt
{
    public class Kunder
    {
        public string name;
        public List<Bog> Bog = new List<Bog>();

        public Kunder(string name)
        {
            this.name = name;
        }
        public void AddBog(Bog Title)
        {
            Bog.Add(Title);
        }
        public string BogTitle(int id)
        {
            return Bog[id].title;
        }
        public int BogCount()
        {
            return Bog.Count;
        }
    }
}
