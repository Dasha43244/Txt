using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Инициализирует все элементы управления и их свойства.
            saveFileDialog1.Filter = "Text File(*.txt | *.txt | Notepad File (*.tnf) |*.tnf "; // Устанавливает фильтр файлов для диалога сохранения.
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Этот метод вызывается при нажатии на пункт меню "Сохранить как".
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) // Открывает диалог сохранения и проверяет, была ли нажата кнопка "Отмена".
                return;
            string filename = saveFileDialog1.FileName; // Получает имя выбранного файла.
            File.WriteAllText(filename, richTextBox1.Text); // Записывает текст из richTextBox1 в файл.
            MessageBox.Show("Файл сохранен!"); // Показывает сообщение, что файл был сохранен.
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) // Открывает диалог открытия файла и проверяет, была ли нажата кнопка "Отмена".
                return;
            string filename = openFileDialog1.FileName; // Получает имя выбранного файла.
            string fileText = File.ReadAllText(filename); // Читает текст из файла.
            richTextBox1.Text = fileText; // Устанавливает прочитанный текст в richTextBox1.
            MessageBox.Show("Файл открыт!"); // Показывает сообщение, что файл был открыт.
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Этот метод вызывается при нажатии на пункт меню "Сохранить".
            string fileText = richTextBox1.Text; // Получает текст из richTextBox1.
            if (!string.IsNullOrEmpty(fileText)) // Проверяет, содержит ли текст.
            {
                saveFileDialog1.FileName = "defaultFileName.txt"; // Устанавливает стандартное имя файла.
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) // Открывает диалог сохранения и проверяет, была ли нажата кнопка "ОК".
                {
                    string filename = saveFileDialog1.FileName; // Получает имя выбранного файла.
                    File.WriteAllText(filename, fileText); // Записывает текст в файл.
                    MessageBox.Show("Файл сохранен!"); // Показывает сообщение, что файл был сохранен.
                }
            }
            else
            {
                MessageBox.Show("Нечего сохранять!"); // Показывает сообщение, что нет содержимого для сохранения.
            }
        }




        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy(); // Копирует выбранный текст в richTextBox1.
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void настройкиШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void настройкиФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.BackColor = colorDialog1.Color;
        }



        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                richTextBox1.ContextMenuStrip = contextMenuStrip1;
            }
        }

        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }

        }

        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Paste();
            }
        }

        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.SelectAll();
            }
        }

        private void oПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пародия на текстовый редактор на Winform", "О программе");
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                if (!string.IsNullOrEmpty(saveFileDialog1.FileName) && System.IO.File.Exists(saveFileDialog1.FileName))
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, richTextBox1.Text, System.Text.Encoding.GetEncoding(1251));
                }
                e.SuppressKeyPress = true;
            }
        }


    }
}

