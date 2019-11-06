using System;
using System.Collections.Generic;

namespace CykelShop
{
    public class Koncern
    {
        public List<CykelButik> CykelButik = new List<CykelButik>();

        public void AddButik(CykelButik butik)
        {
            CykelButik.Add(butik);
        }

        public List<string> ReturnAllRedBikes()
        {
            List<string> array = new List<string>();
            for (int i = 0; i < CykelButik.Count; i++)
            {
                var Red = CykelButik[i].CyklerModelsRed();
                for (int x = 0; x < Red.Count; x++)
                {
                    array.Add(CykelButik[i].name + " : " + Red[x]);
                }
            }
            return array;
        }
    }
}
