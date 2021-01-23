using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{

    /// <summary>
    /// This class exist for keep data which after then will be keep in list.
    /// </summary>
    /// <typeparam name="T"> Node might keeps generic data.User will be determine type data.</typeparam>
    public class Node <T>
    {
       public T value { get; set; }
       public Node<T> previousNode { get; set; }
       public Node<T> nextNode { get; set; }

        public Node()
        {
        
        }

        public Node( T value, Node<T> previousNode, Node<T> nextNode)
        {
            this.value = value;
            this.previousNode = previousNode;
            this.nextNode = nextNode;
        }
    }
}
