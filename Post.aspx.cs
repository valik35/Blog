using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Post : System.Web.UI.Page
{
    private int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPost(id);
    }
    protected override void OnPreInit(EventArgs e)
    {
        if (Request["Post"] != null)
            Int32.TryParse(Request["Post"], out id);
        base.OnPreInit(e);
    }
    private void LoadPost(int id)
    {
        string query = "SELECT Date, Text, Title, ID FROM Articles WHERE ID=" + id;
        var myConnection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        myConnection.Open();
        SqlCommand myCommand = new SqlCommand(query, myConnection);
        SqlDataReader dr = myCommand.ExecuteReader();

        for (int i = 1; dr.Read(); i++)
        {
            var ctrl = (PostUserControl)LoadControl("Client_User_Controls/PostUserControl.ascx");
            ctrl.Date = (DateTime)dr[0];
            ctrl.Text = ((string) dr[1]);
            ctrl.Title = (string)dr[2];
            ctrl.Id = (int)dr[3];
            PostsPH.Controls.Add(ctrl);
        }
    }
}