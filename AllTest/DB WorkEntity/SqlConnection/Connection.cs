using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain;

namespace DB_WorkEntity.SqlConnection
{
   
    public class Connection: IConnection
    {
        public Connection(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; set; }

        public List<EndDayShow> GetEndDayShowProcedure(int numend, int kind)
        {
            var returnStructs = new List<EndDayShow>();
            using (var sqlConn = new System.Data.SqlClient.SqlConnection(ConnectionString))
            {
                var sqlCmd = new SqlCommand("EndDayShow", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Numend", /* Значение параметра */ numend);
                sqlCmd.Parameters.AddWithValue("@Kind", /* Значение параметра */ kind);


                sqlConn.Open();
                using (SqlDataReader dr = sqlCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        //var d = dr.GetOrdinal("Depart1");
                        short? depart = /*dr.GetOrdinal("Depart") == 0 ? (short?)null : */dr.GetInt16(dr.GetOrdinal("Depart"));
                        int codFuel = dr.GetInt32(dr.GetOrdinal("CodFuel"));
                        string name = dr.GetString(dr.GetOrdinal("name"));
                        int price = dr.GetInt32(dr.GetOrdinal("Price"));
                        var d = dr.GetOrdinal("Amount");
                        double amount = dr.GetDouble(dr.GetOrdinal("Amount"));
                        int pay = dr.GetInt32(dr.GetOrdinal("Pay"));
                        
        
                        returnStructs.Add(new EndDayShow
                        {
                            CodFuel = codFuel,
                            Depart = depart,
                            Name = name,
                            Amount = amount,
                            Kind = kind,
                            Pay = pay,
                            Price = price
                        });
                    }
                }
            }
            return returnStructs;
        }
    }
}
