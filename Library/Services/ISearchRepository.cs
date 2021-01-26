using Library.Models;

namespace Library.Services
{
    public interface ISearchRepository
    {
        void Insert(Search search);

        ListSearch GetAllSerach();
    }
}