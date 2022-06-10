using Newtonsoft.Json;
using System.Collections.Generic;

namespace Assignment.Model
{
    public class CommonResonseModel
    {
        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <value>
        /// The page.
        /// </value>
        [JsonProperty("page")]
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets the per page.
        /// </summary>
        /// <value>
        /// The per page.
        /// </value>
        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        [JsonProperty("total")]
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the total pages.
        /// </summary>
        /// <value>
        /// The total pages.
        /// </value>
        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the user details model list.
        /// </summary>
        /// <value>
        /// The user details model list.
        /// </value>
        [JsonProperty("data")]
        public List<UserDetailsModel> UserDetailsModelList { get; set; }
    }
}
