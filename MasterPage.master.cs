using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadLinks();
    }
    private void LoadLinks()
    {
        string query = "SELECT COUNT(ID) FROM Articles";
        var myConnection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        myConnection.Open();
        SqlCommand myCommand = new SqlCommand(query, myConnection);
        SqlDataReader dr = myCommand.ExecuteReader();
        dr.Read();
        int Pages = (int)Math.Ceiling((int)dr[0] / 7.0);
        for (int i = 0; i < Pages; i++)
        {
            var ctrl = (HyperLinkUserControl)LoadControl("Client_User_Controls/HyperLinkUserControl.ascx");
            ctrl.Text = (i + 1).ToString();
            ctrl.Url = "Index.aspx?Page=" + (i + 1);
            ctrl.Id = "link" + i;
            LinksPH.Controls.Add(ctrl);
        }
    }
}
