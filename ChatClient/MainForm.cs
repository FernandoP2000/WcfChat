using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using WcfChat;
using WindowsInput;
using WindowsInput.Native;

namespace ChatClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            lblStatus.Text = "Desconectado";
            ToolTip toolTip = new ToolTip{AutoPopDelay = 5000,InitialDelay = 1000,ReshowDelay = 500,ShowAlways = true};
            toolTip.SetToolTip(button2, "Escribe un usuario en la barra de mensajes");
        }

        private ChannelFactory<IChatService> canalRemoto; //remoteFactory
        private IChatService remoteProxy;
        private ChatUser clientUser;
        private bool isConnected = false;
        private Color Cnombres = Color.Blue;
        private Color Ctexto = Color.Black;
        private Color CmiNombre = Color.DarkGreen;
        private Color CletrasSistema = Color.Black;
        private List<string> ListaPrivados = new List<string>();

        private void LoginMenuSuperior(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Conectando...";
                LoginForm loginDialog = new LoginForm();
                loginDialog.ShowDialog(this);
                if (!String.IsNullOrEmpty(loginDialog.UserName))
                {
                    if (loginDialog.ClavePrivada.Length > 5 && loginDialog.ClavePrivada.StartsWith("C") && loginDialog.ClavePrivada.EndsWith("9"))
                    {   
                        canalRemoto = new ChannelFactory<IChatService>("ChatConfig");
                        remoteProxy = canalRemoto.CreateChannel();
                        clientUser = remoteProxy.ClientConnect(loginDialog.UserName);
                        Cifrado.Clave = loginDialog.ClavePrivada;

                        if (clientUser != null)
                        {
                            usersTimer.Enabled = true;
                            messagesTimer.Enabled = true;
                            LoguearseMenu.Enabled = false;
                            btnSend.Enabled = true;
                            txtMessage.Enabled = true;
                            isConnected = true;
                            SalirMenu.Enabled = true;
                            chatPrivado.Enabled = true;
                            lblStatus.Text = "Conectado como: " + clientUser.UserName;
                            txtMessage.Focus();
                        }
                    }
                    else
                    {
                        lblStatus.Text = "Desconectado";
                        MessageBox.Show("Sesión rechazada");
                    }
                }
                else
                {
                    lblStatus.Text = "Desconectado";
                }            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimerListaUsuarios(object sender, EventArgs e)
        {
            try
            { 
                List<ChatUser> listUsers = remoteProxy.GetAllUsers();
                listBox.Items.Clear();
                foreach (var ej in listUsers)
                {
                    listBox.Items.Add(ej.ToString());
                }
            }
            catch(System.ServiceModel.EndpointNotFoundException)
            {
                MessageBox.Show("El servidor no se encuentra disponible");
            }
        }

        private void BotonEnviar(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMessage.Text) && txtMessage.Text.Length < 8100)
            {
                ChatMessage newMessage = new ChatMessage();
                if (txtChat.Visible == true)
                {
                    newMessage.Date = DateTime.Now;
                    newMessage.Message = Cifrado.CifradoTexto(txtMessage.Text);
                    newMessage.User = clientUser;
                    remoteProxy.SendNewMessage(newMessage);
                    InsertarMensaje(newMessage);
                }
                else
                {
                    if (ListaPrivados.Count > 0)
                    {
                        newMessage.Date = DateTime.Now;
                        newMessage.Message = Cifrado.CifradoTexto($"[Privado]{txtMessage.Text}");
                        newMessage.User = clientUser;
                        remoteProxy.SendNewMessagePrivado(newMessage, ListaPrivados);
                        InsertarMensaje(newMessage);
                    }
                    else
                    {
                        MessageBox.Show("No has añadido ningun usuario");
                    }
                }
                txtMessage.Text = String.Empty;
            }
            else
            {
                if (txtMessage.Text.Length < 8100)
                {
                    MessageBox.Show("Longuitud del mensaje demasiado grande");
                }
            }
        }

        private void TimerMensajes(object sender, EventArgs e)
        {
            try
            {
                List<ChatMessage> messages = remoteProxy.GetNewMessages(clientUser);

                if (messages != null)
                {
                    foreach (var message in messages)
                    {
                        InsertarMensaje(message);
                    }
                }
            }
            catch(System.ServiceModel.EndpointNotFoundException)
            {
                MessageBox.Show("El servidor no se encuentra disponible");
            }
        }

        private string lastuser = "";
        private void InsertarMensaje(ChatMessage message)
        {
            string mensajeDescifrado = Cifrado.DescifradoTexto(message.Message);
            int inicio = 9;
            if (message.User.UserName.Equals(lastuser))
            {
                txtChat.SelectionColor = Ctexto;
                if (txtChatPrivado.Visible && string.IsNullOrEmpty(txtChatPrivado.Text))
                {
                    txtChatPrivado.AppendText($"{message.User}\n");
                }
                if (message.User.UserName.Equals(clientUser.UserName))
                {
                    if (!mensajeDescifrado.Contains("[Privado]"))
                    {
                        txtChat.SelectionColor = CmiNombre;
                    }
                    else
                    {
                        txtChatPrivado.SelectionColor = CmiNombre;
                    }
                }
                if (!mensajeDescifrado.Contains("[Privado]"))
                {
                    txtChat.AppendText($"{mensajeDescifrado}\n");
                }
                else
                {
                    int longuitud = mensajeDescifrado.Length - inicio;
                    txtChatPrivado.AppendText($"{mensajeDescifrado.Substring(inicio, longuitud)}\n");
                }
            }
            else
            {
                if (message.User.UserName.Equals(clientUser.UserName))
                {
                    if (!mensajeDescifrado.Contains("[Privado]"))
                    {
                        txtChat.SelectionColor = CmiNombre;
                        txtChat.AppendText(message.User.UserName); //+ " (" + message.Date + "):"
                    }
                    else
                    {
                        txtChatPrivado.SelectionColor = CmiNombre;
                        int longuitud = mensajeDescifrado.Length - inicio;
                        txtChatPrivado.AppendText($"{mensajeDescifrado.Substring(inicio, longuitud)}\n");
                    }
                }
                else
                {
                    if (!mensajeDescifrado.Contains("[Privado]"))
                    {
                        txtChat.SelectionColor = Cnombres;
                        txtChat.AppendText(message.User.UserName);
                        txtChat.SelectionColor = Ctexto;
                    }
                    else
                    {
                        txtChatPrivado.SelectionColor = Cnombres;
                        int longuitud = mensajeDescifrado.Length - inicio;
                        txtChatPrivado.AppendText($"{mensajeDescifrado.Substring(inicio, longuitud)}\n");
                        txtChatPrivado.SelectionColor = Ctexto;
                    }
                }
                if (!mensajeDescifrado.Contains("[Privado]"))
                {
                    txtChat.AppendText($"\n{mensajeDescifrado} \n");
                }
                else
                {
                    int longuitud = mensajeDescifrado.Length - inicio;
                    txtChatPrivado.AppendText($"{mensajeDescifrado.Substring(inicio, longuitud)}\n");
                }
            }
            lastuser = message.User.UserName;
        }

        private void Desconectando(object sender, FormClosingEventArgs e)
        {
            Desconectar();
        }
        private void Desconectar()
        {
            if (isConnected)
            {
                remoteProxy.SendNewMessage(new ChatMessage()
                {
                    Date = DateTime.Now,
                    Message = "c/ef5hP1nUmtPFG52Br4Vg==",//Despedida
                    User = clientUser
                });
                remoteProxy.RemoveUser(clientUser);
                canalRemoto.Close();
            }
        }
        private void ExitMenuSuperior(object sender, EventArgs e)
        {
            if (isConnected)
            {
                LoguearseMenu.Enabled = true;
                SalirMenu.Enabled = false;
                usersTimer.Enabled = false;
                messagesTimer.Enabled = false;
                btnSend.Enabled = false;
                txtMessage.Enabled = false;
                isConnected = false;
                chatPrivado.Enabled = false;
                Desconectar();
                lblStatus.Text = "Desconectado";
                listBox.Items.Clear();
                txtChat.Text = "";
            }
        }

        private void PresionarTecla(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)       //Enter     
            {
                BotonEnviar(sender, e);
                InputSimulator sim = new InputSimulator();
                sim.Keyboard.KeyPress(VirtualKeyCode.BACK);
            }

            if (e.KeyChar == (char)27)   //Escape
            {
                if (txtChat.Visible == true)
                {
                    txtChat.Text = String.Empty;
                }
                else
                {
                    txtChatPrivado.Text = String.Empty;
                }
            }
        }

        ColorDialog selectorColor = new ColorDialog();
        private void AjustesPaneles(object sender, EventArgs e)
        {
            selectorColor.FullOpen = true;
            selectorColor.AnyColor = true;
            if (selectorColor.ShowDialog() == DialogResult.OK)
            {
                txtChat.BackColor = selectorColor.Color;
                listBox.BackColor = selectorColor.Color;
                txtMessage.BackColor = selectorColor.Color;
            }
        }
        private void ColorNombre(object sender, EventArgs e)
        {
            if (selectorColor.ShowDialog() == DialogResult.OK)
            {
                Cnombres = selectorColor.Color;
            }
        }
        private void ColorTexto(object sender, EventArgs e)
        {
            if (selectorColor.ShowDialog() == DialogResult.OK)
            {
                Ctexto = selectorColor.Color;
            }
        }
        private void ColorMiNombre(object sender, EventArgs e)
        {
            if (selectorColor.ShowDialog() == DialogResult.OK)
            {
                CmiNombre = selectorColor.Color;
            }
        }
        private void ColorFondo(object sender, EventArgs e)
        {
            if (selectorColor.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = selectorColor.Color;
                labelEstado.BackColor = selectorColor.Color;
                menuSuperior.BackColor = selectorColor.Color;
            }
        }
        private void ColorLetrasSistema(object sender, EventArgs e)
        {
            if (selectorColor.ShowDialog() == DialogResult.OK)
            {
                CletrasSistema = selectorColor.Color;
                menuSuperiorInicio.ForeColor = selectorColor.Color;
                menuSuperiorAjustes.ForeColor = selectorColor.Color;
                menuSuperiorChatGeneral.ForeColor = selectorColor.Color;
                menuSuperiorChatPrivado.ForeColor = selectorColor.Color;
                labelEstado.ForeColor = selectorColor.Color;
                txtMessage.ForeColor = selectorColor.Color;
                listBox.ForeColor = selectorColor.Color;
            }
        }

        ToolStripMenuItem menuSuperiorChatGeneral = new System.Windows.Forms.ToolStripMenuItem();
        ToolStripMenuItem menuSuperiorChatPrivado = new System.Windows.Forms.ToolStripMenuItem();
        private void NuevoChatPrivado(object sender, EventArgs e)
        {
            if (menuSuperior.Items.Count == 2)
            {
                menuSuperior.Items.Add(menuSuperiorChatGeneral);
                menuSuperiorChatGeneral.Name = "menuSuperiorChatGeneral";
                menuSuperiorChatGeneral.Size = new System.Drawing.Size(86, 20);
                menuSuperiorChatGeneral.Text = "Chat general";
                menuSuperiorChatGeneral.Click += new System.EventHandler(MostrarGeneral);
                menuSuperior.Items.Add(menuSuperiorChatPrivado);
                menuSuperiorChatPrivado.Name = "menuSuperiorChatPrivado";
                menuSuperiorChatPrivado.Size = new System.Drawing.Size(85, 20);
                menuSuperiorChatPrivado.Text = "Chat privado";
                menuSuperiorChatPrivado.Click += new System.EventHandler(MostrarPrivado);
                menuSuperiorChatGeneral.ForeColor = Color.Green;
                menuSuperiorChatPrivado.ForeColor = CletrasSistema;
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Cerrar el chat privado?", "Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    menuSuperior.Items.Remove(menuSuperiorChatGeneral);
                    menuSuperior.Items.Remove(menuSuperiorChatPrivado);
                    txtChatPrivado.Visible = false;
                    txtChat.Visible = true;
                    listBox.Visible = true;
                    listBoxPrivada.Visible = false;
                    button2.Visible = false;
                }
            }
        }
        private void MostrarGeneral(object sender, EventArgs e)
        {
            txtChatPrivado.Visible = false;
            txtChat.Visible = true;
            listBox.Visible = true;
            listBoxPrivada.Visible = false;
            button2.Visible = false;
            menuSuperiorChatGeneral.ForeColor = Color.Green;
            menuSuperiorChatPrivado.ForeColor = CletrasSistema;
        }
        private void MostrarPrivado(object sender, EventArgs e)
        {
            txtChatPrivado.Visible = true;
            txtChat.Visible = false;
            listBox.Visible = false;
            listBoxPrivada.Visible = true;
            button2.Visible = true;
            menuSuperiorChatGeneral.ForeColor = CletrasSistema;
            menuSuperiorChatPrivado.ForeColor = Color.Green;
        }

        private void BotonAñadir(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtMessage.Text) || String.IsNullOrEmpty(txtMessage.Text))
            {
                txtMessage.Text = "Introduce el nombre del nuevo usuario";
            }
            else
            {
                bool existe = false;
                foreach (var item in listBox.Items)
                {
                    if (txtMessage.Text.Equals(item.ToString()))
                    {
                        existe = true;
                        break;
                    }
                }
                if (existe && !listBoxPrivada.Items.Contains(txtMessage.Text) && !listBoxPrivada.Items.Contains(txtMessage.Text))
                {
                    listBoxPrivada.Items.Add(txtMessage.Text);
                    ListaPrivados.Add(txtMessage.Text);
                    txtMessage.Text = "";
                }
                else if (listBoxPrivada.Items.Contains(txtMessage.Text) || listBoxPrivada.Items.Contains(txtMessage.Text))
                {
                    listBoxPrivada.Items.Remove(txtMessage.Text);
                    ListaPrivados.Remove(txtMessage.Text);
                    txtMessage.Text = "";
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado");
                }
            }
        }

    }
}
