using GCenapu_Contracts;
using GCenapu_Entity;
using GCenapu_Entity.common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCenapu_Entity.Request;

namespace GCenapu_Data
{
    public class DContractDetail : IContractDetail
    {
        readonly IConfiguration _configuration;

        public DContractDetail(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<ContractDetail>> List()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<ContractDetail> list = new List<ContractDetail>();
                    using (SqlCommand cmd = new SqlCommand("sp_detailContract_list", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new ContractDetail
                                {
                                    id = dr.GetInt32("id"),
                                    contractDescriptionLong = dr.GetString("contractDescriptionLong"),
                                    contractDescriptionShort = dr.GetString("contractDescriptionShort"),
                                    tarifaDescription = dr.GetString("tarifaDescription"),
                                    tarifaAmount = dr.GetDecimal("tarifaAmount"),
                                    periodDescription = dr.GetString("periodDescription"),
                                    periodMonth = dr.GetInt32("month"),
                                    unitMeasurementDescription = dr.GetString("unitMeasurementDescription"),
                                    unitDescription = dr.GetString("unitDescription"),
                                    periodoMeta = dr.GetDecimal("periodoMeta"),
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
        public async Task<List<ContractDetail>> ListIdContract( int id)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<ContractDetail> list = new List<ContractDetail>();
                    using (SqlCommand cmd = new SqlCommand("sp_detailContract_list_id", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idContract", id);
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new ContractDetail
                                {
                                    id = dr.GetInt32("id"),
                                    contractDescriptionLong = dr.GetString("contractDescriptionLong"),
                                    idContract=dr.GetInt32("idContrato"),
                                    dateStart= (dr.GetDateTime("dateStart")).ToString("dd-MM-yyyy"),
                                    dateEnd = (dr.GetDateTime("dateEnd")).ToString("dd-MM-yyyy"),
                                    contractDescriptionShort = dr.GetString("contractDescriptionShort"),
                                    tarifaDescription = dr.GetString("tarifaDescription"),
                                    tarifaAmount = dr.GetDecimal("tarifaAmount"),
                                    periodDescription = dr.GetString("periodDescription"),
                                    periodMonth = dr.GetInt32("month"),
                                    unitMeasurementDescription = dr.GetString("unitMeasurementDescription"),
                                    unitDescription = dr.GetString("unitDescription"),
                                    periodoMeta = dr.GetDecimal("periodoMeta"),
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
        public async Task<int> Maintenance(RContractDetailMaintenance contractDetail)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    int num = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_detailContract_maintaining", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", contractDetail.id);
                        cmd.Parameters.AddWithValue("@idContract", contractDetail.idContract);
                        cmd.Parameters.AddWithValue("@idTarifa", contractDetail.idTarifa);
                        cmd.Parameters.AddWithValue("@idPeriod", contractDetail.idPeriod);
                        cmd.Parameters.AddWithValue("@idUnitMeasurement", contractDetail.idUnitMeasurement);
                        cmd.Parameters.AddWithValue("@periodoMeta", contractDetail.periodoMeta);
                        cmd.Parameters.AddWithValue("@user", contractDetail.user);
                        cmd.Parameters.AddWithValue("@option", contractDetail.option);

                        cn.Open();
                        using (SqlDataReader dr =cmd.ExecuteReader())
                            if (dr.Read())
                            {
                                 num =dr.GetInt32("result"); 
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
        public async Task<List<ContractDetail>> Search(string text)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<ContractDetail> list = new List<ContractDetail>();
                    using (SqlCommand cmd = new SqlCommand("sp_contractDetail_search", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text", text);
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new ContractDetail
                                {
                                    id = dr.GetInt32("id"),
                                    contractDescriptionLong = dr.GetString("contractDescriptionLong"),
                                    contractDescriptionShort = dr.GetString("contractDescriptionShort"),
                                    tarifaDescription = dr.GetString("tarifaDescription"),
                                    tarifaAmount = dr.GetDecimal("tarifaAmount"),
                                    periodDescription = dr.GetString("periodDescription"),
                                    periodMonth = dr.GetInt32("periodMonth"),
                                    unitMeasurementDescription = dr.GetString("unitMeasurementDescription"),
                                    unitDescription = dr.GetString("unitDescription"),
                                    periodoMeta = dr.GetDecimal("periodoMeta"),
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
    }
}
