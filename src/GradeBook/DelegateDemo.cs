using System;

namespace GradeBook
{
    class DelegateDemo
    {
        private int count = 0;
        public delegate string WriteALogMessage(string msg);

        public string JustCount(string message)
        {
            count++;
            return null;
        }
        
        public string WriteLogAndCount(string message)
        {
            count++;
            return $"Message {message} logged and count is {count}.";
        }

        public void DoAllDelegateActions(string message)
        {
            WriteALogMessage log;
            log = JustCount;
            log += WriteLogAndCount;
            Console.WriteLine(log(message));
        }
    }
}