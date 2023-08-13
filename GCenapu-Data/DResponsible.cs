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
    public class DResponsible : IResponsible
    {
        readonly IConfiguration _configuration;
        public DResponsible(IConfiguration configuration) { 
            _configuration = configuration;
        
        }
        public async Task<List<Responsible>> List()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Responsible> list = new List<Responsible>();
                    using (SqlCommand cmd = new SqlCommand("sp_responsible_list", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new Responsible()
                                {
                                    id = dr.GetInt32("id"),
                                    name = dr.GetString("name"),
                                    email = dr.GetString("email"),
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

        public async Task<List<Responsible>> List(int idContract)
        {
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Responsible> list = new List<Responsible>();
                    using (SqlCommand cmd=new SqlCommand("sp_responsible_list_idContract", cn))
                    {
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idContract", idContract);
                        cn.Open();
                        using (SqlDataReader dr=cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new Responsible()
                                {
                                    id = dr.GetInt32("id"),
                                    name = dr.GetString("name"),
                                    email = dr.GetString("email"),
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

        public async Task<int> Maintenance(RResponsibleMaintenance responsible)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    int insert = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_responsible_maintaining", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", responsible.id);
                        cmd.Parameters.AddWithValue("@idContract", responsible.idContract);
                        cmd.Parameters.AddWithValue("@idUser", responsible.idUser);
                        cmd.Parameters.AddWithValue("@user", responsible.user);
                        cmd.Parameters.AddWithValue("@option", responsible.option);
                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                insert = dr.GetInt32("result");
                            }
                        }

                        cn.Close();
                        return insert;

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<List<Responsible>> Search(string text)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Responsible> list = new List<Responsible>();


                    using (SqlCommand cmd = new SqlCommand("sp_responsible_search", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text", text);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new Responsible()
                                {

                                    id = dr.GetInt32("id"),
                                    name = dr.GetString("name"),
                                    email = dr.GetString("email"),
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
