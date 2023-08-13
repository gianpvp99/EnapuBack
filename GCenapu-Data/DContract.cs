using GCenapu_Contracts;
using GCenapu_Entity;
using GCenapu_Entity.common;
using GCenapu_Entity.Request;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Data
{
    public class DContract:IContract
    {
        readonly IConfiguration _configuration;
        public DContract(IConfiguration configuration)
        {
            this._configuration= configuration;
        }

        public async Task<int> Add(RContractMaintenanceAdd contract)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                
                cn.Open();
                
               
                //int idContract;
                //SqlTransaction transaction = cn.BeginTransaction();
                try
                {
                    int num = 1;
                    
                    using (SqlCommand cmd = new SqlCommand("sp_contract_maintaining", cn))
                    {
                        //cmd.Transaction= transaction;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", contract.id);
                        cmd.Parameters.AddWithValue("@idTerminalPortuario", contract.idTerminalPortuario);
                        cmd.Parameters.AddWithValue("@descriptionLong", contract.descriptionLong);
                        cmd.Parameters.AddWithValue("@descriptionShort", contract.descriptionShort);
                        cmd.Parameters.AddWithValue("@idClient", contract.idClient);
                        cmd.Parameters.AddWithValue("@idTypeContract", contract.idTypeContract);
                        cmd.Parameters.AddWithValue("@dateContract", contract.dateContract);
                        cmd.Parameters.AddWithValue("@dateStart", contract.dateStart);
                        cmd.Parameters.AddWithValue("@dateEnd", contract.dateEnd);
                        cmd.Parameters.AddWithValue("@DirectionContract", contract.DirectionContract);
                        cmd.Parameters.AddWithValue("@idUsuario", contract.idUsuario);
                        cmd.Parameters.AddWithValue("@user", contract.user);
                        cmd.Parameters.AddWithValue("@option", 0);
                        cmd.ExecuteNonQuery();
                    }
                    //int idContract;
                    //using (SqlCommand cmd = cn.CreateCommand())
                    //{
                    //    cmd.Transaction = transaction;
                    //    cmd.CommandText = "SELECT SCOPE_IDENTITY()";
                    //    idContract = Convert.ToInt32(cmd.ExecuteScalar());
                    //    idContract=id;
                    //}
                    int idDetailContract = IdEndDetail() != null ? IdEndDetail() + 1 : 1;
                    int idContract = IdEnd() != null ? IdEnd(): 1;
                    foreach (RContractDetailMaintenance detalle in contract.detail)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_detailContract_maintaining", cn))
                        {
                            //cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id",detalle.id);
                            cmd.Parameters.AddWithValue("@idContract", idContract);
                            cmd.Parameters.AddWithValue("@idTarifa", detalle.idTarifa);
                            cmd.Parameters.AddWithValue("@idPeriod", detalle.idPeriod);
                            cmd.Parameters.AddWithValue("@idUnitMeasurement", detalle.idUnitMeasurement);
                            cmd.Parameters.AddWithValue("@periodoMeta", detalle.periodoMeta);
                            cmd.Parameters.AddWithValue("@user", detalle.user);
                            cmd.Parameters.AddWithValue("@option", 0);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd=new SqlCommand("sp_contractPrograming_add", cn))
                        {
                            cmd.CommandType=CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idDetailContract", idDetailContract);
                            cmd.Parameters.AddWithValue("@idTarifa", detalle.idTarifa);
                            cmd.Parameters.AddWithValue("@user", detalle.user);
                            cmd.Parameters.AddWithValue("@idContract", idContract);
                            cmd.ExecuteNonQuery();
                        }
                        idDetailContract++;
                    }
                    //transaction.Commit();
                    foreach (RResponsibleMaintenance _responsible in contract.responsible)
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_responsible_maintaining",cn))
                        {
                            //cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id", _responsible.id);
                            cmd.Parameters.AddWithValue("@idContract", idContract);
                            cmd.Parameters.AddWithValue("@idUser", _responsible.idUser);
                            cmd.Parameters.AddWithValue("@user", _responsible.user);
                            cmd.Parameters.AddWithValue("@option", 0);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    cn.Close();
                   // transaction.Commit();
                    return num;
                }
                 catch (Exception ex)
                {
                    //transaction.Rollback();
                    throw ex;
                }

            }
        }
        public async Task<List<Contract>> List(string idPuerto)
        {
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    cn.Open();
                    using(SqlCommand cmd=new SqlCommand("sp_contract_list",cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPuerto", idPuerto);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            List<Contract> list = new List<Contract>();
                            while (dr.Read())
                            {
                                list.Add(new Contract()
                                {
                                    id = dr.GetInt32("id"),
                                    detailTerminalPortuario=dr.GetString("detailTerminalPortuario"),
                                    descriptionLong = dr.GetString("descriptionLong"),
                                    descriptionShort=dr.GetString("descriptionLong"),
                                    cliente=dr.GetString("nameCliente"),
                                    detailTypeContract =dr.GetString("detailTypeContract"),
                                    dateContract=(dr.GetDateTime("dateContract")).ToString("dd-MM-yyyy"),
                                    dateStart=(dr.GetDateTime("dateStart")).ToString("dd-MM-yyyy"),
                                    dateEnd=(dr.GetDateTime("dateEnd")).ToString("dd-MM-yyyy"),
                                    DirectionContract=dr.GetString("DirectionContract"),
                                    user=dr.GetString("Usuario"),
                                    commonTables=new CommonTables()
                                    {
                                        state=dr.GetBoolean("state"),
                                    }
                                });
                            }
                            cn.Close();
                            return list;
                        }
                    }
                    
                }
                catch (Exception ex) 
                {

                    throw new Exception();
                }
            }
        }
        public async Task<int> Maintenance(RContractMaintenance Contract)
        {
            int num = 0;
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_contract_maintaining", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Contract.id);
                        cmd.Parameters.AddWithValue("@idTerminalPortuario", Contract.idTerminalPortuario);
                        cmd.Parameters.AddWithValue("@descriptionLong", Contract.descriptionLong);
                        cmd.Parameters.AddWithValue("@descriptionShort", Contract.descriptionShort);
                        cmd.Parameters.AddWithValue("@idClient", Contract.idClient);
                        cmd.Parameters.AddWithValue("@idTypeContract", Contract.idTypeContract);
                        cmd.Parameters.AddWithValue("@dateContract", Contract.dateContract);
                        cmd.Parameters.AddWithValue("@dateStart", Contract.dateStart);
                        cmd.Parameters.AddWithValue("@dateEnd", Contract.dateEnd);
                        cmd.Parameters.AddWithValue("@DirectionContract", Contract.DirectionContract);
                        cmd.Parameters.AddWithValue("@idUsuario", Contract.idUsuario);
                        cmd.Parameters.AddWithValue("@user", Contract.user);
                        cmd.Parameters.AddWithValue("@option", Contract.option);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                num = reader.GetInt32("result");
                            }
                            cn.Close();
                            return num;
                        }    
                    }
                }
                catch (Exception ex) 
                {

                    throw new Exception();
                }
                
            }
        }
        public async Task<List<Contract>> Search(string text)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_contract_search", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text",text);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            List<Contract> list = new List<Contract>();
                            while (dr.Read())
                            {
                                list.Add(new Contract()
                                {
                                    id = dr.GetInt32("id"),
                                    detailTerminalPortuario = dr.GetString("detailTerminalPortuario"),
                                    descriptionLong = dr.GetString("descriptionLong"),
                                    descriptionShort = dr.GetString("descriptionLong"),
                                    cliente = dr.GetString("nameCliente"),
                                    detailTypeContract = dr.GetString("detailTypeContract"),
                                    dateContract = (dr.GetDateTime("dateContract")).ToString("dd-MM-yyyy"),
                                    dateStart = (dr.GetDateTime("dateStart")).ToString("dd-MM-yyyy"),
                                    dateEnd = (dr.GetDateTime("dateEnd")).ToString("dd-MM-yyyy"),
                                    DirectionContract = dr.GetString("DirectionContract"),
                                    user = dr.GetString("Usuario")
                                });
                            }
                            cn.Close();
                            return list;
                        }
                    }

                }
                catch (Exception ex)
                {

                    throw new Exception();
                }
            }
        }
        public int IdEnd()
        {
            int numId = 0;
            // sp_Contract_End_id
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_Contract_End_id", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            List<Contract> list = new List<Contract>();
                            if (dr.Read())
                            {
                                numId = dr.GetInt32("id");
                            }
                            return numId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public int IdEndDetail()
        {
            int numId = 0;
            // sp_Contract_End_id
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DetailContract_End_id", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            List<Contract> list = new List<Contract>();
                            if (dr.Read())
                            {
                                numId = dr.GetInt32("id");
                            }
                            return numId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
    
}
