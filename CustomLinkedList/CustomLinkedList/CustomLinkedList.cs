using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomLinkedList
{
    class CustomLinkedList<T>
    {
        Node<T> head { get; set; }
        Node<T> tail { get; set; }
        public int Count { get; set; }

        public CustomLinkedList()
        {

        }

        public void Add(T value)
        {
            Node<T> currentNode = new Node<T>();
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

        public T this[int index]
        {           
            get
            {
                if (index >= Count)
                {
                    throw new System.NullReferenceException();
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
                    throw new System.NullReferenceException();
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
            
    }





    }

