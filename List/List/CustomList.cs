using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
   public class CustomList<T>
    {
        Node<T> head;
        Node<T> tail;
        public int count { get; protected set; }

        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value, null);
                tail = head;
                count += 1;
                return;
            }

            Node<T> nodeToAdd = new Node<T>(value, null);
            tail.NextNode = nodeToAdd;
            tail = nodeToAdd;
            count += 1;
        }


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


    }
    }



    //insert   (remove(T value) : bool)      clear indexator





