using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_1_PD_24__2_
{
    internal class FileLogger
    {
        private string _path;

        public FileLogger(string path)
        {
            _path = path;
        }

        public void Subscribe(MessagePublisher publisher)
        {
            publisher.MessageSent += OnMessage;
        }

        private void OnMessage(string message)
        {
            string log = DateTime.Now + " : " + message;
            File.AppendAllText(_path, log + "\n");
        }
    }
}