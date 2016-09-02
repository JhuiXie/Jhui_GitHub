using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JhClass.委托及事件
{
    class EventTest
    {
        private string message1 = "This is a message";
        private string message2 = "This is another message";
        private string message3 = "";

        public class TestEventArgs : EventArgs
        {
            public readonly string mess1;
            public readonly string mess2;
            public readonly string mess3; 
            public  TestEventArgs(string mess1,string mess2,string mess3)
            {
                this.mess1 = mess1;
                this.mess2 = mess2;
                this.mess3 = mess3;
            }
        }

        public delegate void TestEventHandler(object sender,TestEventArgs e);

        public event TestEventHandler testEvent;

        public void test()
        {
            int n = 0;
            for (int i = 0; i < 101;i++ )
            {
                n += i;
                if (i > 99)
                {
                    message3 = "The result is:" + n;
                    TestEventArgs e = new TestEventArgs(message1, message2, message3);
                    testEvent(this, e);
                }
            }
        }
    }
}
