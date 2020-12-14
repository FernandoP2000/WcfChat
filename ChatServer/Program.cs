using System;
using System.ServiceModel;
using System.Security.Principal;
using WcfChat;
using System.Windows.Forms;

namespace ChatServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();

            if (obj.IsCurrentlyRunningAsAdmin())
                obj.RunServer();
            else
                MessageBox.Show("¿Lo has avierto como Administrador?", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void RunServer()
        {
            using (ServiceHost host = new ServiceHost(typeof(ChatService)))
            {
                host.Open();
                Console.WriteLine("Servidor iniciado\n");
                Console.WriteLine(" Nombre de configuracion:   " + host.Description.ConfigurationName);
                Console.WriteLine(" Dirección del punto final: " + host.Description.Endpoints[0].Address);
                Console.WriteLine(" Enlace de punto final:     " + host.Description.Endpoints[0].Binding.Name);
                Console.WriteLine(" Contrato de punto final:   " + host.Description.Endpoints[0].Contract.ConfigurationName);
                Console.WriteLine(" Nombre del punto final:    " + host.Description.Endpoints[0].Name);
                Console.WriteLine(" Punto final leer uri:      " + host.Description.Endpoints[0].ListenUri);
                Console.WriteLine(" \n Nombre:                    " + host.Description.Name);
                Console.WriteLine(" Espacio de nombres:        " + host.Description.Namespace);
                Console.WriteLine(" Tipo de Servicio:          " + host.Description.ServiceType);

                Console.ReadLine();
                host.Close();
            }
        }
        private bool IsCurrentlyRunningAsAdmin()
        {
            bool isAdmin = false;
            WindowsIdentity currentIdentity = WindowsIdentity.GetCurrent();
            if (currentIdentity != null)
            {
                WindowsPrincipal pricipal = new WindowsPrincipal(currentIdentity);
                isAdmin = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
                pricipal = null;
            }
            return isAdmin;
        }
    }
}
