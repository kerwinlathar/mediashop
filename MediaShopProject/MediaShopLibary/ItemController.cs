using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MediaShopLibary
{
    public class ItemController:IitemRepository
    {
        private ModelMediaShopData content;

        public ItemController(ModelMediaShopData content)
        {
            this.content = content;
        }

        public List<Books> GetAllBooks()
        {
            return content.books.ToList();
        }

        public List<DVD> GetAllDVDs()
        {
            List<DVD> dvdlist = content.dvd.ToList();
            return dvdlist;
        }

        public void AddBook(Books BookToAdd)
        {
            content.books.Add(BookToAdd);
            content.SaveChanges();
            
        }

        virtual public void AddDvd(DVD DvdToAdd)
        {
            content.dvd.Add(DvdToAdd);
            content.SaveChanges();
        }

        public void RemoveBook(int BookIdToRemove)
        {
            var bookremove = content.books.Where(x => x.id == BookIdToRemove);
            foreach (Books book_check in bookremove)
            {
                if (book_check.id == BookIdToRemove)
                {
                    content.books.Remove(book_check);
                    
                }

            }
            content.SaveChanges();
        }

        public void RemoveDvds(int DvdIdToRemove)
        {
            var dvdremove = content.dvd.Where(x => x.id == DvdIdToRemove);
            foreach (DVD dvd_check in dvdremove)
            {
                if (dvd_check.id == DvdIdToRemove)
                {
                    content.dvd.Remove(dvd_check);
                }
                
            }
            content.SaveChanges();
        }

        public void UpdateBook(int BookIdToUppdate, Books updatebook)
        {
            var datatest = content.books.Where(x => x.id == BookIdToUppdate).Count();

            if (datatest != 0)
            {
                var databook = content.books.Where(x => x.id == BookIdToUppdate).First();

                if (updatebook.title != null)
                {
                    databook.title = updatebook.title;
                }

                if (updatebook.author != null)
                {
                    databook.author = updatebook.author;
                }

                if (updatebook.price != 0m)
                {
                    databook.price = updatebook.price;
                }
            }

            content.SaveChanges();
        }


        public void UpdateDvds(int DvdIdToUppdate, DVD updatedvd)
        {
            var datatest = content.dvd.Where(x => x.id == DvdIdToUppdate).Count();
            if (datatest != 0)
            {

                var datadvd = content.dvd.Where(x => x.id == DvdIdToUppdate).First();

                if (updatedvd.title != null)
                {
                    datadvd.title = updatedvd.title;
                }

                if (updatedvd.director != null)
                {
                    datadvd.director = updatedvd.director;
                }

                if (updatedvd.price != 0m)
                {
                    datadvd.price = updatedvd.price;
                }
            }

            content.SaveChanges();
        }

        

        
    }
}
