using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;




/// <summary>
/// Descrição resumida de API
/// </summary>
/// 

public class API
    {
    public API()
    {

    }
    string route = "http://localhost:60864/api/";

        public String ConsultaAmigosProximos()
        {
            String str_uri = route + "/amigos/GetBuscaAmigos/";
            String retorno = string.Empty;
            try
            {
                var parametros = new Dictionary<string, string>();
                parametros.Add("login", "empty");

                HttpWebRequest htpReq = (HttpWebRequest)WebRequest.Create(str_uri);
                HttpWebResponse httpWebReponse = (HttpWebResponse)htpReq.GetResponse();
                StreamReader reader = new StreamReader(httpWebReponse.GetResponseStream());

                var objText = reader.ReadToEnd();

                retorno = objText.ToString();
                reader.Dispose();
                httpWebReponse.Dispose();
                reader.Close();
                httpWebReponse.Close();
            }
            catch (Exception ex)
            {
                retorno = ex.Message;
            }


            return retorno;

        }

    }
