using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using JhClass.Event;
using JhClass.Methods;
using JhClass.Interface;

//下面一行为定义一个List<T>的DateTime类型的简化写法
using DateTimeList = System.Collections.Generic.List<System.DateTime>;
using JhClass.Delegates;
using static JhClass.Delegates.DelegateTest;
using System.Text;

namespace JhClass.Forms
{
    public partial class FormResult : Form
    {
        public FormResult()
        {
            InitializeComponent();
        }

        #region 委托相关
        /// <summary>
        /// 将字符加倍
        /// 用于测试委托
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string doubleString(ref string str)
        {
            str = str + str;
            return str;
        }
        private string plusA2String(ref string str)
        {
            str = "A" + str;
            return str;
        }
        private void btnDelegateTestClick(object sender, EventArgs e)
        {
            using (DelegateTest test = new DelegateTest())
            {
                StringDelegate dgt1 = new StringDelegate(doubleString);
                dgt1 += plusA2String;

                // 用这个变量来保存输出的字符串
                StringBuilder returnstring = new StringBuilder();

                //以下方法可获取委托中每个方法的返回值，并可处理委托链中的报错
                // 获取一个委托数组，其中每个元素都引用链中的委托
                foreach (var item in dgt1.GetInvocationList())
                {
                    StringDelegate tempObj = item as StringDelegate;
                    try
                    {
                        string str = "test\n";
                        //调用委托获得返回值
                        returnstring.Append(tempObj(ref str) + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        returnstring.AppendFormat("异常从 {0} 方法中抛出, 异常信息为：{1}{2}", tempObj.Method.Name, ex.Message, Environment.NewLine);
                    }

                }

                richTextBox2.Text += returnstring;
                richTextBox2.Text += "///////////////////////////////////////\n";
                richTextBox2.Text += test.delegateUser("test\n", dgt1) + "\n";
            }
        }
        #endregion

        /// <summary>
        /// 泛型，ref
        /// </summary>
        /// <typeparam name="T">泛型，此方法约束为必须是struct</typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        private void Swap<T>(ref T a, ref T b) where T : struct
        {
            //将一个泛型变量设为默认值
            T d = default(T);
            T c = b;
            b = a;
            a = c;
        }

        /// <summary>
        /// params 可变数量参数
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string DisplayTypes(params Object[] list)
        {
            if (list != null)
            {
                string re = "";
                foreach (object item in list)
                {
                    re += (item == null) ? "null" : item.GetType().ToString();
                    re += "   ";
                }
                return re;
            }
            else
                return "null";
        }

        //===========================================
        //泛型的逆变与协变
        //-------
        //逆变用in标记,只能出现在输入位置
        //逆变可以从基类更改到任意派生类
        //-------
        //协变用out标记,只能出现在输出位置
        //逆变可以从派生类更改到基类
        //===========================================
        /// <summary>
        /// 泛型的逆变与协变
        /// </summary>
        /// <typeparam name="T">逆变量</typeparam>
        /// <typeparam name="TResult">协变量</typeparam>
        /// <param name="arg"></param>
        /// <returns></returns>
        public delegate TResult Func<in T, out TResult>(T arg);

        private string ClassAndStructTest(out string str2)
        {
            //DateTimeList为自定义的一个类型,见引用部分,其类型为List<T>
            DateTimeList dtl = new DateTimeList();

            //逆变协变的使用
            Func<Object, ArgumentException> fn1 = null;
            Func<string, Exception> fn2 = fn1;

            //可空值类型
            //若不为可空值类型，则其值不可为null
            Nullable<int> nullX = 3;
            int? nullY = 4;
            nullX = null;
            //当左边不为null，则等于左边，否则等于右边
            int? nullZ = nullX ?? nullY;
            nullY = nullX;
            nullZ = nullX ?? nullY ?? 5;

            try
            {
                Member m = new Member() { Nage = "123", Age = 5 - 3 };
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message);
            }
            //匿名类型
            var o1 = new { Name = "123", Age = -3, Sex = "F" };
            someClass sc = new someClass();
            someClass sc2 = new someClass();

            someStruct ss = new someStruct();
            someStruct ss2 = new someStruct();
            sc.x = 3;
            sc2 = sc;
            sc.x = 5;

            ss.x = 4;
            ss2 = ss;
            ss.x = 6;

            object o = ss.x;
            someStruct ss3 = new someStruct();
            someClass sc3 = new someClass();
            ss3.x = (int)o;
            sc3.x = (int)o;
            ss.x = 7;
            o = 9;

            int j = 3;
            int k = 9;
            if (j == k)
            {
            }
            MethodsClass.SetDouble(ref j);
            Swap(ref k, ref j);
            Test1<string> t1 = new Test1<string>();
            ITest1<string> t2 = t1;
            string t1r = t1.TestIMethod();
            string t2r = t2.TestIMethod();
            string str1 = @"/// <summary>
/// 引用类型，在内存中，传递指针
/// </summary>
class someClass
{
    public int x;
}
/// <summary>
/// 在线程栈中，复制值
/// </summary>
struct someStruct
{
    public int x;
}
someClass sc = new someClass();
someClass sc2 = new someClass();

someStruct ss = new someStruct();
someStruct ss2 = new someStruct();
sc.x = 3;
sc2 = sc;
sc.x = 5;

ss.x = 4;
ss2 = ss;
ss.x = 6;

object o = ss.x;
someStruct ss3 = new someStruct();
someClass sc3 = new someClass();
ss3.x = (int)o;
sc3.x = (int)o;
ss.x = 7
o = 9;
int j = 3;
int k = 9;
SetDouble(ref j);
Swap(ref k, ref j);
=====================================================================
";

            str2 = "sc=" + sc.x + "\n" + "sc2=" + sc2.x + "\n" + "ss=" + ss.x + "\n" + "ss2=" + ss2.x + "\n";
            str2 += "ss3=" + ss3.x + "\nsc3=" + sc3.x + "\no=" + o + "\nj.Triple()=" + j.Triple() + "\n";
            str2 += DisplayTypes(3, "ss", o, j, k, null);
            string a = null;
            //若a为空，则将x赋值给b
            string b = a ?? "x";
            return str1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Stopwatch用来记录代码执行时间
            Stopwatch watch = new Stopwatch();
            watch.Start();

            string str1 = "", str2 = "";

            str1 = ClassAndStructTest(str2: out str2);

            richTextBox1.Text = str1;
            richTextBox2.Text = str2;
            watch.Stop();
            richTextBox2.Text += "\n" + (watch.Elapsed) + "\n" + watch.ElapsedMilliseconds;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //Unregister(null);
        }

