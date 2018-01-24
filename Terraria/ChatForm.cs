using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Terraria
{
	public class ChatForm : Form
	{
		private Button btn_Send;

		private IContainer components;

		private TextBox tb_chat;

		public static KeyboardState keyState = Keyboard.GetState();

		public ChatForm()
		{
			this.InitializeComponent();
			Main.isChatFormOpen = true;
		}

		private void btn_Send_Click(object sender, EventArgs e)
		{
			string text = this.tb_chat.Text.Trim();
			if (!string.IsNullOrEmpty(text))
			{
				text = text.Replace('\r', '\0').Replace('\n', '\0');
				while (Main.fontMouseText.MeasureString(text).X > 470f)
				{
					text = text.Substring(0, text.Length - 1);
				}
				NetMessage.SendData(25, -1, -1, text, Main.myPlayer, 0f, 0f, 0f, 0);
				Main.PlaySound(11, -1, -1, 1);
				this.tb_chat.Text = "";
			}
			Main.chatMode = false;
			Main.chatRelease = false;
			base.Dispose();
		}

		private void tb_chat_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyValue == 13)
			{
				string text = this.tb_chat.Text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					text = text.Replace('\r', '\0').Replace('\n', '\0');
					while (Main.fontMouseText.MeasureString(text).X > 470f)
					{
						text = text.Substring(0, text.Length - 1);
					}
					NetMessage.SendData(25, -1, -1, text, Main.myPlayer, 0f, 0f, 0f, 0);
					Main.PlaySound(11, -1, -1, 1);
					this.tb_chat.Text = "";
				}
				Main.chatMode = false;
				Main.chatRelease = false;
				base.Dispose();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
			Main.isChatFormOpen = false;
		}

		private void InitializeComponent()
		{
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(ChatForm));
			this.tb_chat = new TextBox();
			this.btn_Send = new Button();
			base.SuspendLayout();
			this.tb_chat.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
			this.tb_chat.Location = new Point(12, 12);
			this.tb_chat.Multiline = true;
			this.tb_chat.Name = "tb_chat";
			this.tb_chat.Size = new Size(320, 118);
			this.tb_chat.TabIndex = 0;
			if (Main.SetWindowPos_X >= 0 && Main.SetWindowPos_Y >= 0)
			{
				base.StartPosition = FormStartPosition.Manual;
				base.SetDesktopLocation(Main.SetWindowPos_X, Main.SetWindowPos_Y);
			}
			else
			{
				base.StartPosition = FormStartPosition.CenterScreen;
			}
			this.btn_Send.Anchor = AnchorStyles.Bottom;
			this.btn_Send.Location = new Point(129, 136);
			this.btn_Send.Name = "btn_Send";
			this.btn_Send.Size = new Size(149, 23);
			this.btn_Send.TabIndex = 1;
			this.btn_Send.Text = "点击发送或敲回车关闭";
			this.btn_Send.UseVisualStyleBackColor = true;
			this.btn_Send.Click += new EventHandler(this.btn_Send_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(344, 162);
			base.Controls.Add(this.btn_Send);
			base.Controls.Add(this.tb_chat);
			base.Name = "ChatForm";
			this.Text = "快捷中文聊天窗口(可关闭)";
			base.ResumeLayout(false);
			base.PerformLayout();
			this.tb_chat.KeyDown += new KeyEventHandler(this.tb_chat_KeyDown);
		}
	}
}
