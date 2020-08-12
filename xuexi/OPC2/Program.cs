using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc;
using OpcCom;
using Opc.Da;
using System.Threading;

namespace OPC2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester tst = new Tester();
            tst.Work();
        }
        class Tester
        {
            private Opc.Da.Server m_server = null;//定义数据存取服务器
            private Opc.Da.Subscription subscription = null;//定义组对象（订阅者）
            private Opc.Da.SubscriptionState state = null;//定义组（订阅者）状态，相当于OPC规范中组的参数
            private Opc.IDiscovery m_discovery = new OpcCom.ServerEnumerator();//定义枚举基于COM服务器的接口，用来搜索所有的此类服务器。
            public void Work()
            {
                //查询服务器
                // Opc.Server[] servers = m_discovery.GetAvailableServers(Specification.COM_DA_20, "TX1", null);//远程,TX1是计算机名

                Opc.Server[] servers = m_discovery.GetAvailableServers(Specification.COM_DA_20, "192.168.3.201", null);//本地

                //daver表示数据存取规范版本，Specification.COMDA_20等于2.0版本。
                //host为计算机名，null表示不需要任何网络安全认证。
                if (servers != null)
                {
                    foreach (Opc.Da.Server server in servers)
                    {
                        //server即为需要连接的OPC数据存取服务器。
                        if (String.Compare(server.Name, "OPC.SimaticNET", true) == 0)//为true忽略大小写
                                                                                     //if (String.Compare(server.Name, "KEPware.KEPServerEx.V4", true) == 0)//不带计算机名为本地访问
                        {
                            m_server = server;//建立连接。
                            break;
                        }
                    }
                }

                //连接服务器
                if (m_server != null)//非空连接服务器
                    m_server.Connect();
                else
                    return;

                //设定组状态
                state = new Opc.Da.SubscriptionState();//组（订阅者）状态，相当于OPC规范中组的参数
                state.Name = "测试";//组名
                state.ServerHandle = null;//服务器给该组分配的句柄。
                state.ClientHandle = Guid.NewGuid().ToString();//客户端给该组分配的句柄。
                state.Active = true;//激活该组。
                state.UpdateRate = 100;//刷新频率为1秒。
                state.Deadband = 0;// 死区值，设为0时，服务器端该组内任何数据变化都通知组。
                state.Locale = null;//不设置地区值。

                //添加组
                subscription = (Opc.Da.Subscription)m_server.CreateSubscription(state);//创建组
                                                                                       //定义Item列表
                                                                                       //对应类型为:{Byte,Byte,Char,Short,String,Word,Boolean}
                string[] itemName = { "S7:[300d]MB0", "S7:[300d]MB2", "BPJ.DB1.dbc2", "BPJ.DB1.dbi3",
                                    "BPJ.DB1.dbs4", "BPJ.DB1.dbw5", "BPJ.DB1.dbx6" };

                //定义item列表
                Item[] items = new Item[2];//定义数据项，即item
                int i;
                for (i = 0; i < items.Length; i++)//item初始化赋值
                {
                    items[i] = new Item();//创建一个项Item对象。
                    items[i].ClientHandle = Guid.NewGuid().ToString();//客户端给该数据项分配的句柄。
                    items[i].ItemPath = null; //该数据项在服务器中的路径。
                    items[i].ItemName = itemName[i]; //该数据项在服务器中的名字。
                }

                //添加Item
                subscription.AddItems(items);

                //注册回调事件
                subscription.DataChanged += new Opc.Da.DataChangedEventHandler(OnDataChange);

                //以下测试同步读
                //以下读整个组
                ItemValueResult[] values = subscription.Read(subscription.Items);
                //以下检验item的quality
                /*if (values[0].Quality .Equals(Opc.Da.Quality.Good))
                    Console.WriteLine("检测质量成功！")；*/
                //以下读部分组
                Item[] r_items = new Item[1];
                for (i = 1; i < 2; i++)
                    r_items[i - 1] = subscription.Items[i];
                ItemValueResult[] values2 = subscription.Read(r_items);
                //以下遍历读到的全部值
                /*foreach (ItemValueResult value in values2)
                {
                    Console.WriteLine("同步读：ITEM:{0},value:{1},quality:{2}", value.ItemName, value.Value, value.Quality);
                }*/

                //以下测试异步读
                IRequest quest = null;
                subscription.Read(subscription.Items, 1, this.OnReadComplete, out quest);

                //以下测试同步写
                //以下写整个组
                ItemValue[] itemvalues = new ItemValue[subscription.Items.Length];
                for (i = 0; i < subscription.Items.Length; i++)
                    itemvalues[i] = new ItemValue((ItemIdentifier)subscription.Items[i]);
                itemvalues[0].Value = 255;
                itemvalues[1].Value = 126;
                // itemvalues[2].Value = 'A';
                // itemvalues[3].Value = -128;
                // itemvalues[4].Value = "Good Lucky！";
                // itemvalues[5].Value = 65535;
                // itemvalues[6].Value = true;
                subscription.Write(itemvalues);
                Thread.Sleep(500);//暂停线程以让DataChange反映
                                  //以下写部分组
                ItemValue[] itemvalues2 = new ItemValue[3];
                itemvalues2[0] = new ItemValue((ItemIdentifier)subscription.Items[1]);//TItem类要先转成ItemIdentifier，才能转成ItemValue
                itemvalues2[1] = new ItemValue((ItemIdentifier)subscription.Items[2]);//TItem类要先转成ItemIdentifier，才能转成ItemValue
                itemvalues2[2] = new ItemValue((ItemIdentifier)subscription.Items[3]);//TItem类要先转成ItemIdentifier，才能转成ItemValue      
                itemvalues2[0].Value = 12;
                itemvalues2[1].Value = 112;
                itemvalues2[2].Value = 122;
                subscription.Write(itemvalues2);

                //以下测试异步写
                Thread.Sleep(500);//暂停线程以让DataChange反映
                subscription.Write(itemvalues, 1, this.OnWriteComplete, out quest);


                //END
                Console.WriteLine("************************************** hit <return> to close...");
                Console.ReadLine();

                //取消回调事件
                subscription.DataChanged -= new Opc.Da.DataChangedEventHandler(this.OnDataChange);
                //移除组内item
                subscription.RemoveItems(subscription.Items);
                //结束：释放各资源
                m_server.CancelSubscription(subscription);//m_server前文已说明，通知服务器要求删除组。        
                subscription.Dispose();//强制.NET资源回收站回收该subscription的所有资源。         
                m_server.Disconnect();//断开服务器连接
            }

            //DataChange回调
            public void OnDataChange(object subscriptionHandle, object requestHandle, ItemValueResult[] values)
            {
                Console.WriteLine("_____________________DataChange事件");
                foreach (ItemValueResult item in values)
                {
                    Console.WriteLine("发生DataChange事件");
                    Console.WriteLine("ITEM:{0},value:{1}", item.ItemName, item.Value);
                    Console.WriteLine("ITEM:{0},value:{1}", item.Quality, item.Timestamp);
                    Console.WriteLine("事件信号句柄为{0}", requestHandle);

                }

            }

            //ReadComplete回调
            public void OnReadComplete(object requestHandle, Opc.Da.ItemValueResult[] values)
            {
                /*Console.WriteLine("发生异步读name:{0},value:{1}", values[0].ItemName, values[0].Value);
                if ((int)requestHandle == 1)
                    Console.WriteLine("事件信号句柄为{0}", requestHandle);*/
            }

            //WriteComplete回调
            public void OnWriteComplete(object requestHandle, Opc.IdentifiedResult[] values)
            {
                /*Console.WriteLine("发生异步写name:{0},value:{1}", values[0].ItemName, values[0].GetType());
                if ((int)requestHandle == 2)
                    Console.WriteLine("事件信号句柄为{0}", requestHandle);*/
            }
        }
    }




}