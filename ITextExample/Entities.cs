using System.Collections.Generic;
using System.Linq;

namespace ITextExample
{
    public static class Entities
    {
        public static Dictionary<string, string> SampleCollection = new Dictionary<string, string>
        {
            {"Par","Par"},
            {"Kgr","Kgr"},
            {"M3","M3"},
            {"M2","M2"},
        };
        public static List<string> ListOfWarehouses = new List<string>
        {
            "SIROVINI",
            "CENTRALEN MAGACIN",
            "KANCELARISKI MATERIJAL",
            "GORIVO",
            "SITEN INVENTAR",
        };
        public static Dictionary<string, string> SampleCollectionWarehouses = new Dictionary<string, string>();

        public static Dictionary<string, string> ReadyWarehouses()
        {
            for (int i = 0; i < ListOfWarehouses.Count; i++)
            {
                SampleCollectionWarehouses.Add("00"+(i+1),ListOfWarehouses.ElementAt(i));
            }
            return SampleCollectionWarehouses;
        }
    }
}