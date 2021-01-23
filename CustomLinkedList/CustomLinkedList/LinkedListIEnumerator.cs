using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{

    /// <summary>
    /// This class exist for realization IEnumerator interface generic.
    /// </summary>
    /// <typeparam name="T"> This parameter will be the same like parameter generic from class CustomLinkedList.</typeparam>
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

        /// <summary>
        /// This method  does finalize object.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// This method goes over nodes in list and returh each current node for property Current.
        ///  Also returns value true when method could to send node for property Current.
        /// </summary>
        /// <returns> Returns value true when method could to send node for property Current. </returns>
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
