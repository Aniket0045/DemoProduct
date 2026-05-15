using System;

namespace ProductApp.Exceptions
{

    public class ProductException : Exception
    {
        public ProductException(string message) : base(message) { }
    }

    public class ProductNotFoundException : ProductException
    {
        public ProductNotFoundException(int id)
            : base($"Product with ID {id} not found.") { }
    }

    public class DuplicateProductException : ProductException
    {
        public DuplicateProductException(int id)
            : base($"Product with ID {id} already exists.") { }
    }

    public class InvalidProductException : ProductException
    {
        public InvalidProductException(string message)
            : base(message) { }
    }
}