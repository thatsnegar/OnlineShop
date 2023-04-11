namespace ViewModels.Paginations
{
    public class PageViewModel : object
    {
        public PageViewModel(int pageNumber, int pageSize = 8)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 8 || pageSize < 1 ? 8 : pageSize;
        }

        // **********
        public int PageNumber { get; set; }
        // **********

        // **********
        public int PageSize { get; set; }
        // **********
    }
}
