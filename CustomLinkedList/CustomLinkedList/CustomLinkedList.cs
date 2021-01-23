using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{
    /// <summary>
    /// This class keeps data in list.List has nodes which keep data.
    /// </summary>
    /// <typeparam name="T">List might keeps generic data.User will be determine type data.</typeparam>
  public class CustomLinkedList<T>: IEnumerable<T>
    {
        Node<T> head { get; set; }
        Node<T> tail { get; set; }
        public int Count { get; set; }

        public CustomLinkedList()
        {

        }

        /// <summary>
        /// This method adds new data in list.
        /// </summary>
        /// <param name="value">Value will be save in list. </param>
        public void Add(T value)
        {
            Node<T> nodeWithNewValue = new Node<T>(value, null, null);
            if (head == null)
            {
                head = nodeWithNewValue;
                tail = head;
                Count += 1;
                return;
            }
            nodeWithNewValue.previousNode = tail;
            tail.nextNode = nodeWithNewValue;
            tail = nodeWithNewValue;
            Count += 1;
        }




        /// <summary>
        /// Indexator will be to search value in list.Value index determine in input parameter. 
        /// </summary>
        /// <param name="index">Index which will be to use for search value in list </param>
        /// <exception>
        /// ArgumentOutOfRangeException
        /// </exception>
        /// <returns> Value which was found. </returns>
        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new System.ArgumentOutOfRangeException();
                }

                Node<T> currentNode = new Node<T>();
                if (index < Count / 2)
                {
                    currentNode = head;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.nextNode;
                    }
                }
                else
                {
                    currentNode = tail;
                    for (int i = Count - 1; i > index; i--)
                    {
                        currentNode = currentNode.previousNode;
                    }
                }
                return currentNode.value;
            }

            set
            {
                if (index >= Count)
                {
                    throw new System.ArgumentOutOfRangeException();
                }

                Node<T> currentNode = new Node<T>();
                if (index < Count / 2)
                {
                    currentNode = head;
                    for (int i = 0; i < index; i++)
                    {
                        currentNode = currentNode.nextNode;
                    }
                    currentNode.value = value;
                }
                else
                {
                    currentNode = tail;
                    for (int i = Count - 1; i > index; i--)
                    {
                        currentNode = currentNode.previousNode;
                    }
                    currentNode.value = value;
                }
            }

        }

        /// <summary>
        /// This method insert new data in list by index.
        /// </summary>
        /// <exception >
        /// ArgumentOutOfRangeException
        /// </exception>
        /// <param name="value"> Value determine data which will be insert in list by index. </param>
        /// <param name="index"> Index determine place insert new value in list. </param>
        public void Insert(T value, int index)
        {
            if (index >= Count)
            {
                throw new System.ArgumentOutOfRangeException();
            }
            Node<T> currentNode = head;
            Node<T> nodeWithValueInsert = new Node<T>(value, null, null);
            Node<T> copyPreviousNodeLocatedBeforeInsertValueNode;
            if (index == 0)
            {
                nodeWithValueInsert.nextNode = head;
                head.previousNode = nodeWithValueInsert;
                head = nodeWithValueInsert;
                Count += 1;
                return;
            }
            if (index <= Count / 2)
            {
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.nextNode;
                }
                copyPreviousNodeLocatedBeforeInsertValueNode = currentNode.previousNode;
                nodeWithValueInsert.nextNode = currentNode;
                nodeWithValueInsert.previousNode = copyPreviousNodeLocatedBeforeInsertValueNode;
                currentNode.previousNode = nodeWithValueInsert;
                currentNode = copyPreviousNodeLocatedBeforeInsertValueNode;
                currentNode.nextNode = nodeWithValueInsert;
                Count += 1;
                return;
            }

            if (index > Count / 2)
            {
                currentNode = tail;
                for (int i = Count - 1; i > index; i--)
                {
                    currentNode = currentNode.previousNode;
                }
                copyPreviousNodeLocatedBeforeInsertValueNode = currentNode.previousNode;
                nodeWithValueInsert.nextNode = currentNode;
                nodeWithValueInsert.previousNode = copyPreviousNodeLocatedBeforeInsertValueNode;
                currentNode.previousNode = nodeWithValueInsert;
                currentNode = copyPreviousNodeLocatedBeforeInsertValueNode;
                currentNode.nextNode = nodeWithValueInsert;
                Count += 1;
                return;
            }
        }

        /// <summary>
        /// This method removes data from list by determine value.Value determine in input parameter.
        /// </summary>
        /// <param name="value">Value which have got to find and remove.</param>
        /// <returns>Return true if value was found and removed, and will return false if value was not found. </returns>
        public bool Remove(T value)
        {
            Node<T> currentNode = head;
            Node<T> copyPreviousNodeLocatedBeforeRemoveNode;
            bool valueWasRemoved = false; 
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.value.Equals(value) && currentNode == head)
                {
                    currentNode = currentNode.nextNode;
                    currentNode.previousNode = null;
                    head = currentNode;
                    valueWasRemoved = true;
                    Count -= 1;
                    return valueWasRemoved;
                }
                if (currentNode.value.Equals(value) && currentNode == tail)
                {
                    currentNode = currentNode.previousNode;
                    currentNode.nextNode = null;
                    tail = currentNode;
                    Count -= 1;
                    valueWasRemoved = true;
                    return valueWasRemoved;
                }
                else if (currentNode.value.Equals(value)) 
                {
                    currentNode = currentNode.previousNode;
                    copyPreviousNodeLocatedBeforeRemoveNode = currentNode;
                    currentNode.nextNode = currentNode.nextNode.nextNode;
                    currentNode = currentNode.nextNode;
                    currentNode.previousNode = copyPreviousNodeLocatedBeforeRemoveNode;                   
                    Count -= 1;
                    valueWasRemoved = true;
                    return valueWasRemoved;
                }
                currentNode = currentNode.nextNode;
            }
            return valueWasRemoved;
        }

        /// <summary>
        /// This method removes all data from list.
        /// </summary>
        public void Clear()
        {
            if (head != null)
            {
                head = null;
                tail = null;
                Count = 0;            
            }
        }


        /// <summary>
        ///  This method exist for realization interface IEnumerable generic.
        /// </summary>
        /// <returns>Returns object which  realizations interface  IEnumerator generic.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListIEnumerator<T>(head);
        }

        /// <summary>
        /// This method exist for realization interface IEnumerable.
        /// </summary>
        /// <returns>
        /// Returns object which  realizations interface  IEnumerator.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

