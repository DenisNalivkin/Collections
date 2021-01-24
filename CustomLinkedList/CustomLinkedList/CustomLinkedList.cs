using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{
    /// <summary>
    /// Represents a list of objects that can be accessed by index. 
    /// </summary>
    /// <typeparam name="T">Represents the type of elements in the list.</typeparam>
    public class CustomLinkedList<T>: IEnumerable<T>
    {
        Node<T> head { get; set; }
        Node<T> tail { get; set; }
        public int Count { get; set; }

        public CustomLinkedList()
        {

        }

        /// <summary>
        /// Adds a new element in the List.
        /// </summary>
        /// <param name="value">Data to be added in the List. </param>
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
            nodeWithNewValue.PreviousNode = tail;
            tail.NextNode = nodeWithNewValue;
            tail = nodeWithNewValue;
            Count += 1;
        }


        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">Index which will to use for search value in list.</param>
        /// <exception>
        /// ArgumentOutOfRangeException
        /// </exception>
        /// <returns> Value which was found or exception if value was not found.</returns>
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
                        currentNode = currentNode.NextNode;
                    }
                }
                else
                {
                    currentNode = tail;
                    for (int i = Count - 1; i > index; i--)
                    {
                        currentNode = currentNode.PreviousNode;
                    }
                }
                return currentNode.Value;
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
                        currentNode = currentNode.NextNode;
                    }
                    currentNode.Value = value;
                }
                else
                {
                    currentNode = tail;
                    for (int i = Count - 1; i > index; i--)
                    {
                        currentNode = currentNode.PreviousNode;
                    }
                    currentNode.Value = value;
                }
            }

        }

        /// <summary>
        /// Inserts a new element into the List at the specified index.
        /// </summary>
        /// <exception >
        /// ArgumentOutOfRangeException
        /// </exception>
        /// <param name="value"> The element which will insert.</param>
        /// <param name="index"> Index at which element should be inserted.</param>
        public void Insert(T value, int index)
        {
            if (index >= Count)
            {
                throw new System.ArgumentOutOfRangeException();
            }
            Node<T> currentNode = head;
            Node<T> nodeToInsert = new Node<T>(value, null, null);
            Node<T> previousNodeCopy;
            if (index == 0)
            {
                nodeToInsert.NextNode = head;
                head.PreviousNode = nodeToInsert;
                head = nodeToInsert;
                Count += 1;
                return;
            }
            if (index <= Count / 2)
            {
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                previousNodeCopy = currentNode.PreviousNode;
                nodeToInsert.NextNode = currentNode;
                nodeToInsert.PreviousNode = previousNodeCopy;
                currentNode.PreviousNode = nodeToInsert;
                currentNode = previousNodeCopy;
                currentNode.NextNode = nodeToInsert;
                Count += 1;
                return;
            }

            if (index > Count / 2)
            {
                currentNode = tail;
                for (int i = Count - 1; i > index; i--)
                {
                    currentNode = currentNode.PreviousNode;
                }
                previousNodeCopy = currentNode.PreviousNode;
                nodeToInsert.NextNode = currentNode;
                nodeToInsert.PreviousNode = previousNodeCopy;
                currentNode.PreviousNode = nodeToInsert;
                currentNode = previousNodeCopy;
                currentNode.NextNode = nodeToInsert;
                Count += 1;
                return;
            }
        }

        /// <summary>
        /// Removes a specified element from the List.
        /// </summary>
        /// <param name="value">The element which will remove from the List.</param>
        /// <returns>Returns true if element is successfully removed; otherwise, false. This method also returns false if element was not found in the List. </returns>
        public bool Remove(T value)
        {
            Node<T> currentNode = head;
            Node<T> previousNodeCopy;
            bool valueWasRemoved = false; 
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.Value.Equals(value) && currentNode == head)
                {
                    currentNode = currentNode.NextNode;
                    currentNode.PreviousNode = null;
                    head = currentNode;
                    valueWasRemoved = true;
                    Count -= 1;
                    return valueWasRemoved;
                }
                if (currentNode.Value.Equals(value) && currentNode == tail)
                {
                    currentNode = currentNode.PreviousNode;
                    currentNode.NextNode = null;
                    tail = currentNode;
                    Count -= 1;
                    valueWasRemoved = true;
                    return valueWasRemoved;
                }
                else if (currentNode.Value.Equals(value)) 
                {
                    currentNode = currentNode.PreviousNode;
                    previousNodeCopy = currentNode;
                    currentNode.NextNode = currentNode.NextNode.NextNode;
                    currentNode = currentNode.NextNode;
                    currentNode.PreviousNode = previousNodeCopy;                   
                    Count -= 1;
                    valueWasRemoved = true;
                    return valueWasRemoved;
                }
                currentNode = currentNode.NextNode;
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
        ///  This method exists for interface implementation Ienumerable generic.
        /// </summary>
        /// <returns>Returns object which implement interface IEnumerator generic.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListIEnumerator<T>(head);
        }

        /// <summary>
        /// This method exists for interface implementation  Ienumerable.
        /// </summary>
        /// <returns>
        /// Returns object which implement interface Ienumerator.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

