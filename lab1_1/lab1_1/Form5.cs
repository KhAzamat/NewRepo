using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox1.Text);
            int[,] matrix = new int[n, n];
            Random rand = new Random();
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 4;
                
                }
            }
 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 4)
                    {
                        if (i == j)
                        {
                            matrix[i, j] = 0;
                        }
                        else if (i != j)
                        {
                            matrix[i, j] = rand.Next(0, 3);
                            if (matrix[i, j] == 2)
                            {
                                matrix[j, i] = 0;
                            }
                            else if (matrix[i, j] == 1)
                            {
                                matrix[j, i] = 1;
                            }
                            else if (matrix[i, j] == 0)
                            {
                                matrix[j, i] = 2;
                            }
                        }
                    }
                    
                }
            }
            int count_answer = 0;
            int[] team = new int[n];
            int mas_ind = 0;
            for (int i = 0; i < n; i++)
            {
                int count_win = 0;
                int count_l = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 2)
                    {
                        count_win = count_win + 1;
                    }
                    else if (matrix[i, j] == 0)
                    {
                        count_l = count_l + 1;
                    }
                }
                if (count_win > count_l - 1)
                {
                    count_answer++;
                }
                if (count_win == n - 1)
                {
                    team[mas_ind] = i + 1;
                    mas_ind++;
                }
            }   
            textBox2.Text = count_answer.ToString();
            String str_team = "";
            for (int i = 0; i < team.Length; i++)
            {
                if (team[i] != 0) str_team += team[i].ToString() + " ";
            }
                
            textBox3.Text = str_team;

        }
    }
}
