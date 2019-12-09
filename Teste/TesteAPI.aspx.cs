using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using static ObjetoDistanciaGoogle;

public partial class TesteAPI : System.Web.UI.Page
{
    protected void Page_Load (object sender, EventArgs e)
    {

        

    }




    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        pesquisaAmigosProximos();

    }

    public void pesquisaAmigosProximos()
    {
        string destinations = "";
        string origins = "";
        string jsonDadosAmigos = "";
        string jsonDistanciaAmigos = "";

        Amigos meuGeoPosicionamento = new Amigos();
        List<Amigos> listaAmigosGeoPosicionamento = new List<Amigos>();
        AmigosServices dal = new AmigosServices();

        try
        {
            
            jsonDadosAmigos = dal.retornaDadosAmigos();

            
            listaAmigosGeoPosicionamento = dal.ConverteJSonParaObjectAmigos<List<Amigos>>(jsonDadosAmigos);
            destinations = retornadDestinations(listaAmigosGeoPosicionamento);
            origins = txtLatitude.Text + "," + txtLongitude.Text;

            
            jsonDistanciaAmigos = dal.retornaDistanciaAmigos(origins, destinations);
            JObject dados = JObject.Parse(jsonDistanciaAmigos);
            var serializer = new JavaScriptSerializer();
            var Red = serializer.Deserialize<ObjetoDistanciaGoogle.RootObject>(dados.ToString());
            Red.ToString();
            Red.rows[0].elements[0].distance.text.ToString();
            Red.rows[0].elements[0].duration.text.ToString();

            for (int contador = 0; contador < Red.rows[0].elements.Count(); contador++)
            {
                listaAmigosGeoPosicionamento[contador].endereco = Red.destination_addresses[contador].ToString();
                listaAmigosGeoPosicionamento[contador].distancia = Red.rows[0].elements[contador].distance.text.ToString();
                listaAmigosGeoPosicionamento[contador].vl_distancia = Red.rows[0].elements[contador].distance.value;
                listaAmigosGeoPosicionamento[contador].tempo = Red.rows[0].elements[contador].duration.text.ToString();               
            }
            listaAmigosGeoPosicionamento = listaAmigosGeoPosicionamento.OrderBy(x => x.vl_distancia).ToList();

            if (listaAmigosGeoPosicionamento.Exists(p => p.latitude == txtLatitude.Text && p.longitude == txtLongitude.Text))
            {
                Amigos a = listaAmigosGeoPosicionamento.Find(p => p.latitude == txtLatitude.Text && p.longitude == txtLongitude.Text);
                listaAmigosGeoPosicionamento.Remove(a);
            }

            Amigos amigo = new Amigos();
            amigo.nome = "Minha Localização";
            amigo.latitude = txtLatitude.Text;
            amigo.longitude = txtLongitude.Text;

            listaAmigosGeoPosicionamento.Add(amigo);
            gerarArquivoJson(listaAmigosGeoPosicionamento);



        }

        catch (Exception ex)
        {
            throw new Exception("Problema no Servidor" + ex.Message);
        }

    }

    public string retornadDestinations(List<Amigos> listaAmigosGeoPosicionamento)
    {
        string destinations = "";
        foreach (Amigos amigos in listaAmigosGeoPosicionamento)
        {
            destinations += "|" + amigos.latitude + "," + amigos.longitude;
        }
        return destinations;
    }

    public void gerarArquivoJson(List<Amigos> dados)
    {
        var javaScriptSerializer = new JavaScriptSerializer();
        List<Amigos> top3 = new List<Amigos>();
        top3.Add(dados[0]);
        top3.Add(dados[1]);
        top3.Add(dados[2]);
        top3.Add(dados[dados.Count-1]);
        //top3 = dados;
        var emp = top3;
        
        var jsonSerializado = javaScriptSerializer.Serialize(emp);

        var xmlSerializer = new XmlSerializer(emp.GetType());
        xmlSerializer.Serialize(Console.Out, emp);

        string path = @"c:/Teste/Teste/Content/arquivoTeste.json";
        File.WriteAllText(path, jsonSerializado);

        //File.WriteAllText("../../Users/Sebek/Source/Repos/Teste/Teste/Content/arquivoTeste1.json", jsonSerializado);
    }

}