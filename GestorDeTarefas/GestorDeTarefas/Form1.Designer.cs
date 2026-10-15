namespace GestorDeTarefas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titulo = new Label();
            textBoxAdicionar = new TextBox();
            botaoAdicionar = new Button();
            tarefas = new ListBox();
            botaoCompletar = new Button();
            botaoApagar = new Button();
            SuspendLayout();
            // 
            // titulo
            // 
            titulo.AutoSize = true;
            titulo.Font = new Font("Gill Sans Ultra Bold", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            titulo.ForeColor = SystemColors.ButtonFace;
            titulo.Location = new Point(201, 22);
            titulo.Name = "titulo";
            titulo.Size = new Size(392, 48);
            titulo.TabIndex = 0;
            titulo.Text = "Gestor de Tarefas";
            // 
            // textBoxAdicionar
            // 
            textBoxAdicionar.Location = new Point(86, 90);
            textBoxAdicionar.Name = "textBoxAdicionar";
            textBoxAdicionar.Size = new Size(507, 27);
            textBoxAdicionar.TabIndex = 1;
            // 
            // botaoAdicionar
            // 
            botaoAdicionar.Location = new Point(627, 90);
            botaoAdicionar.Name = "botaoAdicionar";
            botaoAdicionar.Size = new Size(94, 29);
            botaoAdicionar.TabIndex = 2;
            botaoAdicionar.Text = "Adicionar";
            botaoAdicionar.UseVisualStyleBackColor = true;
            botaoAdicionar.Click += botaoAdicionar_Click;
            // 
            // tarefas
            // 
            tarefas.FormattingEnabled = true;
            tarefas.Location = new Point(86, 145);
            tarefas.Name = "tarefas";
            tarefas.Size = new Size(635, 204);
            tarefas.TabIndex = 3;
            // 
            // botaoCompletar
            // 
            botaoCompletar.Location = new Point(228, 378);
            botaoCompletar.Name = "botaoCompletar";
            botaoCompletar.Size = new Size(94, 29);
            botaoCompletar.TabIndex = 4;
            botaoCompletar.Text = "Completar";
            botaoCompletar.UseVisualStyleBackColor = true;
            botaoCompletar.Click += botaoCompletar_Click;
            // 
            // botaoApagar
            // 
            botaoApagar.Location = new Point(477, 378);
            botaoApagar.Name = "botaoApagar";
            botaoApagar.Size = new Size(94, 29);
            botaoApagar.TabIndex = 5;
            botaoApagar.Text = "Apagar";
            botaoApagar.UseVisualStyleBackColor = true;
            botaoApagar.Click += botaoApagar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(800, 450);
            Controls.Add(botaoApagar);
            Controls.Add(botaoCompletar);
            Controls.Add(tarefas);
            Controls.Add(botaoAdicionar);
            Controls.Add(textBoxAdicionar);
            Controls.Add(titulo);
            Name = "Form1";
            Text = "Gestor de Tarefas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titulo;
        private TextBox textBoxAdicionar;
        private Button botaoAdicionar;
        private ListBox tarefas;
        private Button botaoCompletar;
        private Button botaoApagar;
    }
}
