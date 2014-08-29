using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    public int CurentPage = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPostsPreview(CurentPage);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Page">Номер страницы с превьюшками(по 7 на страничке)</param>
    private void LoadPostsPreview(int Page)
    {
        string query = "SELECT Date, Text, Title, ID FROM Articles";
        var myConnection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        myConnection.Open();
        SqlCommand myCommand = new SqlCommand(query, myConnection);
        SqlDataReader dr = myCommand.ExecuteReader();

        for (int i = 1; dr.Read(); i++)
        {
            var ctrl = (PostPreviewUserControl)LoadControl("Client_User_Controls/PostPreviewUserControl.ascx");
            ctrl.Date = (DateTime)dr[0];
            ctrl.Text = ((string)dr[1]).Remove(200) + "...";//Обрезаем текст превьюшки и добавляем ... =)
            ctrl.Title = (string)dr[2];
            ctrl.Id = (int)dr[3];
            if (i > (CurentPage - 1) * 7 && i <= CurentPage * 7)
                PostsPH.Controls.Add(ctrl);
        }
    }

    protected override void OnPreInit(EventArgs e)
    {
        if (Request["Page"] != null)
            Int32.TryParse(Request["Page"], out CurentPage);
        base.OnPreInit(e);
    }
}