using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountCards.Core.Domains.Maps
{
    public struct GeographicalCoordinates
    {
        public float Longtitude;
        public float Latitude;

        public GeographicalCoordinates(float longtitude, float latitude)
        {
            Longtitude = longtitude;
            Latitude = latitude;
        }

        public float DistanceTo(GeographicalCoordinates p1)
        {
            var kmInOneDegreeLongtitude = new double[] { 111.3, 109.6, 104.6, 96.5, 85.3, 71.1, 55.8, 38.2, 19.8};
            var kmInOneDegreeLatitude = 111;

            var difVector = p1 - this;

            var kmInLongtitude = kmInOneDegreeLongtitude[Math.Abs((int)difVector.Latitude / 10)] * difVector.Longtitude;
            var kmInLatitude = difVector.Latitude * kmInOneDegreeLatitude;

            return (float)Math.Sqrt(kmInLatitude * kmInLatitude + kmInLongtitude * kmInLongtitude); 
        }

        public static GeographicalCoordinates operator -(GeographicalCoordinates p1, GeographicalCoordinates p2) 
        {
            return new GeographicalCoordinates()
            {
                Latitude = p1.Latitude - p2.Latitude,
                Longtitude = p2.Longtitude - p2.Longtitude
            };
        }

        public override string ToString()
        {
            var format = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            var lat = Latitude.ToString(format);
            var lon = Longtitude.ToString(format);
            return $"{lon},{lat}";
        }
    }
}
