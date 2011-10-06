using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Messages;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Global.Bus.Send<RequestWithResponse>(m => m.SaySomething = TextBox1.Text)
                .RegisterWebCallback<int>(i => Label1.Text = i.ToString(),null);
        }
    }
}
