namespace ChatClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelEstado = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuSuperior = new System.Windows.Forms.MenuStrip();
            this.menuSuperiorInicio = new System.Windows.Forms.ToolStripMenuItem();
            this.LoguearseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.chatPrivado = new System.Windows.Forms.ToolStripMenuItem();
            this.SalirMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSuperiorAjustes = new System.Windows.Forms.ToolStripMenuItem();
            this.panelChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorNombreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fondoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelChatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.colorTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.letrasDelSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox = new System.Windows.Forms.ListBox();
            this.txtChat = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.usersTimer = new System.Windows.Forms.Timer(this.components);
            this.messagesTimer = new System.Windows.Forms.Timer(this.components);
            this.txtChatPrivado = new System.Windows.Forms.RichTextBox();
            this.listBoxPrivada = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.labelEstado.SuspendLayout();
            this.menuSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEstado
            // 
            this.labelEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.labelEstado.Location = new System.Drawing.Point(0, 324);
            this.labelEstado.Name = "labelEstado";
            this.labelEstado.Size = new System.Drawing.Size(668, 22);
            this.labelEstado.TabIndex = 0;
            this.labelEstado.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 17);
            this.lblStatus.Text = "statusLabel";
            // 
            // menuSuperior
            // 
            this.menuSuperior.BackColor = System.Drawing.SystemColors.Control;
            this.menuSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSuperiorInicio,
            this.menuSuperiorAjustes});
            this.menuSuperior.Location = new System.Drawing.Point(0, 0);
            this.menuSuperior.Name = "menuSuperior";
            this.menuSuperior.Size = new System.Drawing.Size(668, 24);
            this.menuSuperior.TabIndex = 1;
            this.menuSuperior.Text = "menuStrip1";
            // 
            // menuSuperiorInicio
            // 
            this.menuSuperiorInicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoguearseMenu,
            this.chatPrivado,
            this.SalirMenu});
            this.menuSuperiorInicio.Name = "menuSuperiorInicio";
            this.menuSuperiorInicio.Size = new System.Drawing.Size(48, 20);
            this.menuSuperiorInicio.Text = "Inicio";
            // 
            // LoguearseMenu
            // 
            this.LoguearseMenu.Name = "LoguearseMenu";
            this.LoguearseMenu.Size = new System.Drawing.Size(142, 22);
            this.LoguearseMenu.Text = "Loguearse";
            this.LoguearseMenu.Click += new System.EventHandler(this.LoginMenuSuperior);
            // 
            // chatPrivado
            // 
            this.chatPrivado.Enabled = false;
            this.chatPrivado.Name = "chatPrivado";
            this.chatPrivado.Size = new System.Drawing.Size(142, 22);
            this.chatPrivado.Text = "Chat Privado";
            this.chatPrivado.Click += new System.EventHandler(this.NuevoChatPrivado);
            // 
            // SalirMenu
            // 
            this.SalirMenu.Enabled = false;
            this.SalirMenu.Name = "SalirMenu";
            this.SalirMenu.Size = new System.Drawing.Size(142, 22);
            this.SalirMenu.Text = "Salir";
            this.SalirMenu.Click += new System.EventHandler(this.ExitMenuSuperior);
            // 
            // menuSuperiorAjustes
            // 
            this.menuSuperiorAjustes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.panelChatToolStripMenuItem});
            this.menuSuperiorAjustes.Name = "menuSuperiorAjustes";
            this.menuSuperiorAjustes.Size = new System.Drawing.Size(57, 20);
            this.menuSuperiorAjustes.Text = "Ajustes";
            // 
            // panelChatToolStripMenuItem
            // 
            this.panelChatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNombreToolStripMenuItem,
            this.colorNombreToolStripMenuItem1,
            this.fondoToolStripMenuItem,
            this.panelChatToolStripMenuItem1,
            this.colorTextToolStripMenuItem,
            this.letrasDelSistemaToolStripMenuItem});
            this.panelChatToolStripMenuItem.Name = "panelChatToolStripMenuItem";
            this.panelChatToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.panelChatToolStripMenuItem.Text = "Colores";
            // 
            // miNombreToolStripMenuItem
            // 
            this.miNombreToolStripMenuItem.Name = "miNombreToolStripMenuItem";
            this.miNombreToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.miNombreToolStripMenuItem.Text = "Mi nombre";
            this.miNombreToolStripMenuItem.Click += new System.EventHandler(this.ColorMiNombre);
            // 
            // colorNombreToolStripMenuItem1
            // 
            this.colorNombreToolStripMenuItem1.Name = "colorNombreToolStripMenuItem1";
            this.colorNombreToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.colorNombreToolStripMenuItem1.Text = "Usuarios";
            this.colorNombreToolStripMenuItem1.Click += new System.EventHandler(this.ColorNombre);
            // 
            // fondoToolStripMenuItem
            // 
            this.fondoToolStripMenuItem.Name = "fondoToolStripMenuItem";
            this.fondoToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.fondoToolStripMenuItem.Text = "Fondo";
            this.fondoToolStripMenuItem.Click += new System.EventHandler(this.ColorFondo);
            // 
            // panelChatToolStripMenuItem1
            // 
            this.panelChatToolStripMenuItem1.Name = "panelChatToolStripMenuItem1";
            this.panelChatToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.panelChatToolStripMenuItem1.Text = "Paneles";
            this.panelChatToolStripMenuItem1.Click += new System.EventHandler(this.AjustesPaneles);
            // 
            // colorTextToolStripMenuItem
            // 
            this.colorTextToolStripMenuItem.Name = "colorTextToolStripMenuItem";
            this.colorTextToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.colorTextToolStripMenuItem.Text = "Color texto";
            this.colorTextToolStripMenuItem.Click += new System.EventHandler(this.ColorTexto);
            // 
            // letrasDelSistemaToolStripMenuItem
            // 
            this.letrasDelSistemaToolStripMenuItem.Name = "letrasDelSistemaToolStripMenuItem";
            this.letrasDelSistemaToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.letrasDelSistemaToolStripMenuItem.Text = "Letras del sistema";
            this.letrasDelSistemaToolStripMenuItem.Click += new System.EventHandler(this.ColorLetrasSistema);
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(527, 27);
            this.listBox.Name = "listBox";
            this.listBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox.Size = new System.Drawing.Size(129, 251);
            this.listBox.TabIndex = 2;
            // 
            // txtChat
            // 
            this.txtChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChat.BackColor = System.Drawing.Color.White;
            this.txtChat.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(12, 27);
            this.txtChat.Name = "txtChat";
            this.txtChat.ReadOnly = true;
            this.txtChat.Size = new System.Drawing.Size(509, 251);
            this.txtChat.TabIndex = 3;
            this.txtChat.Text = "";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(527, 284);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(129, 37);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Enviar";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.BotonEnviar);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage.Enabled = false;
            this.txtMessage.Location = new System.Drawing.Point(12, 284);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(509, 36);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PresionarTecla);
            // 
            // usersTimer
            // 
            this.usersTimer.Interval = 5000;
            this.usersTimer.Tick += new System.EventHandler(this.TimerListaUsuarios);
            // 
            // messagesTimer
            // 
            this.messagesTimer.Interval = 500;
            this.messagesTimer.Tick += new System.EventHandler(this.TimerMensajes);
            // 
            // txtChatPrivado
            // 
            this.txtChatPrivado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChatPrivado.BackColor = System.Drawing.Color.LightGray;
            this.txtChatPrivado.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChatPrivado.Location = new System.Drawing.Point(12, 27);
            this.txtChatPrivado.Name = "txtChatPrivado";
            this.txtChatPrivado.ReadOnly = true;
            this.txtChatPrivado.Size = new System.Drawing.Size(509, 251);
            this.txtChatPrivado.TabIndex = 6;
            this.txtChatPrivado.Text = "";
            this.txtChatPrivado.Visible = false;
            // 
            // listBoxPrivada
            // 
            this.listBoxPrivada.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxPrivada.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.listBoxPrivada.FormattingEnabled = true;
            this.listBoxPrivada.Location = new System.Drawing.Point(527, 27);
            this.listBoxPrivada.Name = "listBoxPrivada";
            this.listBoxPrivada.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxPrivada.Size = new System.Drawing.Size(129, 212);
            this.listBoxPrivada.TabIndex = 7;
            this.listBoxPrivada.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(527, 241);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 37);
            this.button2.TabIndex = 8;
            this.button2.Text = "Añadir/Eleminar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.BotonAñadir);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 346);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBoxPrivada);
            this.Controls.Add(this.txtChatPrivado);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.labelEstado);
            this.Controls.Add(this.menuSuperior);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuSuperior;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Cifrado WCF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Desconectando);
            this.labelEstado.ResumeLayout(false);
            this.labelEstado.PerformLayout();
            this.menuSuperior.ResumeLayout(false);
            this.menuSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip labelEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.MenuStrip menuSuperior;
        private System.Windows.Forms.ToolStripMenuItem menuSuperiorInicio;
        private System.Windows.Forms.ToolStripMenuItem SalirMenu;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.RichTextBox txtChat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.ToolStripMenuItem LoguearseMenu;
        private System.Windows.Forms.Timer usersTimer;
        private System.Windows.Forms.Timer messagesTimer;
        private System.Windows.Forms.ToolStripMenuItem menuSuperiorAjustes;
        private System.Windows.Forms.ToolStripMenuItem panelChatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panelChatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem colorNombreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem colorTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chatPrivado;
        private System.Windows.Forms.ToolStripMenuItem fondoToolStripMenuItem;
        private System.Windows.Forms.RichTextBox txtChatPrivado;
        private System.Windows.Forms.ListBox listBoxPrivada;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem letrasDelSistemaToolStripMenuItem;
    }
}

