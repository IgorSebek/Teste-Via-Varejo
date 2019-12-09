<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TesteAPI.aspx.cs" Inherits="TesteAPI" %>

<!DOCTYPE html>
<html>
<head>
    <title>Simple Map</title>
    <meta name="viewport" content="initial-scale=1.0">
    <meta charset="utf-8">
    <style>
        #map {
            height: 80%;
            width:100%;
            border-radius: 10px;

        }

        html {
            height: 100%;
            width: 50%;
            margin: 0;
            padding-left: 10%;
            padding-right: 25%; 
            
            background-image: url("/imagens/telaPrincipal.jpg");
        }

         body {
            height: 100%;
            width: 100%;
            padding-left: 25%;
            padding-right: 25%; 
                        
        }
    </style>
</head>
<body>

<form runat="server">

    
          <table runat="server" height="80px">
        <tr>
            <td>
                <asp:Label runat="server" Text="Latitude" Font-Bold="true" Font-Size="20px"></asp:Label>
                <br />
                <asp:TextBox ID="txtLatitude" runat="server" Width="100px" Height="20px"></asp:TextBox>
            </td>

            <td>
                <asp:Label runat="server" Text="Longitude" Font-Bold="true" Font-Size="20px"></asp:Label>
                <br />
                <asp:TextBox ID="txtLongitude" runat="server" Width="100px" Height="20px"></asp:TextBox>
            </td>
                <td>
                    <br />
                   <asp:Button runat="server" ID="btnPesquisar" Width="80px" OnClick="btnPesquisar_Click" Text="Buscar" Height="25px" /> 
                </td>

        </tr>

    </table>
        </form>

        <div id="map" runat="server"></div>




<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.3/jquery.min.js" type="text/javascript"></script>

    <script >

        var map;
        function initMap() {
            map = new google.maps.Map(document.getElementById('map'), {
                center: { lat: -23.679999, lng: -46.573805 },
                zoom: 12,
                
            });

            carregarPontos();
        }

        function carregarPontos() {
            var amigos = new Object();
            amigos.nome ="";
            amigos.latitude=0 ;
            amigos.longitude = 0;
            amigos.endereco = "";
            amigos.distancia = "";
            amigos.tempo = "";

            $.getJSON('Content/arquivoTeste.json', function (amigos) {

                
                $.each(amigos, function (index, amigo) {
                    //alert(index);
                    if (index == 3) {

                        var marker = new google.maps.Marker({
                            position: new google.maps.LatLng(amigo.latitude, amigo.longitude),
                            title: amigo.nome,
                            map: map,
                        });

                    }
                    else {

                        var marker = new google.maps.Marker({
                            position: new google.maps.LatLng(amigo.latitude, amigo.longitude),
                            title: amigo.nome+" ("+amigo.distancia+")",
                            map: map,

                            icon: 'imagens/amigos.png'

                        });

                    }
                });
            });

        }

        //carregarPontos();
    </script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCuXvjawu_ZKLXdLJdRy9Kn0zdF6j73BaQ&callback=initMap"
        async defer></script>
    
    
</body>


    
</html>
