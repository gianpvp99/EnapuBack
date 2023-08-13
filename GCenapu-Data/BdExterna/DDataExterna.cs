using GCenapu_Contracts.BsExterna;
using GCenapu_Entity;
using GCenapu_Entity.BdExterna;
using GCenapu_Entity.common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Data.BdExterna
{
    public class DDataExterna : IDataExterna
    {

        readonly IConfiguration _configuration;
        public DDataExterna(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<EnapuPrincipal_Cliente>> ListCliente(string idTerminal)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<EnapuPrincipal_Cliente> list = new List<EnapuPrincipal_Cliente>();


                    using (SqlCommand cmd = new SqlCommand("EnapuPrincial_List_Cliente", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPuerto", idTerminal);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {   
                            while (dr.Read())
                            {

                                list.Add(new EnapuPrincipal_Cliente()
                                {
                                    id = dr.GetString("id"),
                                    name = dr.GetString("nombre"),

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

        public async Task<List<EnapuPrincipal_Tarifa>> ListTarifa(string idTerminal, string idServicio)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<EnapuPrincipal_Tarifa> list = new List<EnapuPrincipal_Tarifa>();


                    using (SqlCommand cmd = new SqlCommand("EnapuPrincial_List_Tarifa", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPuerto", idTerminal);
                        cmd.Parameters.AddWithValue("@idServicio", @idServicio);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new EnapuPrincipal_Tarifa()
                                {
                                    id = dr.GetString("id"),
                                    description = dr.GetString("descripcion"),
                                    monto = dr.GetDecimal("monto"),
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

        public async Task<List<EnapuPrincipal_TerminalPortuario>> ListTerminal()
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<EnapuPrincipal_TerminalPortuario> list = new List<EnapuPrincipal_TerminalPortuario>();


                    using (SqlCommand cmd = new SqlCommand("EnapuPrincial_List_TerminalPortuario", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new EnapuPrincipal_TerminalPortuario()
                                {
                                    id = dr.GetString("id"),
                                    detalle = dr.GetString("detalle"),
            
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

        public async Task<List<EnapuPrincipal_TipoTarifa>> ListTipoTarifa(string idTerminal)
        {
            using (SqlConnection cn = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    List<EnapuPrincipal_TipoTarifa> list = new List<EnapuPrincipal_TipoTarifa>();


                    using (SqlCommand cmd = new SqlCommand("EnapuPrincipal_List_TipoTarifa", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPuerto", idTerminal);

                        cn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {

                                list.Add(new EnapuPrincipal_TipoTarifa()
                                {
                                    idPuerto = dr.GetString("idPuerto"),
                                    idTipoTarifa = dr.GetString("idTipoTarifa"),
                                    descripcion = dr.GetString("descripcion"),

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
