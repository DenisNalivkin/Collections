using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    /// <summary>
    /// Represents a  list of objects that can be accessed by index. 
    /// </summary>
    /// <typeparam name="T"> Represents the type of elements in the list.</typeparam>
    public class CustomList<T>: IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        public int count { get; protected set; }

        /// <summary>
        /// Adds a new element in the List.
        /// </summary>
        /// <param name="value">Data to be added in the List.</param>
        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value, null);
                tail = head;
                count += 1;
                return;
            }

            Node<T> newNode = new Node<T>(value, null);
            tail.NextNode = newNode;
            tail = newNode;
            count += 1;
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index"> Index which will to use for search value in list.</param>
        /// <exception>
        /// IndexOutOfRangeException
        /// </exception>
        /// <returns> Value which was found or exception if value was not found. </returns>
        public T this[int index]
        {
            get
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> node = head;
                for(int i =0; i<index;i++)
                {
                    node = node.NextNode;
                }
                return node.Value;
            }

            set
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException();
                }

                Node<T> node = head;
                for (int i = 0; i < index; i++)
                {
                    node = node.NextNode;
                }
                node.Value = value;
            }
        }

        /// <summary>
        /// Inserts a new element into the List at the specified index.
        /// </summary>
        /// <exception >
        /// ArgumentOutOfRangeException
        /// </exception >
        /// <param name="index"> Index at which element should be inserted.  </param>
        /// <param name="value"> The element which will insert. </param>
        public void Insert(int index, T value)
        {
            Node<T> currentNode = head;
            Node<T> previousNode = currentNode;
            Node<T> nodeToInsert = new Node<T>(value, null);

            if (index >= count)
            {
                throw new IndexOutOfRangeException();
            }
       
            else if (index == 0)
            {
                previousNode = currentNode;
                nodeToInsert.NextNode = previousNode;
                head = nodeToInsert;
                count += 1;
                return;            
            }
                
            for (int i = 0; i < index ; i ++)
            {
                previousNode = currentNode;
                currentNode = currentNode.NextNode;         
            }
            nodeToInsert.NextNode = currentNode;
            previousNode.NextNode = nodeToInsert;        
            count += 1;
        }

        /// <summary>
        /// Removes a specified element from the List.
        /// </summary>
        /// <param name="value"> The element which will remove from the List.</param>
        /// <returns>Returns true if element is successfully removed; otherwise, false. This method also returns false if element was not found in the List..</returns>
        public bool Remove(T value)
        {
            Node<T> currentNode = head;
            Node<T> previousNode = null;
            Node<T> nodeWithWantedValue = new Node<T>(value, currentNode.NextNode);
            bool valueResideInNode = false;

            while (currentNode != null)
            {
                valueResideInNode = currentNode.Value.Equals(nodeWithWantedValue.Value);

                if (valueResideInNode == true)
                {
                    if (previousNode != null)
                    {
                        previousNode.NextNode = currentNode.NextNode;
                        currentNode = head;
                    }
                    else
                    {
                        currentNode = currentNode.NextNode;
                        head = currentNode;
                    }
                    count -= 1;
                    return valueResideInNode;
                }

                previousNode = currentNode;
                currentNode = currentNode.NextNode;
            }

            return valueResideInNode;
        }

        /// <summary>
        /// This method removes all data from list.
        /// </summary>
        public void Clear ()
        {
            if (count != 0)
            {
                head = null;
                tail = null;
                count = 0;
                return;
            }
        }

        /// <summary>
        /// This method exists for interface implementation Ienumerable generic.
        /// </summary>
        /// <returns>  Returns object which implement interface IEnumerator generic.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomListIenumerator<T>(head);
        }

        /// <summary>
        /// This method exists for interface implementation  IEnumerable.
        /// </summary>
        /// <returns> Returns object which implement interface IEnumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    }



   





