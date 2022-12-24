using Business.Models;
using Business.Services;

namespace TresCamadas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario();
            usuario.Nome = txtNome.Text;
            usuario.Telefone = txtTelefone.Text;
            usuario.CPF = txtCPF.Text;

            new UsuarioService().Gravar(usuario);

            MessageBox.Show("Cadastrado com sucesso!");
        }
    }
}