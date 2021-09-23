using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnotherWF
{

    public partial class Form1 : Form
    {
        const int Start_Hoz = 50;
        const int Start_Ver = 70;
        const int Def_Hoz = 500;
        const int Def_Ver = 100;
        int Des_Hoz = 500;
        int Des_Ver = 100;
        Label Inline;
        public static TreeNode S;
        public Form1()
        {
            InitializeComponent();
        }
        Label CreateLabel(String Text)
        {
            Label Result = new Label();
            Result.ForeColor = Color.Red;
            Result.BackColor = Color.Green;
            Result.Text = Text;
            Result.Name = Text;
            Result.Location = new Point(Start_Hoz, Start_Ver);
            Result.TextAlign = ContentAlignment.MiddleCenter;
            Result.Width = 70;
            Result.Height = 30;
            Result.Font = new Font("Sanserif", 14, FontStyle.Bold);
            return Result;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Label k = CreateLabel(Value.Text);
            this.Controls.Add(k);
            Inline = k;
            insert(ref S, int.Parse(Value.Text), Des_Hoz, Des_Ver);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Inline.Left += (Des_Hoz - Inline.Left);
            Inline.Top += (Des_Ver - Inline.Top);
            if (Inline.Left == Des_Hoz || Inline.Top == Des_Ver)
            {
                Value.Text = "";
                Value.Focus();
                timer1.Stop();
                Des_Hoz = Def_Hoz;
                Des_Ver = Def_Ver;
            }
        }
        public void insert(ref TreeNode Result, int value, int x, int y)
        {
            if (Result == null)
            {
                Des_Hoz = x;
                Des_Ver = y;
                timer1.Start();
                Result = new TreeNode(value);
                
            }
            else if (value >= Result.val)
            {
                SearchLabel(Result.val.ToString());
                insert(ref Result.right, value, x + 250, y + 80);
                
            }
            else
            {
                SearchLabel(Result.val.ToString());
                insert(ref Result.left, value, x - 150, y + 80);
            }

        }
        
        public void SearchLabel(String name)
        {
            foreach(Control i in this.Controls)
            {
                if (i is Label && i.Text
                    == name)
                {
                    i.BackColor = Color.Purple;
                    Task.Delay(1000).Wait();
                    i.BackColor = Color.Green;

                }

            }
            
        }
    }
}
