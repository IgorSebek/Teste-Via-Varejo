using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de LoginDAL
/// </summary>
public class LoginDAL
{
    String conexao = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;

    public LoginDAL()
    {

    }
    public int retornaStatusToken(string usuario, string senha)
    {
        int retorno = 0;
        SqlConnection conn = new SqlConnection(conexao);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        conn.Open();

        string sql = @"exec sp_valida_login @usuario,@senha,@opcao";
        cmd.Parameters.AddWithValue("@usuario", usuario);
        cmd.Parameters.AddWithValue("@senha", senha);
        cmd.Parameters.AddWithValue("@opcao", 1);

        cmd.CommandText = sql;
        Amigos amigos = new Amigos();

        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            retorno = Convert.ToInt32(dr["liberado"]);

        }

        return retorno;
    }

}