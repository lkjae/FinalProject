using Renci.SshNet;

namespace SImple_SSH
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            sshClient();


        }

        private void sshClient()
        {
            var ci = new ConnectionInfo("192.168.58.254",
                                        "ips", 
                                        new PasswordAuthenticationMethod("ips", "ips123"));

            using var sshCli = new SshClient(ci);
            sshCli.Connect();

            var output = sshCli.CreateCommand("ifconfig").Execute();
            textBox1.Text = output;

            using (SshCommand cmd = sshCli.CreateCommand("cat .profile"))
            {
                output = cmd.Execute();
                textBox2.Text = $"ExitStatus: {cmd.ExitStatus}";

                textBox3.Text = output;
            } 


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);    
            
        }

    }
}
