namespace SharedKernel
{
    public abstract class SearchRequestBase
    {
        /// <summary>
        /// The zero-based page index that is being requested.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// The requested page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// The field by which the results should be sorted.
        /// </summary>
        public string SortBy { get; set; }

        /// <summary>
        /// True if the results should be sorted by <see cref="SortBy"/> in descending order; false otherwise.
        /// </summary>
        public bool SortDescending { get; set; }

        /// <summary>
        /// The query sort direction as per <see cref="SortDescending"/>.
        /// </summary>
        public string OrderByString => SortDescending ? "descending" : "ascending";
    }
}