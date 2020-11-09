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
    }
}
