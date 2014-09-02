using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PostPreviewUserControl : System.Web.UI.UserControl
{
    public string Text { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public int Id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (contentPHText != null)
            contentPHText.Controls.Add(ParseControl(Text));
        PostName.Text = Title;
        PostDate.Text = Date.ToShortDateString();
        PreRender += PostPreviewUserControl_PreRender;
    }

    void PostPreviewUserControl_PreRender(object sender, EventArgs e)
    {
        StatMess.Text += LoadStatisticsDB("MessagesCount");
        StatViews.Text += LoadStatisticsDB("ViewsCount");
    }
    public string LoadStatisticsDB(string column)
    {

        string query = "SELECT " + column + " FROM [Statistics] WHERE (ArcticleID = " + Id + ")";
        var myConnection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        myConnection.Open();
        SqlCommand myCommand = new SqlCommand(query, myConnection);
        SqlDataReader dr = myCommand.ExecuteReader();
        dr.Read();
        try
        {
            return dr[column].ToString();
        }
        catch (Exception)
        {
            return "0";
        }
    }

}