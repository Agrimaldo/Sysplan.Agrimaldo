
using System.Collections.Generic;

namespace Sysplan.Agrimaldo.Domain.Models
{
    public class ReturnStructure<T> where T : class
    {
        private bool success { get; set; }
        private IList<string> messages { get; set; }

        public bool Success => success;
        public IList<string> Messages => messages;
        public T Data { get; }
        protected ReturnStructure(T _data)
        {
            success = true;
            Data = _data;
            messages = new List<string>();
        }
        protected ReturnStructure(bool _success, List<string> _messages)
        {
            success = _success;
            messages = _messages;
        }
        public static ReturnStructure<T> Return(T obj)
        {
            return new ReturnStructure<T>(obj);
        }
        public static ReturnStructure<T> Return(bool _success, List<string> _messages)
        {
            return new ReturnStructure<T>(_success, _messages);
        }
        public static ReturnStructure<T> Return(bool _success, string message)
        {
            return new ReturnStructure<T>(_success, new List<string> { message });
        }
    }
}
