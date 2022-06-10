using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Assignment.Control
{
    public class WebImage : Image
    {
        public static readonly BindableProperty WebImageSourceProperty = BindableProperty.Create(
          nameof(WebImageSource), typeof(string), typeof(Image), null, BindingMode.Default, null, null);

        public string WebImageSource
        {
            get { return (string)GetValue(WebImageSourceProperty); }
            set { this.SetValue(WebImageSourceProperty, value); }

        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(WebImageSource):
                   if(WebImageSource is null)
                    {
                        Source = null;
                    }
                   else
                    {
                        Source = ImageSource.FromUri(new Uri(WebImageSource));
                    }
                    break;
                case nameof(Source):
                    if (WebImageSource is null)
                    {
                        Source = null;
                    }
                    else
                    {
                        Source = ImageSource.FromUri(new Uri(WebImageSource));
                    }
                    break;
            }
        }
    }
}
