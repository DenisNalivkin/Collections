using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Node<T>
    {
       public T Value { get;  set; }
        public Node<T> NextNode { get; set; }
     

        public Node()
        {

        }

        public Node(T value, Node<T> nextNode)
        {
            Value = value;
            NextNode = nextNode;
        }









    













    }
}
