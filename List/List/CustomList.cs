using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    /// <summary>
    /// This class keeps data in list. List has nodes which keep data.
    /// </summary>
    /// <typeparam name="T"> List might keeps generic data.User will be determine type data.</typeparam>
    public class CustomList<T>: IEnumerable<T>
    {
        Node<T> head;
        Node<T> tail;
        public int count { get; protected set; }

        /// <summary>
        /// This method adds new data in list.
        /// </summary>
        /// <param name="value">Value will be save in list. </param>
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
        /// Indexator will be to search value in list.Value index determine in input parameter.
        /// </summary>
        /// <param name="index"> Index which will be to use for search value in list.</param>
        /// <exception>
        /// IndexOutOfRangeException
        /// </exception>
        /// <returns> Value which was found </returns>
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
        /// This method insert new data in list by index.
        /// </summary>
        /// <exception >
        /// ArgumentOutOfRangeException
        /// </exception >
        /// <param name="index"> Value determine data which will be insert in list by index.  </param>
        /// <param name="value"> Index determine place insert new value in list. </param>
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
        /// This method removes data from list by determine value.Value determine in input parameter.
        /// </summary>
        /// <param name="value"> Value which have got to find and remove.</param>
        /// <returns> Return true if value was found and removed, and will return false if value was not found.</returns>
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
        /// This method exist for realization interface IEnumerable generic.
        /// </summary>
        /// <returns> Returns object which  realization interface  IEnumerator generic.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new CustomListIenumerator<T>(head);
        }

        /// <summary>
        /// This method exist for realizations interface IEnumerable.
        /// </summary>
        /// <returns> Returns object which  realizations interface  IEnumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    }



   





