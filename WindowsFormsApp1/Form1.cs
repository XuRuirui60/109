using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace _109
{
    public partial class Form1 : Form
    {
        SerialPort BT = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            comBoxSet();//加入偵測到的port口到combox裡面
           
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            label2.BackColor = Color.Red;
            label2.Text = "Device Offline";
        }
        public void comBoxSet()//加入偵測到的port口到combox裡面
        {
            comboBox1.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(s);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            comBoxSet();
            textBox1.Text = $"Current Time:{DateTime.Now.ToString("tt hh:mm:ss")}";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (BT.IsOpen)
            {
                //串口已經處於打開狀態
                BT.Close();    //關閉串口
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                label2.BackColor = Color.Red;
                label2.Text = "Device Offline";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void open_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(comboBox1.Text.Trim()))
            {
                BT.PortName = comboBox1.Text;
                BT.BaudRate = 38400;//藍芽預設連接速度
                BT.WriteTimeout = 3000;//預設連接時間3秒
                BT.Open();//開啟藍芽Tx com port
                label2.BackColor = Color.Green;
                label2.Text = "Device Online";
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
            }
        }

        private void write_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Length != 4)//只能輸入4個字
            {
                textBox2.Text = "";
            }
            else//否則清除
            {
                BT.Write("w" + textBox2.Text);
            }
        }

        private void allon_Click(object sender, EventArgs e)
        {
            BT.Write("a1");
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
            checkBox4.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox7.Checked = true;
            checkBox8.Checked = true;
        }

        private void alloff_Click(object sender, EventArgs e)
        {
            BT.Write("a2");
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }



        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            BT.Write("b0");
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            BT.Write("b1");
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            BT.Write("b2");
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            BT.Write("b3");
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            BT.Write("b4");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            BT.Write("b5");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            BT.Write("b6");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            BT.Write("b7");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar < 48 | (int)e.KeyChar > 57)//限制只能輸入數字
            {
                e.Handled = true;
            }
        }
    }
}
