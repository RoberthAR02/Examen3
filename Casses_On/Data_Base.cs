using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
namespace Examen3
{
    public class Data_Base
    {
        public static int insertarFormulario(string nombre, int edad, string correo, int partido)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Plug_In.getConnection())
                {
                    SqlCommand cmd = new SqlCommand("AGREGAR_FORMULARIO", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@EDAD", edad));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", correo));
                    cmd.Parameters.Add(new SqlParameter("@PARTIDO", partido));

                    ret = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Plug_In.closeConnection(cnx);
            }

            return ret;
        }

        public static int consultarFormulario(GridView dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Plug_In.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_TODOS_FORMULARIO", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                Plug_In.closeConnection(cnx);
            }

            return ret;
        }

        public static int ConsultarPartidos(DropDownList dg)
        {
            int ret = 0;

            SqlConnection cnx = new SqlConnection();
            try
            {
                using (cnx = Plug_In.getConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("CONSULTAR_PARTIDOS", cnx)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                dg.DataSource = dt;

                                dg.DataTextField = dt.Columns["Nombre"].ToString();
                                dg.DataValueField = dt.Columns["IDPartido"].ToString();
                                dg.DataBind();

                                ret = cmd.ExecuteNonQuery();
                            }
                        }
                    }


                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                ret = -1;
            }
            finally
            {
                    Plug_In.closeConnection(cnx);
            }

            return ret;
        }
    }
}