        /// <summary>
        /// 测试事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEventTest_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Heater heater = new Heater();
            //这里每次都重新定义一个heater并绑定一个方法到事件，实际运用中可在初始化时实例对象并绑定事件方法
            heater.HeaterEvent += (new HeaterEventTestClass(cts)).MakeAlarm;

            ThreadPool.QueueUserWorkItem(o => heater.Heat(cts.Token));
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            stringTest.testMethod();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ThreadTest tt = new ThreadTest();
            tt.threadWork();
        }
    }

    /// <summary>
    /// 引用类型，在内存中，传递指针
    /// </summary>
    internal class someClass
    {
        public int x;
    }

    /// <summary>
    /// 在线程栈中，复制值
    /// </summary>
    internal struct someStruct
    {
        public int x;
    }

    internal class stringTest
    {
        public static void testMethod()
        {
            char aaa = 'a';
            string aaa2 = "a";
            string aaa3 = (string)aaa2.Clone();
            string aaa4 = "3";
            //CompareTo方法受区域化影响，在不同的环境可能得到不同的结果
            int i = aaa2.CompareTo("333");
            bool isSame = aaa2.Equals("999");
            int k = aaa2.GetHashCode();
        }
    }

    public class ThreadTest
    {
        public ThreadTest()
        { }

        public void threadWork()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Token.Register(() => MessageBox.Show("5"));
            ThreadPool.QueueUserWorkItem(o => work2(cts.Token));
            ThreadPool.QueueUserWorkItem(new WaitCallback(work1), "1");

            cts.Cancel();
        }

        private void work1(object state)
        {
            int i = 3;
            for (int j = 1; j < 99; j++)
            {
                i = i * j / i;

                Thread.Sleep(1);
            }
            MessageBox.Show(i.ToString());
        }

        private void work2(CancellationToken token)
        {
            int i = 3;
            for (int j = 1; j < 99; j++)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }
                i = i * j / i;

                Thread.Sleep(1);
            }
        }
    }
}