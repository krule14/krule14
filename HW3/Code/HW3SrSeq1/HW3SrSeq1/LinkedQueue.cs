using System;
using System.Collections.Generic;
using System.Text;

namespace HW3SrSeq1
{

    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }

        public T Push(T element)
        {
            if (element == null)
            {
                throw new NullReferenceException();
            }
            if (IsEmpty())
            {
                Node<T> tmp = new Node<T>(element, next: null);
                rear = front = tmp;
            }
            else
            {
                //general case
                Node<T> tmp = new Node<T>(element, next: null);
                rear.next = tmp;
                rear = tmp;
            }
            return element;
        }

        public T Pop()
        {
            T tmp;
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if (front == rear)
            {
                //one item in queue
                tmp = front.data;
                front = null;
                rear = null;
            }
            else
            {
                //general case
                tmp = front.data;
                front = front.next;
            }
            return tmp;
        }
        public Boolean IsEmpty()
        {
            return (front == null && rear == null);
        }

    }
}