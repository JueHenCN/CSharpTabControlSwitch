using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<TabPage, Form> tabPageList = new Dictionary<TabPage, Form>(); // 窗体所在选项卡下标集合
        Form2 form2 = new Form2(); // 测试2窗体对象
        Form3 form3 = new Form3(); // 测试2窗体对象
        Form4 form4 = new Form4(); // 测试2窗体对象

        private void button2_Click(object sender, EventArgs e)
        {
            // 判断是否为空
            if (form2 == null)
            {
                form2 = new Form2();
            }
            CheckTabPage(form2); // 显示该窗口
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 判断是否为空
            if (form3 == null)
            {
                form3 = new Form3();
            }
            CheckTabPage(form3); // 显示该窗口
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 判断是否为空
            if (form4 == null)
            {
                form4 = new Form4();
            }
            CheckTabPage(form4); // 显示该窗口
        }
        
        /// <summary>
        /// 显示选择的窗体方法
        /// (该方法是当前选项卡中不存在该窗体，然后创建并跳转至该窗体)
        /// </summary>
        /// <param name="form">需要显示的窗体</param>
        private void ShowMessage(Form form)
        {
            TabPage tabPage = new TabPage(); // 创建新的选项卡
            tcDisplay.Controls.Add(tabPage); // 添加到选项卡容器中
            tabPage.Text = form.Text; // 设置选项卡的标题
            tabPage.Name = form.Name; // 设置选项卡的属性名

            form.TopLevel = false; // 设置该窗体不为顶级窗体
            form.Parent = tabPage; // 设定该窗体的父窗体为选项卡
            form.FormBorderStyle = FormBorderStyle.None; // 设定窗体无边框
            form.Dock = DockStyle.Fill; // 设定窗体填充到父窗体中
            form.Show(); // 显示窗体
            tcDisplay.SelectedTab = tabPage; // 显示当前选项卡
            tabPageList.Add(tabPage, form); // 将当前窗体加入集合中(用于确定窗体存在于哪个选项卡中)
        }

        /// <summary>
        /// 检查当前窗体是否已在选项卡中显示
        /// </summary>
        /// <param name="form">需要显示的窗体</param>
        private void CheckTabPage(Form form)
        {
            bool flage = true;
            // 遍历窗体所在选项卡集合
            foreach (TabPage item in tabPageList.Keys)
            {
                // 判断当前窗体是否存在
                if (tabPageList[item]==form)
                {
                    tcDisplay.SelectedTab = item; // 显示当前选项卡
                    flage = false;
                    break;
                }
            }
            if (flage)
            {
                ShowMessage(form); // 创建新的选项卡
            }
        }

        /// <summary>
        /// 当选项卡选择项改变时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tcDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 遍历窗体所在选项卡集合
            foreach (TabPage item in tabPageList.Keys)
            {
                // 判断当前选项卡是否存在
                if (!tcDisplay.TabPages.Contains(item))
                {
                    tabPageList[item] = null;
                    tabPageList.Remove(item);
                    break;
                }
            }
        }


        /// <summary>
        /// 关闭按钮单击事件
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); // 结束程序
        }
    }
}
