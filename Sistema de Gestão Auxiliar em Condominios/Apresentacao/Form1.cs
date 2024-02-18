using System.Drawing.Drawing2D;
using Sistema_de_Gestão_Auxiliar_em_Condominios.Modelo;

namespace Sistema_de_Gestão_Auxiliar_em_Condominios
{

    public partial class Form1 : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        System.Windows.Forms.Timer timer1;

        public Form1()
        {
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += timer1_Tick;
            this.FormBorderStyle = FormBorderStyle.None; // Opcional: para um formulario sem bordas
            RoundCorners();
            InitializeComponent();

        }
        private void DraggableForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Define a altura da área arrastavel para o topo do formulário
            int dragAreaHeight = 30;
            // Checa se o mouse está acompanhando a área arrastavel
            if (e.Y <= dragAreaHeight)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }

        }

        // Atualiza a posição do formulário enquanto ele está sendo arrastado pelo usuário
        private void DraggableForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint)); // Calcula a diferença entre a posição atual do cursor e a posição do cursor quando o arraste começou
                this.Location = Point.Add(dragFormPoint, new Size(dif)); // Move o formulário da posição anterior para a nova posição armazenada em 'dif'
            }
        }

        // Define dragging para false para indicar que a ação de arrastar não está sendo feita
        private void DraggableForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // Deixa o formulário com as bordas redondas 
        private void RoundCorners()
        {
            Rectangle Bounds = new Rectangle(0, 0, this.Width, this.Height);
            int cornerRadius = 30; // Define o quão redondo as bordas estão, coloque o valor que desejar
            GraphicsPath path = new GraphicsPath();

            path.AddArc(Bounds.X, Bounds.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - cornerRadius, Bounds.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - cornerRadius, Bounds.Y + Bounds.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RoundCorners();
        }

        // Botão de minimizar
        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Animação para caso o programa feche
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0)
            {
                this.Opacity -= 0.965;
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }

        // Botão de sair 
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        // Carrega o icone de entrar quando é pressionado
        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox5.Load(@"..\..\..\Resources\enter_480pxorange.png");
            pictureBox5.Size = new Size(48, 48);
        }

        // Carrega o icone de entrar quando não está sendo pressionado
        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox5.Load(@"..\..\..\Resources\enter_480px.png");
            pictureBox5.Size = new Size(50, 50);

        }

        // Coleta os dados das caixas de textos e retorna o status de login quando clicado
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Controle controle = new Controle();
            controle.acessar(textBox1.Text, textBox2.Text);
            if (controle.mensagem.Equals(""))
            {
                if (controle.tem)
                {
                    MessageBox.Show("Logado com sucesso", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Login ou senha estão incorretos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }
            
    }
}
