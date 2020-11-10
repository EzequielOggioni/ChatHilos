using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatUI
{
    public partial class FrmPrincipal : Form
    {
        private Usuario userLog;
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
            List<Mensaje> mensajes = DB.TraerMensajes(this.userLog, DB.TraesPersonas());
            this.txtMensajes.Text = "";
            foreach (Mensaje item in mensajes)
            {
                this.txtMensajes.Text += item.persona.Nombre + " " + item.TextoMensaje + "\n";
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            DB.InsertarMensaje(this.userLog, (Persona)cmbPersonas.SelectedItem, this.txtEnviar.Text);
        }
    }
}
