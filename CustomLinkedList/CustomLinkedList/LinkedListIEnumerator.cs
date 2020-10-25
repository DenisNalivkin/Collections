using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{
    class LinkedListIEnumerator<T> : IEnumerator<T>
    {
        Node<T> head;
        Node<T> tail;
        Node<T> currentNode;


        public LinkedListIEnumerator(Node<T> head, Node<T> tail)
        {
            this.head = head;
            this.tail = tail;
        }



        public T Current
        {
            get
            {
                return currentNode.value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return (object)this.Current;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool MoveNext()
        {
            
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
