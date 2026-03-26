using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_PD_24__2_
{
    internal class MessagePublisher
    {
        public delegate void MessageHandler(string message);

        public event MessageHandler MessageSent;

        public void Send(string message)
        {
            Console.WriteLine("Send: " + message);
            MessageSent?.Invoke(message);
        }
    }
}