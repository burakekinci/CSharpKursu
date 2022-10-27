namespace RecapDama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateButtons();
        }

        private void GenerateButtons()
        {
            Button[,] buttons = new Button[8, 8];
            short left = 0;
            short top = 0;
            short size = 80;
            for (int i = 0; i <= buttons.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = size;
                    buttons[i, j].Height = size;
                    buttons[i, j].Left = left;
                    buttons[i, j].Top = top;
                    buttons[i, j].ForeColor = Color.Blue;
                    buttons[i, j].Text = (j + 1).ToString();
                    left += size;
                    if ((i + j) % 2 == 0)
                    {
                        buttons[i, j].BackColor = Color.Black;
                    }
                    else
                    {
                        buttons[i, j].BackColor = Color.White;
                    }
                    this.Controls.Add(buttons[i, j]);
                }
                left = 0;
                top += size;
            }
        }
    }
}