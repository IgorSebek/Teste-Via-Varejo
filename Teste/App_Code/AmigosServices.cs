using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using static ObjetoDistanciaGoogle;

/// <summary>
/// Descrição resumida de tst1
/// </summary>
public class AmigosServices
{
    
    public string retornaDadosAmigos()
    {
        string route = "http://localhost:60864/api/";
        String str_uri = route + "/amigos/GetGeoPosicionamentoAmigos/";
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

    public string retornaDistanciaAmigos(string origins,string destinations)
    {


        string route = "https://maps.googleapis.com/maps/api/distancematrix/json?units=metric&origins=" + origins+ "&destinations="+destinations +"&key=AIzaSyCuXvjawu_ZKLXdLJdRy9Kn0zdF6j73BaQ";
        
        String str_uri = route;
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

    public List<Amigos> ConverteJSonParaObjectAmigos<T>(string jsonString)
    {
        try
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Amigos>));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            List<Amigos> amigo = (List<Amigos>)serializer.ReadObject(ms);
            return amigo;
        }
        catch
        {
            throw;
        }
    }
    public List<ObjetoDistanciaGoogle> ConverteJSonParaObjectDistanciaGoogle<T>(string jsonString)
    {
        try
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<ObjetoDistanciaGoogle>));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            List<ObjetoDistanciaGoogle> dados = (List<ObjetoDistanciaGoogle>)serializer.ReadObject(ms);
            return dados;
        }
        catch
        {
            throw;
        }
    }
    public List<Element> ConverteJSonParaObjectElements<T>(string jsonString)
    {
        try
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Element>));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            List<Element> dados = (List<Element>)serializer.ReadObject(ms);
            return dados;
        }
        catch
        {
            throw;
        }
    }

}