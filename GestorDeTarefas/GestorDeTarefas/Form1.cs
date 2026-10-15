namespace GestorDeTarefas
{
    public partial class Form1 : Form
    {

        string ficheiroTarefas = "tarefas.txt";

        public Form1()
        {
            InitializeComponent();
            ImportarTarefas();
        }

        //método que é corrido ao clicar no botão "Adicionar"
        private void botaoAdicionar_Click(object sender, EventArgs e)
        {
            string tarefa = textBoxAdicionar.Text;
            if (!string.IsNullOrEmpty(tarefa))
            {
                tarefas.Items.Add(tarefa);
                textBoxAdicionar.Clear();
                GuardarTarefas();
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
                GuardarTarefas();
            }
        }


        void ImportarTarefas()
        { 
            if (!File.Exists(ficheiroTarefas))
            {
                File.Create(ficheiroTarefas).Close();
            }
            else
            {
                string[] linhas = File.ReadAllLines(ficheiroTarefas);
                foreach (string linha in linhas)
                {
                    tarefas.Items.Add(linha);
                }
            }
        }

        void GuardarTarefas()
        {
            File.WriteAllLines(ficheiroTarefas, tarefas.Items.Cast<string>());
        }
    }
}
