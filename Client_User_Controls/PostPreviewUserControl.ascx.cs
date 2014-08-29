using System;
using System.Collections.Generic;
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

    }
}