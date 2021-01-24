using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{

    /// <summary>
    /// Class exists for interface implementation IEnumerator generic.
    /// </summary>
    /// <typeparam name="T"> This generic type determine what data type will to store in nodes.</typeparam>
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
                return currentNode.Value;
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
        /// Resetts unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Advances the enumerator to the next element of the collection.
        /// </summary>
        /// <returns> Returns true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection. </returns>
        public bool MoveNext()
        {
            if (currentNode == null)
            {
                currentNode = head;         
                return true;
            }
            if (currentNode.NextNode != null)
            {
                currentNode = currentNode.NextNode;
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
