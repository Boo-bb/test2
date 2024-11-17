// See https://aka.ms/new-console-template for more information
using System;

namespace 事件
{
    //事件是一种特殊的变量类型
    //声明语法：
    // 访问修饰符 event 委托类型 事件名
    /// <summary>
    /// 
    /// 一、
    /// 1.事件只能作为成员变量存储在类,接口和结构体中
    /// 2.事件不能在类外部赋值
    /// 3.事件不能在类外部调用
    /// 
    /// 二、
    /// 1.事件是为了防止外部随意置空委托和调用委托
    /// 2.事件相当于对委托做了一次封装
    /// 
    /// </summary>
    class Test
    {

        public Action myfun;
        //事件成员变量，也用于存储函数
        public event Action myevent;

        public Test()
        {
            //事件的使用基于委托
            myfun = Testfunc;
            myfun += Testfunc;
            myfun-=Testfunc;
            myfun();
            myfun.Invoke();
            myfun = null;
            Console.WriteLine("------------");

            myevent = Testfunc;
            myevent += Testfunc;
            myevent-=Testfunc;
            myevent.Invoke();
            myevent();
            myevent = null;
            Console.WriteLine("------------");

        }
        public void Test2()
        {
            if (myevent != null)
            {
                myevent();
            }
        }
  
        public void Testfunc()
        {
            Console.WriteLine("this is Testfunc");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.myfun = null;
            test.myfun = Testfunc;

            //事件不能在类的外部直接赋值
            //事件可以 +=，-=
            //事件不能在类外调用
           
            test.myevent += Testfunc;
            test.myevent += Testfunc;
            test.myevent += Testfunc;

            //事件不能作为临时变量在函数中使用（无论是主函数还是其他函数）
            test.Test2();
            Action a = Testfunc;
            

        }

        static void Testfunc()
        {
            Console.WriteLine("this is web testfun");
        }
    }
}
