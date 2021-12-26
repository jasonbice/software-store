using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace SharedKernel
{
    public class SearchResponse<T> where T : class
    {
        /// <summary>
        /// The paged/sliced results.
        /// </summary>
        public IEnumerable<T> PagedItems { get; }

        /// <summary>
        /// The total number of results produced by the search request, prior to slicing/pagination.
        /// </summary>
        public int TotalItems { get; }

        /// <summary>
        /// The total number of pages in the result set produced by the search request.
        /// </summary>
        public int TotalPages { get; }

        private SearchResponse(IEnumerable<T> pagedItems, int totalItems, int totalPages)
        {
            PagedItems = pagedItems;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public static SearchResponse<T> FromResults(IQueryable<T> allItems, SearchRequestBase searchRequest)
        {
            // TODO: Validate legitimacy of SortBy
            var sortedItems = string.IsNullOrEmpty(searchRequest.SortBy)
                ? allItems
                : allItems.OrderBy($"{searchRequest.SortBy} {searchRequest.OrderByString}");

            var pagedItems = sortedItems
                .Skip((searchRequest.PageSize * searchRequest.Page) - searchRequest.PageSize)
                .Take(searchRequest.PageSize);

            var totalItems = allItems.Count();

            var totalPages = Convert.ToInt32(Math.Ceiling((double) totalItems / searchRequest.PageSize));

            return new SearchResponse<T>(pagedItems, totalItems, totalPages);
        }
    }
}