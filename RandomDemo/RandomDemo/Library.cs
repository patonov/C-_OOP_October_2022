using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books) 
        {
            this.books = books.ToList();
        }

        public void Sort()
        { 
            BookComparator bookComparator = new BookComparator();
            books.Sort(bookComparator);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            //return books.GetEnumerator();
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int currentIndex;

            public LibraryIterator(List<Book> books)
            { 
                this.books = books;
                currentIndex = -1;
            }

            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {                
            }

            public bool MoveNext()
            {
                return ++this.currentIndex < books.Count;
            }

            public void Reset()
            {
                this.currentIndex = 0;
            }
        }
    }
}
