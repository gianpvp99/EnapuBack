using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCenapu_Contracts;
using GCenapu_Entity;
using System.Data.SqlClient;
using System.Data;
using GCenapu_Entity.common;
using GCenapu_Entity.Request;

namespace GCenapu_Data
{

    public class DTypeContract:ITypeContracts
    {
        readonly IConfiguration _configuration;
        public DTypeContract(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<TypeContract>>List()
        {
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))     
            {
                try
                {
                    List<TypeContract> list = new List<TypeContract>();
                   

                    using (SqlCommand cmd = new SqlCommand("sp_typeContract_list",cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new TypeContract()
                                {
                                    id=dr.GetInt32("id"),
                                    typeContract = dr.GetString("TypeContract"),
                                    description = dr.GetString("Description"),
                                    commonTables = new CommonTables()
                                    {
                                        state = dr.GetBoolean("state")
                                    }

                                });
                            }
                        }
                        cn.Close();
                        return list;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<List<TypeContract>> ListActive()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<TypeContract> list = new List<TypeContract>();


                    using (SqlCommand cmd = new SqlCommand("sp_typeContract_list_actives", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new TypeContract()
                                {
                                    id = dr.GetInt32("id"),
                                    typeContract = dr.GetString("TypeContract"),
                                    description = dr.GetString("Description"),
                                    commonTables = new CommonTables()
                                    {
                                        state = dr.GetBoolean("state")
                                    }

                                });
                            }
                        }
                        cn.Close();
                        return list;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<int> Maintenance(RTypeContractMaintenance typeContract)
        {
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {

                    int num = 0;
                    cn.Open();
                    using (SqlCommand cmd=new SqlCommand("sp_typeContract_maintaining",cn))
                    {
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id",typeContract.id);
                        cmd.Parameters.AddWithValue("@typeContract",typeContract.typeContract);
                        cmd.Parameters.AddWithValue("@description",typeContract.description);
                        cmd.Parameters.AddWithValue("@user",typeContract.user);
                        cmd.Parameters.AddWithValue("@option",typeContract.option);
                       

                        num=cmd.ExecuteNonQuery();
                        cn.Close();
                        return num;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public async Task<List<TypeContract>> Search(string text)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<TypeContract> list = new List<TypeContract>();


                    using (SqlCommand cmd = new SqlCommand("sp_typeContract_search", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text", text);
                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new TypeContract()
                                {
                                    typeContract = dr.GetString("TypeContract"),
                                    description = dr.GetString("Description"),
                                    commonTables = new CommonTables()
                                    {
                                        state = dr.GetBoolean("state")
                                    }

                                });
                            }

                        }
                        cn.Close();
                        return list;
                        
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

