using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 注册表
{
    class Program
    {
        static void Main(string[] args)
        {
            //计算机注册表5大类
            //HKEY_CLASSES_ROOT  对打开文件的匹配
            //HKEY CURRENT USER  对当前用户的配置信息管理
            //HKEY_LOCAL_MACHINE 对针对计算机所有用户的信息管理
            //HKEY_USERS         所有用户
            //HKEY CURRENT CONFIG 包含计算机系统启动时所有硬件的配置


            //实现访问注册表的两大类
            //Registry
            //1、只能对注册表进行单一的访问，执行简单的操作
            //2、另一个作用是提顶级键Registrykey实例，Resgistry类提供了7个公共的静态域

            //Resgistry类的7个公共的静态域：
            //1）Resgistry.ClassRoot          对应于HKEY_CLASSES_ROOT主键
            //2）Resgistry.CurrentUser        对应于HKEY_CURRENT_USER主键
            //3）Resgistry.LocalMachine       对应于HKEY_LOCAL_MACHINE主键
            //4）Resgistry.Users              对应于HKEY_USER主键
            //5）Resgistry.CurrentConfig      对应于HEKY_CURRENT_CONFIG主键
            //6）Resgistry.PerformanceData    对应于HKEY_DYN_DATA主键
            //7）Resgistry.DynData            

            //RegistryKey类
            //提供了对注册表操作的方法：查看子键、创建新键、读取或修改键中的值等

            //RegistryKey的方法
            //CreateSubkey                    创建一个新的子项，或打开一个现有子项
            //DeleteSubkey                    删除指定的子项字符串subkey不区分大小写
            //DeleteSubkeyTree                递归删除子项和任何子级子项。字符串subkey不区分大小写
            //DeleteValue                     从此项中删除指定值
            //GetValue                        检索与指定的名称关联的值
            //GetValueKind                    检索与指定名称关联的注册表数据类型
            //GetValueNames                   检索包含与此项关联的所有名称的字符串数值
            //OpenSubkey                      检索指定的子项
            //SetValue                        设置注册表项中的名称/值对的值

            //RegistryKey的属性
            //Name                            检索项的名称
            //SubKeyCouunt                    检索当前项的子项目数目
            //ValueCount                      检索项中的值的计数
        }
    }
}
