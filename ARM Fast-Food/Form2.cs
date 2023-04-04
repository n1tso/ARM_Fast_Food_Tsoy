using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM_Fast_Food
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `zakazi` (`napitok`, `zakuska`, `burger`, `pizza`) VALUES  @napitok, @zakuska, @burger, @pizza ", db.GetConnection());

            command.Parameters.Add("@napitok", MySqlDbType.VarChar).Value = listBox1.SelectedItem;
            command.Parameters.Add("@zakuska", MySqlDbType.VarChar).Value = listBox2.SelectedItem;
            command.Parameters.Add("@burger", MySqlDbType.VarChar).Value = listBox3.SelectedItem;
            command.Parameters.Add("@pizza", MySqlDbType.VarChar).Value = listBox4.SelectedItem;

            db.OpenConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                this.Hide();
                MessageBox.Show("Ваш заказ: " + listBox1.SelectedItem + listBox2.SelectedItem + listBox3.SelectedItem + listBox4.SelectedItem, "Стоимость вашего заказа: ");
            }
            else
            {
                MessageBox.Show("Кран");
            }

            db.CloseConnection();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox5.SelectedIndex != -1)
            listBox5.Items.RemoveAt(listBox5.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox5.Items.Add(listBox1.SelectedItem.ToString());
            listBox5.Items.Add(listBox2.SelectedItem.ToString());
            listBox5.Items.Add(listBox3.SelectedItem.ToString());
            listBox5.Items.Add(listBox4.SelectedItem.ToString());
        }
    }
}
