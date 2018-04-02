using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nutriologos.Recursos_BO.BO_Inicio;
using System.Data.SqlClient;
using System.Data;
using Nutriologos.Recursos_BO.Bo_Admin;

namespace Nutriologos.Models
{
    public class Login
    {

        Conexión_Base_de_Datos con = new Conexión_Base_de_Datos();
        private String hashkey = "*hg849gh84th==3tg7-534d=_";
        Encryptar Encryp = new Encryptar();

        public DataTable Inicio_sesion(string Usuario, string Contraseña)
        {
            con.ConectarBD();
            con.AbrirConexion();
            SqlCommand cmd = new SqlCommand("select Id, Usuario, Contraseña, Id_Tipo from Usuarios where Usuario ='" + Usuario + "' AND Contraseña = '" + Contraseña + "' ");
            cmd.Connection = con.ConectarBD();
            cmd.Parameters.AddWithValue("Usuario", Usuario);
            string sHA = Encryp.CreateSHAHash(Contraseña, hashkey);
            string contra = Encryp.Encriptar(Contraseña);
            cmd.Parameters.AddWithValue("Contraseña", contra);
            cmd.Parameters.AddWithValue("SHA512", sHA);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);



            return dt;

        }

        public bool VereficarUsuarios(UsuariosBO obj)
        {
            string sql = "select Id, Usuario, Contraseña, Id_Tipo from Usuarios";
            bool bandera = false;
            DataTable tabla = con.Tabla_Consultada(sql);
            int tope = tabla.Rows.Count;
            int i = 0;


            do
            {

                if (tabla.Rows[i][0].ToString() != obj.Usuario && tabla.Rows[i][1].ToString() != obj.Nombre)
                {
                    i++;
                    bandera = true;
                }
                else
                {
                    bandera = false;
                    i = tope;
                }


            } while (i != tope);



            return bandera;
        }


    }
}