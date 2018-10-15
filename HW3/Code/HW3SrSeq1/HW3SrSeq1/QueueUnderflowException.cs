using System;
using System.Collections.Generic;
using System.Text;

namespace HW3SrSeq1
{

    public class QueueUnderflowException : SystemException
    {
        public QueueUnderflowException() : base()
        {

        }
        public QueueUnderflowException(string message) : base(message)
        {

        }
    }
}