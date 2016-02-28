using System.Collections.Generic;

namespace Domain
{
    public static class MainDefs
    {
        public static List<int> Config;

        public static void ReadConfig()
        {
            Config = new List<int> {0, -1, -2, -5, -6, -8};
        }
    }
    
    public class EndDayShow
    {
        public short? Depart { get; set; }
        public int CodFuel { get; set; }
        public double Amount { get; set; }
        public int Price { get; set; }
        public int Pay { get; set; }
        public int Kind { get; set; }
        public string Name { get; set; }
    }
}
