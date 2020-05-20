using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteTest
{
    public partial class Form1 : CCWin.CCSkinMain
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.skinTextBox1.Text = "";
            this.skinTextBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string str = this.textBox1.Text;
            //string equipStr = ConvertBytes.StringToAscaillHexString(str);
            //byte[] byteEquip = ConvertBytes.ConvertHexStringToByteArray(equipStr, "", 16);
            //this.label1.Text = equipStr;
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            string strPat = this.skinTextBox1.Text;//正则表达式
            string strLet = this.skinTextBox2.Text;//判断字符
            this.label4.ForeColor = Color.Red;
            try
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(strLet, strPat))
                {
                    this.label4.ForeColor = Color.Green;
                    this.label4.Text = "正则表达式和判断字符相匹配！";
                }
                else
                    this.label4.Text = "正则表达式和判断字符不匹配！";
            }
            catch (Exception)
            {
                this.label4.Text = "正则表达式错误！";
            }

        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            string[] lstName = this.skinTextBox2.Text.Split(this.skinTextBox1.Text.Trim()[0]);//判断字符
            string name = string.Empty;
            for (int i = 0; i < lstName.Length; i++)
            {
                name += "[" + lstName[i] + "]";
            }
            this.label4.ForeColor = Color.Black;
            this.label4.Text ="长度："+ lstName.Length + name ;
        }
    }
}
