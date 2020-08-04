using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace 读取注册表信息
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Registrykey类中的四个方法：
        //Opensubkey（）   用于打开指定的子健   RegistryKey hklm.OpenSubKey(子键名称)  RegistryKey hklm.OpenSubKey(子键名称，是否用于读写操作)
        //GetSubKeyNames（）用于获取主键下边所有子键的名称，它的返回值是字符串的数组
        //GetValueNames（）用于获取当前子键中所有的键名称，它的返回值也是一个字符串的数组
        //GetValye（）用于获取指定键的值    Registrykey hklm.GetValue（子键名称）；
        private void button1_Click(object sender, EventArgs e)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey software = hklm.OpenSubKey("Software");
            RegistryKey win = software.OpenSubKey("microsoft");
            RegistryKey windows = win.OpenSubKey("windows");
            listBox1.Items.Clear();
            foreach(string site in windows.GetSubKeyNames())
            {
                if (site == "CurrentVersion")
                {
                    RegistryKey sitekey = windows.OpenSubKey(site);
                    foreach (string sValName in sitekey.GetValueNames())
                    {
                        listBox1.Items.Add("" + sValName + "：" + sitekey.GetValue(sValName));
                    }
                }
            }
            if (listBox1.Items.Count==0)
            {
                MessageBox.Show("未找到相关数据");
            }
            else
            {
                MessageBox.Show("读取到了数据");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //新增注册表信息
            //CreateSubKey(string key)
            //目的：创建以指定得字符串维名称得子键
            //作用1、能够创建子键2、创建主键

            //SetValue(String name,String keyvalue)
            //作用1、重命名键值得数值，2、创建新的键值
            //如果存在此键值时实现重命名，不存在时，实现创建新的键值

            if (textBox1.Text!="")
            {
                listBox1.Items.Clear();
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey sys = hklm.OpenSubKey("System",true);
                RegistryKey addText = sys.CreateSubKey(textBox1.Text);
                addText.SetValue(textBox2.Text,textBox3.Text);
                foreach (var item in sys.GetSubKeyNames())
                {
                    if (item==textBox2.Text)
                    {
                        RegistryKey sitekey = sys.CreateSubKey(item);
                        foreach (string sVa1Name in sitekey.GetSubKeyNames())
                        {
                            listBox2.Items.Add(item + "" + sVa1Name + ":" + sitekey.GetValue(sVa1Name));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("请先填写数据");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey hklm = Registry.LocalMachine;
            RegistryKey sys = hklm.OpenSubKey("System");
            foreach (string site in sys.GetSubKeyNames()) 
            {
                listBox2.Items.Add(site);
            }
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //C#中实现删除注册信息通过调用三个方法
            //DeleteSubKey 方法
            //DeleteSubKeyTree 方法
            //DeleteValue方法.

            //DeleteSubkey方法  删除一个指定的子键  
            //DeleteSubkey(string subkey);
            //DeleteSubKey（string subkey，Boolean info）
            //true：删除时候会弹出错误信息（存在子键的情况）false：不弹出

            //DeleteSubKeyTree方法 方法删除指定子键下的目录
            //DeleteSubkeyTree（string subkey）；

            //DeleteValue方法. 删除指定的键值
            //DeleteValue（string value）；



            RegistryKey hkim = Registry.LocalMachine;
            RegistryKey sys = hkim.OpenSubKey("System", true);
            foreach (string site in sys.GetSubKeyNames())
            {
                if (site==textBox1.Text)
                {
                    try
                    {
                        sys.DeleteSubKeyTree(site);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.ToString());
                    }
                    
                    MessageBox.Show("yes");
                }
            }
        }
    }
}
