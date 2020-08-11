using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;

namespace OPC
{
    public class OPCInstance
    {
        //1、声明OPC服务器访问需要的成员
        public OPCServer Server;
        public OPCGroups Groups;
        public OPCGroup Group;
        public OPCItems Items;
        public OPCItem Item;

        public void Run() 
        {
            string a = "BarcoVision.OPCSedo0PCServerDA.1";
            string b = "192.168.3.201";
            Server = new OPCServer();//实例化OPCServer()
            Server.Connect(a,b);//连接OPC服务器 参数一：OPC服务器名称，参数二：服务器地址

            if (Server.ServerState==Convert.ToInt32(OPCServerState.OPCRunning))
            {
                Groups = Server.OPCGroups;//获取OPC服务器的组
                Groups.DefaultGroupDeadband = 0;//只要数值有所变动就更新到组里(数据缓冲区刷新阀值)
                Groups.DefaultGroupIsActive = true;//表示添加的组是否可用
                Groups.DefaultGroupUpdateRate = 250;//代表每多少毫秒就刷新一次数值
                Group = Groups.Add("group1");//添加一个组到组集合
                Group.IsSubscribed = true;//当前组对象是否订阅Datechange事件
                Items = Group.OPCItems;
                Item = Items.AddItem("item1",1);

                //订阅组Datechange事件
                Group.DataChange += Group_DataChange;
            }
            Console.ReadKey();
            }

        private void Group_DataChange(int TransactionID, int NumItems, ref Array ClientHandles, ref Array ItemValues, ref Array Qualities, ref Array TimeStamps)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 1; i < NumItems; i++)
            {
                int tmpClientHandle = Convert.ToInt32(ClientHandles.GetValue(i)) ;
                string tmpValue = ItemValues.GetValue(i).ToString();

            }
        }
    }

    }
