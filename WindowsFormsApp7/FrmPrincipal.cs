using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUI
{
    public partial class FrmPrincipal : Form
    {
        private Usuario userLog;
        private  Thread t;
        public FrmPrincipal(Usuario user)
        {
            InitializeComponent();
            userLog = user;
            lblBienvenido.Text = $"Bienvenido {user.Nombre} {user.Apellido}"; 
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.cmbPersonas.DataSource = DB.TraesPersonas();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if(t is null)
            {
                this.t = new Thread(new ParameterizedThreadStart(refrescarMensajes));
                 t.Start(5000);
            }
            else if (t.IsAlive)
            {
                t.Abort();
                t = new Thread(new ParameterizedThreadStart(refrescarMensajes));
                t.Start(3000);
            }
        }

        public void refrescarMensajes(object segundos)
        {
            List<Mensaje> mensajes = DB.TraerMensajes(this.userLog, DB.TraesPersonas());
            if(this.txtMensajes.InvokeRequired)
            {
                this.txtMensajes.BeginInvoke((MethodInvoker)delegate(){
                    this.txtMensajes.Text = "";
                    foreach (Mensaje item in mensajes)
                    {
                        this.txtMensajes.Text += item.persona.ToString() + " " + item.TextoMensaje + "\n";
                    }
                });
            }else
            {
                this.txtMensajes.Text = "";
                foreach (Mensaje item in mensajes)
                {
                    this.txtMensajes.Text += item.persona.ToString() + " " + item.TextoMensaje + "\n";
                }
            }    



            Thread.Sleep((int)segundos);
            refrescarMensajes(segundos);
        }

        public void escrbirEnTxt()
        {

        } 
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            DB.InsertarMensaje(this.userLog, (Persona)cmbPersonas.SelectedItem, this.txtEnviar.Text);
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!(t is null) && t.IsAlive)
                t.Abort();
        }
    }
}
