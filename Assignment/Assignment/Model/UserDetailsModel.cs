using Newtonsoft.Json;
using System;
using Xamarin.Forms;

namespace Assignment.Model
{
    public class UserDetailsModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email identifier.
        /// </summary>
        /// <value>
        /// The email identifier.
        /// </value>
        [JsonProperty("email")]
        public string EmailId { get; set; }

        /// <summary>
        /// Gets or sets the profile image URL.
        /// </summary>
        /// <value>
        /// The profile image URL.
        /// </value>
        [JsonProperty("avatar")]
        public string ProfileImageUrl { get; set; }

        /// <summary>
        /// Gets the profile image source.
        /// </summary>
        /// <value>
        /// The profile image source.
        /// </value>
        public ImageSource ProfileImageSource
        {
            get
            {
                return ImageSource.FromUri(new Uri(ProfileImageUrl));
            }
        }
        
    }
}
