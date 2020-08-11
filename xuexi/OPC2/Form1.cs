using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Opc;
using OpcCom.Da;

namespace OPC2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        IDiscovery m_discovery = new IDiscovery();
        public Opc.Server m_server;

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                Opc.Server[] servers = m_discovery.GetAvailableServers(Specification.COM_DA_20,"192.168.3.201", null);
                if (servers != null)
                {   //遍历所查询到的所有OPC服务器，将其新增到 comboBox1 下拉列表框中
                    foreach (Opc.Da.Server server in servers)
                    {
                        comboBox1.Items.Add(server.Name);
                    }
                }
                comboBox1.SelectedIndex = 0;
                listBox1.Items.Add("查询服务器成功.请选择OPC进行连接");
            }
            catch (Exception ex)
            {

                listBox1.Items.Add(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Opc.Server[] servers = m_discovery.GetAvailableServers(Specification.COM_DA_20, "192.168.3.201", null);
                if (servers != null)
                {
                    foreach (Opc.Da.Server server in servers)
                    {
                        if (String.Compare(server.Name, comboBox1.Text, true) == 0)//为true忽略大小写
                        {
                            m_server = server;//建立连接。
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                listBox1.Items.Add(ex.Message);
                return;
            }
            if (m_server != null)
            {
                try
                {
                    m_server.Connect();
                    listBox1.Items.Add("OPC服务器连接成功,请填写变量名称进行读取数据");

                }
                catch (Exception ex)
                {
                    listBox1.Items.Add(ex.Message);

                }

            }
            else
            {
                listBox1.Items.Add("连接失败,请检查IP以及服务器对象");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
