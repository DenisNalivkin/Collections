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
        Node<T> currentNode;

        public LinkedListIEnumerator(Node<T> head)
        {
            this.head = head;          
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
            if (currentNode == null)
            {
                currentNode = head;         
                return true;
            }
            if (currentNode.nextNode != null)
            {
                currentNode = currentNode.nextNode;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            currentNode = null;
        }
    }
}
