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
using static System.Net.Mime.MediaTypeNames;

namespace GCenapu_Data
{
    public class DUnitMeasurement : IunitMeasurement
    {
        readonly IConfiguration _configuration;
        public DUnitMeasurement(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public async Task<List<UnitMeasurement>> List()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<UnitMeasurement> list = new List<UnitMeasurement>();

                    using (SqlCommand cmd = new SqlCommand("sp_unitMeasurement_list", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new UnitMeasurement()
                                {
                                    description = dr.GetString("description"),
                                    unitDescription=dr.GetString("unitDescription"),
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

        public async Task<int> Maintenance(RUnitMeasurementMaintenance unitMeasurement)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    int insert = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_unitMeasurement_maintaining", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", unitMeasurement.id);
                        cmd.Parameters.AddWithValue("@idunit", unitMeasurement.idUnit);
                        cmd.Parameters.AddWithValue("@description", unitMeasurement.description);
                        cmd.Parameters.AddWithValue("@user", unitMeasurement.user);
                        cmd.Parameters.AddWithValue("@option", unitMeasurement.option);
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

        public async Task<List<UnitMeasurement>> Search(string text)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<UnitMeasurement> list = new List<UnitMeasurement>();

                    using (SqlCommand cmd = new SqlCommand("sp_unitMeasurement_search", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text", text);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new UnitMeasurement()
                                {
                                    
                                    description = dr.GetString("description"),
                                    unitDescription = dr.GetString("unitDescription"),
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

        public async Task<List<UnitMeasurement>> Search(int id)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<UnitMeasurement> list = new List<UnitMeasurement>();

                    using (SqlCommand cmd = new SqlCommand("sp_unitMeasurement_search_id_unit", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new UnitMeasurement()
                                {
                                    id=dr.GetInt32("id"),
                                    description = dr.GetString("unidadMedida"),
                                    unitDescription = dr.GetString("unidad"),
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
    }
}
