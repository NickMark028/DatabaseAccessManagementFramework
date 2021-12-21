using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using MySql.Data.MySqlClient;

interface Iconnection
{
    void close();
    void runRawQuery(string query);
}

class MysqlConnectionAdapter : Iconnection
{
    MysqlConnectionAdapter(MySqlConnection connection)
    {
        this.connection = connection;
    }
    
    
    MySqlConnection connection 
    public void close()
    {
        connection.close();
        connection.Dispose();
    }
    public void runRawQuery(string query)
    {
         MySqlCommand cmd = new MySqlCommand(query, connection);
      //if select
        MySqlDataReader rdr = cmd.ExecuteReader();       
      //if insert/update/delete
       cmd.ExecuteNonQuery()
    }
}
