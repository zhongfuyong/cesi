using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 任务的知识
{
    class Program
    {
        //多任务：
        //如果一个任务t1的执行是依赖于另一个任务t2的，那么就需要在这个任务t2执行完毕后才开始执行t1。
        //这个时候我们可以使用连续任务。

        //任务的层次结构
        //我们在一个任务中启动一个新的任务，相当于新的任务是当前任务的子任务，两个任务异步执行，
        //如果父任务执行完了但是子任没有执行完，它的状态会设置为WaitingFordhildrenToComplete，只有子任务也执行完了，父任务的状态就变成RunToCompletion
        static void Main(string[] args)
        {

        }
    }
}
