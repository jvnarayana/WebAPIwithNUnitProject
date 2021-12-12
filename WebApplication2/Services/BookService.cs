using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Services
{
    public interface iBookService
    {
        IEnumerable<Book> GetAll();
        Book Add(Book newBook);
        Book GuiById(Guid id);
        void Remove(Guid id);


    }
    public class BookService: iBookService
    {
        public readonly List<Book> _books;

        public BookService()
        {
            _books = new List<Book>()
            {
                // I have used online GUID generator https://guidgenerator.com/online-guid-generator.aspx for generating GUIDs 

                new Book()
                {
                    Id = new Guid("6cfbfeed-da15-45c7-8894-e9fca9896be1"),
                    Title = "Maths",
                    Author = "Radha Krishna",
                    Description ="Algenra, Probability and statstics",
                },
                new Book()
                {
                    Id = new Guid("ef10077a-5961-4547-9821-b9910b6b197d"),
                    Title = "Physics",
                    Author = "Ramarao",
                    Description ="Theory of gravity"
                },
                new Book()
                {
                    Id = new Guid("d27edca2-733c-4832-99bf-34759c528c8e"),
                    Title = "Chemistry",
                    Author = "Narayana",
                    Description ="co2 component"
                },
                new Book()
                {
                    Id = new Guid("a1cffc11-250e-4580-9874-c943702c09a7"),
                    Title = "Biology",
                    Author = "Ramana",
                    Description ="Human Body"
                },


            };
           
        }
        public IEnumerable<Book> GetAll()
        {
            return _books;

        }
        public Book Add(Book newBook)
        {
             _books.Add(newBook);
            return newBook;
        }
        public Book GuiById(Guid id)
        {
          return  _books.Where(x => x.Id == id).FirstOrDefault();

        }
        //public void Remove(Guid id, out bool Flag)
        //{
        //    Flag = false;
        //    if (_books.Any(x => x.Id == id))
        //    {
        //        var record  = _books.First(x => x.Id == id);
        //        _books.Remove(record);
        //        Flag = true;
                
        //    }
            

        //}

        public void Remove(Guid id)
        {
           
            if (_books.Any(x => x.Id == id))
            {
                var record = _books.First(x => x.Id == id);
                _books.Remove(record);
               
            }
        }
    }
    

}
