//LibraryException
using System;

namespace csCourseWork
{
    class LibraryException : Exception
    {
        public LibraryException(string message)
        : base(message)
        {
            message = "Library Exception thrown";
        }
    }
}
