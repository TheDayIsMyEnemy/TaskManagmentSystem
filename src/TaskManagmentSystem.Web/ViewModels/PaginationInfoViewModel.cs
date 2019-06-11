using System;

namespace TaskManagmentSystem.Web.ViewModels
{
    public class PaginationInfoViewModel
    {
        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);

        public int PreviousPage => CurrentPage > 1 ? CurrentPage - 1 : CurrentPage;

        public int NextPage => CurrentPage < TotalPages ? CurrentPage + 1 : CurrentPage;
    }
}
