namespace SistemaAcademicoPUC
{
    public partial class TelaLogin : Form
    {
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void usernameInput_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Favor preencher todos os campos!");
                return;
            }
        }

        private void showPass_CheckChanged(object sender, EventArgs e)
        {
            passwordInput.UseSystemPasswordChar = !showPass.Checked;
        }
    }
}