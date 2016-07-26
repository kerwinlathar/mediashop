using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaShopLibary
{
    public interface IitemRepository
    {
        List<Books> GetAllBooks();
        void UpdateBook(int BookIdToUppdate, Books updatebook);
        void RemoveBook(int BookIdToRemove);
        void AddBook(Books BookToAdd);

        List<DVD> GetAllDVDs();
        void UpdateDvds(int DvdIdToUppdate, DVD updatedvd);
        void RemoveDvds(int DvdIdToRemove);
        void AddDvd(DVD DvdToAdd);
    }
}
