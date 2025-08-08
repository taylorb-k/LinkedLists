using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Utility
{
    [Serializable]
    public class Node<T>
    {
        // Properties
        private T data;
        private Node<T> next;

        // Constructor
        public Node(T data)
        {
            this.data = data;
            this.next = null;
        }

        // Getters and Setters
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}

