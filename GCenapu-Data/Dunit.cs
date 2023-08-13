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
    public class DUnit : IUnit
    {

        readonly IConfiguration _configuration;
        public DUnit(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public async Task<List<Unit>> List()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Unit> list = new List<Unit>();

                    using (SqlCommand cmd = new SqlCommand("sp_unit_list", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new Unit()
                                {
                                    id=dr.GetInt32("id"),
                                    description = dr.GetString("description"),
                                    
                                    CommonTables = new CommonTables()
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
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public async Task<List<Unit>> ListActive()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Unit> list = new List<Unit>();

                    using (SqlCommand cmd = new SqlCommand("sp_unit_list_actives", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new Unit()
                                {
                                    id = dr.GetInt32("id"),
                                    description = dr.GetString("description"),

                                    CommonTables = new CommonTables()
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
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public async Task<int> Maintenance(RUnitMaintenance unit)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    int insert = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_unit_maintaining", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", unit.id);
                        cmd.Parameters.AddWithValue("@description", unit.description);
                        cmd.Parameters.AddWithValue("@user", unit.user);
                        cmd.Parameters.AddWithValue("@option", unit.option);
                        cn.Open();
                        insert = cmd.ExecuteNonQuery();
                        cn.Close();
                        return insert;

                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        public async Task<List<Unit>> Search(string text)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Unit> list = new List<Unit>();
                    using (SqlCommand cmd = new SqlCommand("sp_unit_search"))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text", text);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new Unit()
                                {
                                    description = dr.GetString("description"),
                                    CommonTables = new CommonTables()
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
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public void prueba()
        {

        }
    }
}
