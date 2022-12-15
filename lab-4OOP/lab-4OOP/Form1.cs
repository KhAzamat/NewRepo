using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4OOP
{
    public partial class Form1 : Form
    {
        List<string> buffer = new List<string>();
        int buf_index = -1;
        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();
        public Form1()
        {
            InitializeComponent();
            Init.pictureBox = pictureBox1;
            Init.bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
        private bool IsOperation(char item)
        {
            if (item == 'R' || item == 'M' || item == 'D' || item == 'P' || item == ',' || item == '(' || item == ')')
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void textBox1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                operators.Clear();
                operands.Clear();
                string pentryString = textBox1.Text.Replace(" ", "");
                buffer.Add(pentryString);
                
                for (int i = 0; i < pentryString.Length; i++)
                {
                    if (IsOperation(pentryString[i]))
                    {
                        if (!Char.IsDigit(pentryString[i]))
                        {
                            operands.Push(new Operand(pentryString[i]));
                            while (i < pentryString.Length - 1 && IsOperation(pentryString[i + 1]))
                            {
                                string temp_str = operands.Pop().value.ToString() + pentryString[i + 1].ToString();
                                operands.Push(new Operand(temp_str));
                                i++;
                            }
                        }
                        else if (Char.IsDigit(pentryString[i]))
                        {
                            operands.Push(new Operand(pentryString[i].ToString()));
                            while (i < pentryString.Length - 1 && Char.IsDigit(pentryString[i + 1])
                                && IsOperation(pentryString[i + 1]))
                            {
                                int temp_num = Convert.ToInt32(operands.Pop().value.ToString()) * 10 +
                                    (int)Char.GetNumericValue(pentryString[i + 1]);
                                operands.Push(new Operand(temp_num.ToString()));
                                i++;
                            }
                        }
                    }
                    else if (pentryString[i] == 'P')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(pentryString[i]));
                        }
                    }
                    else if (pentryString[i] == 'R')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(pentryString[i]));
                        }
                    }
                    else if (pentryString[i] == 'M')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(pentryString[i]));
                        }
                    }
                    else if (pentryString[i] == 'D')
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(pentryString[i]));
                        }
                    }
                    else if (pentryString[i] == '(')
                    {
                        operators.Push(OperatorContainer.FindOperator(pentryString[i]));
                    }
                    else if (pentryString[i] == ')')
                    {
                        do
                        {
                            if (operators.Peek().symbolOperator == '(')
                            {
                                operators.Pop();
                                break;
                            }
                            if (operators.Count == 0)
                            {
                                break;
                            }
                        }
                        while (operators.Peek().symbolOperator != '(');
                    }
                }
                try
                {
                    SelectingPerformingOperation(operators.Peek());
                }
                catch
                {
                    MessageBox.Show("Введенной команды не существует.");
                    comboBox1.Items.Add("Введенной команды не существует.");
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                buf_index -= 1;
                if (buf_index < 0)
                {
                    buf_index = buffer.Count - 1;
                }
                if (buffer.Count != 0)
                {
                    textBox1.Text = buffer[buf_index];
                }
                else 
                {
                    MessageBox.Show("Истории нет!");
                }
            }

        }
      
        private void SelectingPerformingOperation(Operator op)
        {
            if (op.symbolOperator == 'R')
            {
                if (operands.Count == 5)
                {

                    int w = Convert.ToInt32(operands.Pop().value.ToString());
                    int h = Convert.ToInt32(operands.Pop().value.ToString());
                    int y = Convert.ToInt32(operands.Pop().value.ToString());
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    if(x >= 0 && y >= 0 && x + w >= 0 && y + h >= 0 && x + w <= Init.pictureBox.Width && y + h <= Init.pictureBox.Height)
                    {
                        Rectagle figure = new Rectagle(name, x, y, h, w);
                        ShapeContainer.figureList.Add(figure);
                        figure.Draw();
                        comboBox1.Items.Add($"Прямоугольник {figure.name} отрисован");
                    }
                    else
                    {
                        MessageBox.Show("Прямоугольник выходит за границы");
                        comboBox1.Items.Add("Ошибка. Прямоугольник выходит за границы");
                    }
                }
                else
                {
                    MessageBox.Show("Команда R принимает 5 параметров");
                    comboBox1.Items.Add("Ошибка. Команда R принимает 5 параметров");
                }
            }
            else if (op.symbolOperator == 'M')
            {
                if (operands.Count == 3)
                {
                    Rectagle figure = null;
                    int y = Convert.ToInt32(operands.Pop().value.ToString());
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    foreach (Figure f in ShapeContainer.figureList)
                    {
                        if (f.name == name)
                        {
                            figure = (Rectagle)f;
                        }
                    }
                    if (figure != null)
                    {
                        if (x >= 0 && y >= 0 && x + figure.w >= 0 && y + figure.h >= 0 && x + figure.w <= Init.pictureBox.Width && y + figure.h <= Init.pictureBox.Height)
                            {
                            figure.MoveTo(name, x, y);
                            comboBox1.Items.Add($"Фигура {figure.name} перемещена");
                        }
                        else
                        {
                            MessageBox.Show("Нельзя переместить фигуру за границы");
                            comboBox1.Items.Add("Ошибка. Нельзя переместить фигуру за границы");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Фигуры {name} не существует");
                        comboBox1.Items.Add($"Ошибка. Фигуры {name} не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Команда M принимает 3 параметра");
                    comboBox1.Items.Add("Ошибка. Команда M принимает 3 параметра");
                }
            }
            else if (op.symbolOperator == 'P')
            {
                if (operands.Count == 3)
                {
                    Rectagle figure = null;
                    int h = Convert.ToInt32(operands.Pop().value.ToString());
                    int w = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    foreach (Figure f in ShapeContainer.figureList)
                    {
                        if (f.name == name)
                        {
                            figure = (Rectagle)f;
                        }
                    }
                    if (figure != null)
                    {
                        if (figure.x >= 0 && figure.y >= 0 && figure.x + w >= 0 && figure. y + h >= 0 && figure.x + w <= Init.pictureBox.Width && figure.y + h <= Init.pictureBox.Height)
                        {
                            figure.ch_w(w);
                            figure.ch_h(h);
                            comboBox1.Items.Add($"Фигура {figure.name} изменена");
                        }
                        else
                        {
                            MessageBox.Show("Нельзя изменить фигуру она выходит за границы");
                            comboBox1.Items.Add("Ошибка. Нельзя изменить фигуру она выходит за границы");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Фигуры {name} не существует");
                        comboBox1.Items.Add($"Ошибка. Фигуры {name} не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Команда M принимает 3 параметра");
                    comboBox1.Items.Add("Ошибка. Команда M принимает 3 параметра");
                }
            }
            else if (op.symbolOperator == 'D')
            {
                if (operands.Count == 1)
                {
                    Rectagle figure = null;
                    string name = operands.Pop().value.ToString();
                    foreach (Figure f in ShapeContainer.figureList)
                    {
                        if (f.name == name)
                        {
                            figure = (Rectagle)f;
                        }
                    }
                    if (figure != null)
                    {
                        figure.DeleteF(figure, true);
                        ShapeContainer.figureList.Remove(figure);
                        comboBox1.Items.Add($"Фигура {figure.name} удалена");
                    }
                    else
                    {
                        MessageBox.Show($"Фигуры {name} не существует");
                        comboBox1.Items.Add($"Ошибка. Фигуры {name} не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Команда D принимает 1 параметр");
                    comboBox1.Items.Add("Ошибка. Команда D принимает 1 параметр");
                }
            }
            
        }

        
    }
}
