using System.Drawing.Drawing2D;
using System.Drawing;
using Microsoft.VisualBasic.ApplicationServices;
using Sistema_de_Gestão_Auxiliar_em_Condominios.Modelo;
using Microsoft.VisualBasic;

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
            InitializeComponent();
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += timer1_Tick;
            this.FormBorderStyle = FormBorderStyle.None; // Optional: for a borderless form
            RoundCorners();

        }
        private void DraggableForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Define the height of the draggable area at the top of the form
            int dragAreaHeight = 30;
            // Check if the mouse is within the draggable area
            if (e.Y <= dragAreaHeight)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }

        }
        private void DraggableForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void DraggableForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        private void RoundCorners()
        {
            Rectangle Bounds = new Rectangle(0, 0, this.Width, this.Height);
            int cornerRadius = 30; // Set this to the desired value
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


        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

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

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox5.Load("C:\\Users\\jeanl\\Downloads\\enter_480pxorange.png");
            pictureBox5.Size = new Size(48, 48);
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox5.Load("C:\\Users\\jeanl\\Downloads\\enter_480px.png");
            pictureBox5.Size = new Size(50, 50);

        }

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
