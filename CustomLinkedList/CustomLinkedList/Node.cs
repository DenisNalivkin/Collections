using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{
  public class Node <T>
    {
        T value { get; set; }
        Node<T> previousNode { get; set; }
        Node<T> nextNode { get; set; }

        public Node()
        {
        
        } 

    }
}
