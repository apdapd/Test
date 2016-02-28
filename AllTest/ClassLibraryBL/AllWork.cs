using System.Collections.Generic;
using System.Linq;
using Domain;


//public static List<int> Config;

namespace ClassLibraryBL
{
    public class AllWork
    {
        private readonly List<EndDayShow> _endDayShowList = new List<EndDayShow>();
 
        public List<string> DayShow(int nn, int repN = 1)
        {
            var connectionType = (ConnectionType)repN;

            var connection = ConnectionFactory.GetConnection(connectionType);
            
            var lStr = new List<string>();
            foreach (var i in MainDefs.Config)
            {
                _endDayShowList.Clear();
                _endDayShowList.AddRange(connection.GetEndDayShowProcedure(nn, i));
                //GetEndDays(nn,i);
                lStr.Add(string.Format("Вид {0}", i));
                lStr.AddRange(
                    _endDayShowList.Select(
                        endDayShow =>
                        {
                            //endDayShow.Depart = 0;
                            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}", endDayShow.Depart, endDayShow.Name,
                                endDayShow.Price, endDayShow.Amount, endDayShow.Pay);
                        }
                           ));
            }
            return lStr;
        }

        private void GetEndDays(int numEndDay, int i)
        {
                
        }

    }
}
