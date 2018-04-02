using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Nutriologos.Models
{
    public class Conexión_Base_de_Datos
    {

        SqlCommand ComandoSQL;
        SqlDataAdapter adaptador;
        DataSet DataSetAdaptador;
        SqlConnection con;
            
        public SqlConnection ConectarBD()
        {
            con = new SqlConnection("Data Source = Santiago-Arjona\\Santiago; Initial Catalog = HealthyFood; Integrated Security = True");
            return con;
        }

        public void AbrirConexion()
        {
            con.Open();
        }

        public void CerrarConexion()
        {
            con.Close();
        }

        //Metodos generales para todo el sistema o proyecto
        public int EjecutarComando(string strComando)
        {
            // INSERT, DELETE, UPDATE
            try
            {
                ComandoSQL = new SqlCommand();
                ComandoSQL.Connection = this.ConectarBD();
                this.AbrirConexion();
                ComandoSQL.CommandText = strComando;
                int id = 0;
                id = ComandoSQL.ExecuteNonQuery();
                this.CerrarConexion();
                return id;
            }
            catch (SqlException)
            {
                return 0;
            }
            finally
            {
                CerrarConexion();
            }
        }

        public int EjecutarComando(SqlCommand SqlComando)
        {
            // INSERT, DELETE, UPDATE
            ComandoSQL = new SqlCommand();
            ComandoSQL = SqlComando;
            ComandoSQL.Connection = this.ConectarBD();
            this.AbrirConexion();
            int id = 0; id = Convert.ToInt32(ComandoSQL.ExecuteScalar());
            this.CerrarConexion();
            return id;
        }

        public DataSet EjecutarSentencia(string Sentencia)
        {
            // SELECT
            ComandoSQL = new SqlCommand();
            adaptador = new SqlDataAdapter();
            ComandoSQL = new SqlCommand();
            DataSetAdaptador = new DataSet();
            String strComandoSQL = Sentencia;
            ComandoSQL.CommandText = strComandoSQL;

            ComandoSQL.Connection = this.ConectarBD();
            this.AbrirConexion();

            adaptador.SelectCommand = ComandoSQL;
            adaptador.Fill(DataSetAdaptador);
            return DataSetAdaptador;
        }

        public DataSet EjecutarSentencia(SqlCommand SqlComando)
        {
            adaptador = new SqlDataAdapter();
            ComandoSQL = new SqlCommand();
            DataSetAdaptador = new DataSet();

            ComandoSQL = SqlComando;
            ComandoSQL.Connection = this.ConectarBD();
            this.AbrirConexion();
            adaptador.SelectCommand = ComandoSQL;
            adaptador.Fill(DataSetAdaptador);
            this.CerrarConexion();
            return DataSetAdaptador;
        }

        public DataTable Tabla_Consultada(string Sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(Sql, ConectarBD());
            AbrirConexion();
            DataTable Tabla_Virtual = new DataTable();
            CerrarConexion();
            adapter.Fill(Tabla_Virtual);
            return Tabla_Virtual;
        }

    }
}