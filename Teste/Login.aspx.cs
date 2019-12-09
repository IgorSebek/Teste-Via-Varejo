using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        LoginDAL dal = new LoginDAL();

        if(dal.retornaStatusToken(txtLogin.Text, txtSenha.Text)==1){
            Session["usuario"] = txtLogin.Text;
            Response.Redirect("TesteAPI.aspx");
        }
        else
        {
            Response.Write("<Script>alert('Login Invalido')</Script>");
        }
    }
}