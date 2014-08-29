using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HyperLinkUserControl : System.Web.UI.UserControl
{
    public string Url { get; set; }
    public string Text { get; set; }
    public string Id { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
}