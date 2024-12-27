using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.IlyinME.Sprint7.Project.V4.Lib;
using System.IO;

namespace Tyuiu.IlyinME.Sprint7.Project.V4
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            openFileDialogTask_IME.Filter = "Значения, разделенные запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
            saveFileDialogTask_IME.Filter = "Значения, разделенные запятыми(*.csv)|*.csv|Все файлы(*.*)|*.*";
        }
        public string openFilePath;
        static string[,] array;
        DataService ds = new DataService();
        public string path = @"C:\Users\1\source\repos\Tyuiu.IlyinME.Sprint7\Tyuiu.IlyinME.Sprint7.Project.V4\bin\Debug\Books.csv";
        Point lastPoint;
        private void buttonClose_IME_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelMenu_IME_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panelMenu_IME_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panelMenuUp_IME_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panelMenuUp_IME_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void buttonInfo_IME_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }

        private void buttonStats_IME_Click(object sender, EventArgs e)
        {
            FormStats formStats = new FormStats();
            formStats.ShowDialog();
        }

        private void labelMenu_IME_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void labelMenu_IME_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void buttonSearch_IME_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridViewBooks_IME.RowCount; i++)
                {
                    dataGridViewBooks_IME.Rows[i].Selected = false;
                    for (int j = 0; j < dataGridViewBooks_IME.ColumnCount; j++)
                        if (dataGridViewBooks_IME.Rows[i].Cells[j].Value != null)
                            if ((dataGridViewBooks_IME.Rows[i].Cells[j].Value.ToString().Contains(textBoxAutor_IME.Text)))
                            {
                                dataGridViewBooks_IME.Rows[i].Selected = true;
                            }
                }
            }
            catch
            {
                MessageBox.Show("Строка не найдена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOpenTab_IME_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialogTask_IME.ShowDialog();
                openFilePath = openFileDialogTask_IME.FileName;
                array = ds.LoadFromFileData(openFilePath);
                int rows = array.GetUpperBound(0) + 1;
                int columns = array.Length / rows;

                dataGridViewBooks_IME.ColumnCount = columns;
                dataGridViewBooks_IME.RowCount = rows;

                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c < columns; c++)
                    {
                        if (int.TryParse(array[r, c], out int n))
                        {
                            dataGridViewBooks_IME.Rows[r].Cells[c].Value = n;
                        }
                        else
                        {
                            dataGridViewBooks_IME.Rows[r].Cells[c].Value = array[r, c];
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Файл не выбран!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelMenuRight_IME_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panelMenuRight_IME_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panelMenuLeft_IME_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panelMenuLeft_IME_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void dataGridViewBooks_IME_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void dataGridViewBooks_IME_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void buttonSave_IME_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialogTask_IME.FileName = "BooksSearch";
                saveFileDialogTask_IME.InitialDirectory = Directory.GetCurrentDirectory();
                saveFileDialogTask_IME.ShowDialog();

                string path = saveFileDialogTask_IME.FileName;

                FileInfo fl = new FileInfo(path);
                bool fileExists = fl.Exists;

                if (fileExists)
                {
                    File.Delete(path);
                }

                int rows = dataGridViewBooks_IME.RowCount;
                int columns = dataGridViewBooks_IME.ColumnCount;

                string str = "";

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (j != columns - 1)
                        {
                            str = str + dataGridViewBooks_IME.Rows[i].Cells[j].Value + ";";
                        }
                        else
                        {
                            str = str + dataGridViewBooks_IME.Rows[i].Cells[j].Value;
                        }
                    }
                    File.AppendAllText(path, str + Environment.NewLine, Encoding.GetEncoding(1251));
                    str = "";
                }
            }
            catch
            {
                MessageBox.Show("Файл не удалось сохранить!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_IME_Click(object sender, EventArgs e)
        {
            dataGridViewBooks_IME.Rows.Add(textBoxAvtor_IME.Text, textBoxName_IME.Text, textBoxYears_IME.Text, textBoxPrice_IME.Text, textBoxNew_IME.Text, textBoxAnnotation_IME.Text);
        }

        private void buttonRemove_IME_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridViewBooks_IME.CurrentCell.RowIndex;
            dataGridViewBooks_IME.Rows.RemoveAt(rowIndex);
        }
        private ListSortDirection sortDirection = ListSortDirection.Ascending;
        private void buttonSort_IME_Click(object sender, EventArgs e)
        {
            if (sortDirection == ListSortDirection.Ascending)
            {
                dataGridViewBooks_IME.Sort(dataGridViewBooks_IME.Columns[textBoxSort_IME.Text.ToString()], ListSortDirection.Descending);
                sortDirection = ListSortDirection.Descending;
            }
            else
            {
                dataGridViewBooks_IME.Sort(dataGridViewBooks_IME.Columns[textBoxSort_IME.Text.ToString()], ListSortDirection.Ascending);
                sortDirection = ListSortDirection.Ascending;
            }
        }

        private void buttonInfo_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "О программе";
        }

        private void buttonStats_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "Статистика";
        }

        private void buttonGuide_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "Руководство";
        }

        private void buttonSave_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "Сохранить файл";
        }

        private void buttonSort_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "Сортировать";
        }

        private void buttonAdd_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "Добавить строку";
        }

        private void buttonRemove_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "Удалить строку";
        }

        private void buttonOpenTab_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "Вывод таблицы";
        }

        private void buttonSearch_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "Найти";
        }

        private void buttonGuide_IME_Click(object sender, EventArgs e)
        {
            FormGuide formGuide = new FormGuide();
            formGuide.ShowDialog();
        }

        private void buttonFilterAvtor_IME_Click(object sender, EventArgs e)
        {
            string filterValue = textBoxAvtor1_IME.Text;
            foreach (DataGridViewRow row in dataGridViewBooks_IME.Rows)
            {
                string cellValue = row.Cells[0].Value.ToString();

                if (cellValue.Contains(filterValue))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void buttonFilterBook_IME_Click(object sender, EventArgs e)
        {
            string filterValue = textBoxBook_IME.Text;
            foreach (DataGridViewRow row in dataGridViewBooks_IME.Rows)
            {
                string cellValue = row.Cells[1].Value.ToString();

                if (cellValue.Contains(filterValue))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void buttonFilterYars_IME_Click(object sender, EventArgs e)
        {
            string filterValue = textBoxYears1_IME.Text;
            foreach (DataGridViewRow row in dataGridViewBooks_IME.Rows)
            {
                string cellValue = row.Cells[2].Value.ToString();

                if (cellValue.Contains(filterValue))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void buttonFilterPrice_IME_Click(object sender, EventArgs e)
        {
            string filterValue = textBoxPrice1_IME.Text;
            foreach (DataGridViewRow row in dataGridViewBooks_IME.Rows)
            {
                string cellValue = row.Cells[3].Value.ToString();

                if (cellValue.Contains(filterValue))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void buttonFilterNew_IME_Click(object sender, EventArgs e)
        {
            string filterValue = textBoxNew1_IME.Text;
            foreach (DataGridViewRow row in dataGridViewBooks_IME.Rows)
            {
                string cellValue = row.Cells[4].Value.ToString();

                if (cellValue.Contains(filterValue))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private void buttonFilterAvtor_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "ФильтрА";
        }

        private void buttonFilterBook_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "ФильтрК";
        }

        private void buttonFilterYars_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "ФильтрГ";
        }

        private void buttonFilterPrice_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "ФильтрЦ";
        }

        private void buttonFilterNew_IME_MouseEnter(object sender, EventArgs e)
        {
            toolTipButton_IME.ToolTipTitle = "ФильтрИ";
        }

        private void groupBoxAdd_IME_Enter(object sender, EventArgs e)
        {

        }
    }
}
