using GCenapu_Contracts;
using GCenapu_Entity;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCenapu_Entity.common;
using GCenapu_Entity.Request;

namespace GCenapu_Data
{
    public  class DRole:IRole
    {

        readonly IConfiguration _configuration;
        public DRole(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        public async Task<List<Role>> list()
        {
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Role>list=new List<Role>();

                    using (SqlCommand cmd=new SqlCommand("sp_role_list", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new Role()

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

        public async Task<List<Role>> listActive()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Role> list = new List<Role>();

                    using (SqlCommand cmd = new SqlCommand("sp_role_list_actives", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new Role()

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

        public async Task<int> Maintenance(RRoleMaintenance role)
        {
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    int insert = 0;
                    using (SqlCommand cmd = new SqlCommand("sp_role_maintaining", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", role.id);
                        cmd.Parameters.AddWithValue("@description", role.description);
                        cmd.Parameters.AddWithValue("@user", role.user);
                        cmd.Parameters.AddWithValue("@option", role.option); 
                        cn.Open() ;
                        insert = cmd.ExecuteNonQuery();
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

        public async Task<List<Role>> Search(string text)
        {
            using (SqlConnection cn=new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<Role> list = new List<Role>();
                    using (SqlCommand cmd=new SqlCommand("sp_role_search"))
                    {
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@text", text);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new Role()
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
    }
}
