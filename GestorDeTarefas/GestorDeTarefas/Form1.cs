namespace GestorDeTarefas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //método que é corrido ao clicar no botão "Adicionar"
        private void botaoAdicionar_Click(object sender, EventArgs e)
        {
            string tarefa = textBoxAdicionar.Text;
            if (!string.IsNullOrEmpty(tarefa))
            {
                tarefas.Items.Add(tarefa);
                textBoxAdicionar.Clear();
            }
        }
    }
}
