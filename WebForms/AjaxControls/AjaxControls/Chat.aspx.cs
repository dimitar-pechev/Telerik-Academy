using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AjaxControls
{
    public partial class Chat : System.Web.UI.Page
    {
        private const string CookieUsername = "Username";
        private ChatDbEntities db = new ChatDbEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            var messages = this.db.Messages.OrderBy(m => m.PostedOn).ToList();
            messages.Reverse();

            this.ListViewMessages.DataSource = messages;
            this.ListViewMessages.DataBind();

            if (this.Request.Cookies.AllKeys.Contains(CookieUsername))
            {
                this.Credentials.Visible = false;
                this.ChatPanel.Visible = true;
                this.ChatMessage.Focus();
            }
            else
            {
                this.Credentials.Visible = true;
                this.ChatPanel.Visible = false;
            }
        }

        protected void BtnSubmitUsername_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.Username.Text.Trim()))
            {
                return;
            }

            this.Response.Cookies.Add(new HttpCookie(CookieUsername, this.Username.Text.Trim()));

            this.Credentials.Visible = false;
            this.ChatPanel.Visible = true;
        }

        protected void ChatMessage_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.ChatMessage.Text.Trim()))
            {
                return;
            }

            var message = new Message()
            {
                Author = this.Request.Cookies[CookieUsername].Value,
                PostedOn = DateTime.Now,
                MessageContent = this.ChatMessage.Text.Trim()
            };
            this.db.Messages.Add(message);
            this.db.SaveChanges();

            this.ChatMessage.Text = string.Empty;
            var messages = this.db.Messages.OrderBy(m => m.PostedOn).ToList();
            messages.Reverse();
            this.ListViewMessages.DataSource = messages;
            this.ListViewMessages.DataBind();
            this.ChatMessage.Focus();
        }

        protected void BtnSignOut_Click(object sender, EventArgs e)
        {
            this.Response.Cookies[CookieUsername].Expires = DateTime.Now.AddDays(-1);
            this.Response.Redirect("Chat.aspx");
        }
    }
}