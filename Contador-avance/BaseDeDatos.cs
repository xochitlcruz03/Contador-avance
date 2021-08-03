using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Contador_avance
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Contador_avance.Properties.Settings.SysContableConnectionString"].ConnectionString;
            cn.Open();
            return cn;
        }
    }
}
