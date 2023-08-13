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
    public class DPeriod : Iperiod
    {
        readonly IConfiguration _configuration;
        public DPeriod(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Period>> List()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Period> list = new List<Period>();


                    using (SqlCommand cmd = new SqlCommand("sp_period_list", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new Period()
                                {
                                    id=dr.GetInt32("id"),
                                    description = dr.GetString("Description"),
                                    month= dr.GetInt32("month"),
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
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<List<Period>> ListActive()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Period> list = new List<Period>();


                    using (SqlCommand cmd = new SqlCommand("sp_period_list_actives", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new Period()
                                {
                                    id = dr.GetInt32("id"),
                                    description = dr.GetString("Description"),
                                    month = dr.GetInt32("month"),
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
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public async Task<int> Maintenance(RPeriodMaintenance period)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    int num = 0;
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_period_maintaining", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", period.id);
                        cmd.Parameters.AddWithValue("@month", period.month);
                        cmd.Parameters.AddWithValue("@description", period.description);
                        cmd.Parameters.AddWithValue("@user", period.user);
                        cmd.Parameters.AddWithValue("@option", period.option);
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

        public async Task<List<Period>> Search(string text)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Period> list = new List<Period>();


                    using (SqlCommand cmd = new SqlCommand("sp_period_search", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text", text);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new Period()
                                {

                                    description = dr.GetString("Description"),
                                    month = dr.GetInt32("month"),
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
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
