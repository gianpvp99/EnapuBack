using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Data.Dcommons
{
    //MEJORAS PARA LA CAPA DATA
    public class Dcommons
    {
        readonly IConfiguration _configuration;
        public Dcommons(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<object> DbQuery(string con,string proc)
        {
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString(con)))
            {
                try
                {
                    List<object> list = new List<object>(); 
                    using (SqlCommand cmd=new SqlCommand(proc, cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataReader dr=cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                
                            }
                        }
                        return list;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

    }
}
