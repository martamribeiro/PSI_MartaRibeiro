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

        private void botaoApagar_Click(object sender, EventArgs e)
        {
            if (tarefas.SelectedItem != null)
            {
                tarefas.Items.Remove(tarefas.SelectedItem);
            }
        }

        private void botaoCompletar_Click(object sender, EventArgs e)
        {
            if(tarefas.SelectedItem != null)
            {
                int indice = tarefas.SelectedIndex;
                string tarefaCompleta = tarefas.SelectedItem.ToString() + " ✅";
                tarefas.Items[indice] = tarefaCompleta;
            }
        }
    }
}
