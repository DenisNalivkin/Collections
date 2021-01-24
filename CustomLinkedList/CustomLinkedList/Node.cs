using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{

    /// <summary>
    /// Class created for store data which after then will store in the list.
    /// </summary>
    /// <typeparam name="T"> Node keeps generic data. User will  determine type data.</typeparam>
    public class Node <T>
    {
       public T Value { get; set; }
       public Node<T> PreviousNode { get; set; }
       public Node<T> NextNode { get; set; }

        public Node()
        {
        
        }

        public Node( T value, Node<T> previousNode, Node<T> nextNode)
        {
            this.Value = value;
            this.PreviousNode = previousNode;
            this.NextNode = nextNode;
        }
    }
}
