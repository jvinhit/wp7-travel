using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
using System.Linq;

namespace WindowsPhonePanoramaApplication1.Resources.Converters
{
    public class ItineraryTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var textBuilder = new StringBuilder();

            // Since value represents not well formatted XML which has no root element,
            // and the VirtualEarth prefix is not mapped to any namespace, we're
            // adding a fictitious root element which also maps the VirtualEarth prefix.
            string validXmlText = string.Format("<Directives xmlns:VirtualEarth=\"http://BingMaps\">{0}</Directives>", value);
            XDocument.Parse(validXmlText)
                     .Elements()
                     .Select(e => e.Value)
                     .ToList()
                     .ForEach(v => textBuilder.Append(v));

            return textBuilder.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
