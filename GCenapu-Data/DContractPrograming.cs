using GCenapu_Contracts;
using GCenapu_Entity;
using GCenapu_Entity.common;
using GCenapu_Entity.Request;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GCenapu_Data
{
    public class DContractPrograming : IContractPrograming
    {
        readonly IConfiguration _configuration;

        public DContractPrograming(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ContractPrograming>> List()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<ContractPrograming> list = new List<ContractPrograming>();
                    using (SqlCommand cmd = new SqlCommand("sp_contractPrograming_list", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new ContractPrograming
                                {
                                    id = dr.GetInt32("id"),
                                    idDetailContract = dr.GetInt32("idDetailContract"),
                                    descriptionTarifa = dr.GetString("descripcion"),
                                    month = dr.GetDecimal("monto"),
                                    dateStart = (dr.GetDateTime("dateStart")).ToString("dd-MM-yyyy"),
                                    dateEnd = (dr.GetDateTime("dateEnd")).ToString("dd-MM-yyyy"),
                                    cantFacture = dr.GetDecimal("cantFacture"),
                                    commonTables = new CommonTables()
                                    {
                                        state = dr.GetBoolean("state")
                                    }
                                });
                            }
                        }
                    }
                    cn.Close();
                    return list;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        public async Task<List<ContractPrograming>> ListDestail(int id)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<ContractPrograming> list = new List<ContractPrograming>();
                    using (SqlCommand cmd = new SqlCommand("sp_contractPrograming_list_id", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new ContractPrograming
                                {
                                    id = dr.GetInt32("id"),
                                    idDetailContract = dr.GetInt32("idDetailContract"),
                                    descriptionTarifa = dr.GetString("tarifaDescripcionShort"),
                                    amounth= dr.GetDecimal("monto"),
                                    month = dr.GetDecimal("mountPrograming"),
                                    dateStart = (dr.GetDateTime("dateStart")).ToString("dd-MM-yyyy"),
                                    dateEnd = (dr.GetDateTime("dateEnd")).ToString("dd-MM-yyyy"),
                                    cantFacture = dr.GetDecimal("cantFacture"),
                                    cantOfMeta = dr.GetDecimal("cantofmeta"),
                                    
                                    commonTables = new CommonTables()
                                    {
                                        state = dr.GetBoolean("state")
                                    }
                                });
                            }
                        }
                    }
                    cn.Close();
                    return list;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }



        public async Task<int> Maintenance(RContractProgramingMaintenance contractPrograming)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    int num = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_contractPrograming_maintaining"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", contractPrograming.id);
                        cmd.Parameters.AddWithValue("@idDetailContract", contractPrograming.idDetailContract);
                        cmd.Parameters.AddWithValue("@idTarifa", contractPrograming.idTarifa);
                        cmd.Parameters.AddWithValue("@month", contractPrograming.month);
                        cmd.Parameters.AddWithValue("@dateStart", contractPrograming.dateStart);
                        cmd.Parameters.AddWithValue("@dateEnd", contractPrograming.dateEnd);
                        cmd.Parameters.AddWithValue("@cantFacture", contractPrograming.cantFacture);
                        cmd.Parameters.AddWithValue("@user", contractPrograming.user);
                        cmd.Parameters.AddWithValue("@option", contractPrograming.option);
                        cn.Open();
                        num = cmd.ExecuteNonQuery();
                        cn.Close();
                        return num;

                    }
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public async Task<List<ContractPrograming>> Search(string text)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<ContractPrograming> list = new List<ContractPrograming>();
                    using (SqlCommand cmd = new SqlCommand("sp_contractPrograming_search", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text", text);
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new ContractPrograming
                                {
                                    id = dr.GetInt32("id"),
                                    idDetailContract = dr.GetInt32("idDetailContracts"),
                                    descriptionTarifa = dr.GetString("descriptionTarifa"),
                                    month = dr.GetDecimal("monto"),
                                    dateStart = (dr.GetDateTime("dateStart")).ToString("dd-MM-yyyy"),
                                    dateEnd = (dr.GetDateTime("dateEnd")).ToString("dd-MM-yyyy"),
                                    cantFacture = dr.GetDecimal("cantFacture"),
                                    commonTables = new CommonTables()
                                    {
                                        state = dr.GetBoolean("state")
                                    }
                                });
                            }
                        }
                    }
                    cn.Close();
                    return list;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<int> UpdateCantofMeta(int idContractPrograming, decimal cantOfmeta)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    int num = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_contractPrograming_updateCantOfMeta",cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", idContractPrograming);
                        cmd.Parameters.AddWithValue("@cantOfMeta", cantOfmeta);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                num = dr.GetInt32("result");
                            }
                        }
                        cn.Close();
                        return num;

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
