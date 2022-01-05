using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 移除当前选项卡
            //（当前窗体是已子窗体的存在选项卡中，而父容器的父容器就是选项卡控件，从选项卡控件中移除单个选项卡）
            this.Parent.Parent.Controls.Remove(this.Parent);
        }
    }
}
