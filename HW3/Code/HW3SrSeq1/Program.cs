using System;
using System.Collections.Generic;
using System.Text;

namespace HW3SrSeq1
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node(T data, Node<T> next)
        {
            this.data = data;
            this.next = next;
        }
    }

    public class QueueUnderflowException : SystemException
    {
        public QueueUnderflowException() : base()
        {

        }
        public QueueUnderflowException(String message) : base(message)
        {

        }
    }

    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> front;
        private Node<T> rear;

        public LinkedQueue()
        {
            front = null;
            rear = null;
        }
        public T push(T element)
        {
            if(element == null)
            {
                throw new NullPointerException();
            }
        }
        public T pop()
        {
            T hello;
            return hello;
        }
        public Boolean IsEmpty()
        {
            return true;
        }

    }

    public interface IQueueInterface<T>
    {
        /**
         * Add an element to the rear of the queue
         * 
         * @return the element that was enqueued
         */
        T Push(T element);
        /**
        * Remove and return the front element.
        * 
        * @throws Thrown if the queue is empty
        */
        T Pop(); // throws QueueUnderflowException;
        /**
        * Test if the queue is empty
        * 
        * @return true if the queue is empty; otherwise false
        */
        Boolean IsEmpty();
    }

    public class Main
    {
        /**
     * Print the binary representation of all numbers from 1 up to n.
     * This is accomplished by using a FIFO queue to perform a level 
     * order (i.e. BFS) traversal of a virtual binary tree that 
     * looks like this:
     *                 1
     *             /       \
     *            10       11
     *           /  \     /  \
     *         100  101  110  111
     *          etc.
     * and then storing each "value" in a list as it is "visited".
     */
        static LinkedList<string> generateBinaryRepresentationList(int n)
        {
            // Create an empty queue of strings with which to perform the traversal
            LinkedQueue<StringBuilder> q = new LinkedQueue<StringBuilder>();

            // A list for returning the binary values
            LinkedList<string> output = new LinkedList<string>();
            if (n < 1)
            {
                //binary representation of negative values is not supported 
                // return an empty list
                return output;
            }

            //enqueue the first binary number. Use dynamic string to avoid string concat
            q.push(new StringBuilder("1"));

            //BFS
            while (n-- > 0)
            {
                //print the front of queue
                StringBuilder sb = q.pop();
                output.AddLast(sb.ToString());

                //Make a copy
                StringBuilder sbc = new StringBuilder(sb.ToString());

                //Left child
                sb.Append('0');
                q.push(sb);

                //Right child
                sb.Append('1');
                q.push(sb);
            }
            return output;
        }

        //Driver program to test above function
        public static void main(string[] args)
        {
            int n = 10;
            if (args.Length < 1)
            {
                Console.WriteLine("Please invoke with the max value to print binary up to, like this:");
                Console.WriteLine("\tjava Main 12");
                return;
            }
            try
            {
                n = int.Parse(args[0]);
            } catch (FormatException e)
            {
                Console.WriteLine("I'm sorry, I can't understand the number: " + args[0]);
                return;
            }
            LinkedList<string> output = generateBinaryRepresentationList(n);
            // Print it right justified.  Longest string is the last one.
            // Print enough spaces to move it over the correct distance

            int maxLength = output.Last.Length;
            // this freaking line is a butt- try to fix
            foreach (string s in output)
            {
                for (int i = 0; i < maxLength - s.Length; ++i)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(s);
            }

        }


    }


    
}
