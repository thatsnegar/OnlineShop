namespace ViewModels.Paginations
{
    public class PageViewModel : object
    {
        public PageViewModel(int pageNumber, int pageSize = 6)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 6 || pageSize < 1 ? 6 : pageSize;
        }

        // **********
        public int PageNumber { get; set; }
        // **********

        // **********
        public int PageSize { get; set; }
        // **********
    }
}
