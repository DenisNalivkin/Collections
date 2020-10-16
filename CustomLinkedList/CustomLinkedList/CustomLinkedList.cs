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
                Node<T> currentNode = new Node<T>();
                currentNode = head;
                for (int i = 0; i < index; i ++)
                {
                    if (index >= Count)
                    {
                        throw new System.NullReferenceException();
                    }
                    currentNode = currentNode.nextNode;
                }
                return currentNode.value;
            }

            set
            {
                Node<T> currentNode = new Node<T>();
                currentNode = head;
                for (int i = 0; i < index; i++)
                {
                    if (index >= Count)
                    {
                        throw new System.NullReferenceException();
                    }
                    currentNode = currentNode.nextNode;
                }
                currentNode.value = value;
                return;
            }
            
        }





    }
}
