using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio.Core.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Infraestructura.Data.SQLServer
{
    public class Curso_I
    {
        SqlConnection conexion;
        SqlDataAdapter comando;
        SqlDataReader dr;
        SqlCommand cmd;
        String errores;

        Conexion cn = new Conexion();

        public IEnumerable<Curso> ListarCursos() {
            List<Curso> lista = new List<Curso>();
            try
            {
                conexion = cn.Conectar();
                cmd = new SqlCommand("PR_LISTAR_CURSOS", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                dr = null;
                conexion.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Curso objeto = new Curso();

                    objeto.codigo_c = Convert.ToInt32(dr["codigo_c"]);
                    objeto.nombre_c = Convert.ToString(dr["nombre_c"]);
                    objeto.correo_c = Convert.ToString(dr["correo_c"]);
                    objeto.credito_c = Convert.ToInt32(dr["credito_c"]);
                    lista.Add(objeto);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                errores = ex.Message;
            }
            finally {
                if (conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
                conexion.Dispose();
                cmd.Dispose();
            }
            return lista;
        }

        public Boolean RegistrarCurso(Curso objeto) {
            try
            {
                conexion = cn.Conectar();
                cmd = new SqlCommand("PR_REGISTRA_CURSO", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@C_NOMBRE", SqlDbType.VarChar, 100));
                cmd.Parameters["@C_NOMBRE"].Direction = ParameterDirection.Input;
                cmd.Parameters["@C_NOMBRE"].Value = objeto.nombre_c;

                cmd.Parameters.Add(new SqlParameter("@C_EMAIL_CURSO", SqlDbType.VarChar, 100));
                cmd.Parameters["@C_EMAIL_CURSO"].Direction = ParameterDirection.Input;
                cmd.Parameters["@C_EMAIL_CURSO"].Value = objeto.correo_c;

                cmd.Parameters.Add(new SqlParameter("@C_CREDITOS", SqlDbType.VarChar, 100));
                cmd.Parameters["@C_CREDITOS"].Direction = ParameterDirection.Input;
                cmd.Parameters["@C_CREDITOS"].Value = objeto.credito_c;

                conexion.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                errores = ex.Message;
                return false;
            }

            finally {
                if (conexion.State == ConnectionState.Open) {
                    conexion.Close();
                }
                conexion = null;
                cmd = null;
                cn = null;
            }

        }
    }
}
