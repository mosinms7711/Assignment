using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Assignment.Model
{
    public class UserDetailsModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string EmailId { get; set; }

        [JsonProperty("avatar")]
        public string ProfileImageUrl { get; set; }

        public ImageSource ProfileImageSource
        {
            get
            {
                return ImageSource.FromUri(new Uri(ProfileImageUrl));
            }
        }
        
    }
}
