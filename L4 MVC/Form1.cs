using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L4_MVC
{
    public partial class Form1 : Form
    {
        Model model; // Создание ссылки на модель
        public Form1()
        {
            InitializeComponent();
            model = new Model(); // Создание модели
            model.observers += new EventHandler(UpdateFromModel); // Подписывание формы на обновление
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.Value = Int32.Parse(textBox1.Text);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                model.Value = Int32.Parse(textBox2.Text);
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            model.Value = trackBar.Value;
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            model.Value = vScrollBar.Value;
        }

        // Обновляет компоненты на форме
        public void UpdateFromModel(object sender, EventArgs e)
        {
            textBox1.Text = model.Value.ToString();
            textBox2.Text = (model.Value + 1).ToString();
            trackBar.Value = model.Value;
            progressBar.Value = model.Value;
            vScrollBar.Value = model.Value;
            label.Text = model.Value.ToString();
        }

        public class Model 
        {
            private int value;
            public int Value // Получение и передача зачения модели
            { 
                set 
                {
                    if (value < 0 || value > 20)
                        value = new Random().Next(0, 20);
                    this.value = value; 
                    observers.Invoke(this, null); // Вызов обновления
                } 
                get 
                { 
                    return value; 
                } 
            }
            public EventHandler observers; // Обновление 
        }
    }
}
