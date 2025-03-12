using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class GeoCoordinates : IInit
    {
        private double latitude;
        private double longtitude; static double radius = 6371;
        public static int count = 0; static int minLatitude = -90;
        static int maxLatitude = 90; static int minLongtitude = -180;
        static int maxLongtitude = 180;
        private static Random random = new Random();
        public double GetRandom(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
        public GeoCoordinates(double latitude, double longtitude)
        {
            Latitude = latitude;
            Longtitude = longtitude; count++;
        }
        public GeoCoordinates(GeoCoordinates obj)
        {
            Latitude = obj.latitude;
            Longtitude = obj.longtitude; count++;
        }
        public GeoCoordinates()
        {
            Latitude = 0;
            Longtitude = 0; count++;
        }
        public double Latitude
        {
            get => latitude;
            set
            {
                if (value < minLatitude || value > maxLatitude)
                {
                    throw new ArgumentOutOfRangeException("Широта географической координаты должна быть пределах от -90 до 90");
                }
                latitude = value;
            }
        }
        public double Longtitude
        {
            get => longtitude;
            set
            {
                if (value < minLongtitude || value > maxLongtitude)
                {
                    throw new ArgumentOutOfRangeException("Долгота георграфических координат должна быть в пределах от -180 до 180");
                }
                else
                {
                    longtitude = value;
                }
            }
        }
        private static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
        public double Distance(double lo2, double la2)
        {
            double la = DegreesToRadians(la2 - Latitude);
            double lo = DegreesToRadians(lo2 - longtitude);
            double result = Math.Sin(la / 2) * Math.Sin(la / 2) + Math.Cos(DegreesToRadians(Latitude)) * Math.Cos(DegreesToRadians(la2)) * Math.Sin(lo / 2) * Math.Sin(lo / 2); double d = 2 * radius * Math.Atan2(Math.Sqrt(result), Math.Sqrt(1 - result));
            return Math.Round(d, 3);
        }
        public static double Distance(GeoCoordinates coordinatesFirst, GeoCoordinates coordinatesLast)
        {
            double la = DegreesToRadians(coordinatesLast.Latitude - coordinatesFirst.Latitude); double lo = DegreesToRadians(coordinatesLast.Longtitude - coordinatesFirst.Longtitude);

            double result = Math.Sin(la / 2) + Math.Sin(la / 2) + Math.Cos(DegreesToRadians(coordinatesFirst.Latitude)) * Math.Cos(DegreesToRadians(coordinatesLast.Latitude)) * Math.Sin(lo / 2) * Math.Sin(lo / 2);
            double d = 2 * radius * Math.Atan2(Math.Sqrt(result), Math.Sqrt(1 - result));
            return Math.Round(d, 3);
        }
        public void Show()
        {
            Console.WriteLine($"Широта = {Latitude}, Долгота = {Longtitude}");
        }
        public static GeoCoordinates operator ++(GeoCoordinates a)
        {
            return new GeoCoordinates(a.Longtitude += 0.001, a.Latitude += 0.001);
        }
        public static GeoCoordinates operator -(GeoCoordinates a)
        {
            return new GeoCoordinates(-a.Longtitude, -a.Latitude);
        }
        public static explicit operator bool(GeoCoordinates a)
        {
            return a.Latitude == 0;
        }
        public static implicit operator string(GeoCoordinates a)
        {
            if (a.Longtitude == 0)
            {
                return "Нулевой меридиан";
            }
            else if (a.Longtitude > 0)
            {
                return "Восточная долгота";
            }
            else if (a.Longtitude < 0)
            {
                return "Западная долгота";
            }
            return "";
        }
        public static bool operator ==(GeoCoordinates a, GeoCoordinates b)
        {
            if (a.Longtitude == b.Longtitude)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(GeoCoordinates a, GeoCoordinates b)
        {
            if (a.Latitude != b.Latitude)
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Широта: {Latitude}, Долгота: {Longtitude}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is GeoCoordinates)) { return false; }
            var objToCompare = obj as GeoCoordinates; if (Longtitude == objToCompare.Longtitude && Latitude == objToCompare.Latitude)
            {
                return true;
            }
            return false;
        }

        public void Init()
        {
            Latitude = Input.DoubleInput("Введите широту географической точки: ");
            Longtitude = Input.DoubleInput("Введите долготу географичекской точки: ");
        }

        public void RandomInit()
        {
            Latitude = GetRandom(-90, 90);
            Longtitude = GetRandom(-180, 180);
        }
    }
}