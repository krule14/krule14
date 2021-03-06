﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HW3SrSeq1
{

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

}
