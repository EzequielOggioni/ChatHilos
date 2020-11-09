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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
           Usuario user = DB.validaUsuario(txtUser.Text,txtPass.Text);
            if (!(user is null))
            {
                FrmPrincipal frmPrincipal = new FrmPrincipal(user);
                frmPrincipal.Show();
            }


        }
    }
}
