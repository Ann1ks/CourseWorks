//Library.cs
namespace csCourseWork
{
    class Library
    {
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value > 0)
                    number = value;
                else
                    throw new LibraryException("Number can not be less than zero.");
            }
        }

        private string author;
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (value != null)
                    author = value;
                else
                    throw new LibraryException("Author can not be empty.");
            }
        }
        private string book;
        public string Book
        {
            get
            {
                return book;
            }
            set
            {
                if (value != null)
                    book = value;
                else
                    throw new LibraryException("Book can not be empty.");
            }
        }

        private int copies;
        public int Copies
        {
            get
            {
                return copies;
            }
            set
            {
                if (value > 0)
                    copies = value;
                else
                    throw new LibraryException("Copies can not be less than zero.");
            }
        }

        private double price;
        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                if (value > 0)
                    price = value;
                else
                    throw new LibraryException("Price can not be less than zero.");
            }
        }

        /////////////////////////////////////////////////////////////////////
        public override string ToString()
        {
            return $" Inventory number: {Number}\r\n Author of book: {Author}\r\n Book name: {Book}\r\n Amount of copies: {Copies}\r\n Price of book: {Price}";
        }
        
        public string BinaryToString()
        {
            return $"Inventory number: {Number} \n Author of book: {Author} \n Book name: {Book} \n Amount of copies: {Copies} \n Price of book: {Price}";
        }
    }
}
