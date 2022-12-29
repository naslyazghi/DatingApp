using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class PaginationHeader
    {
        public PaginationHeader(int cuurentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            CuurentPage = cuurentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public int CuurentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}