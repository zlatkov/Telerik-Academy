namespace CohesionAndCoupling
{
    using System;

    public static class GeometryUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));
            return distance;
        }

        public static double CalcVolume(double width, double height, double depth)
        {
            double volume = width * height * depth;
            return volume;
        }

        public static double CalcDistanceToOrigin3D(double x, double y, double z)
        {
            double distance = CalcDistance3D(0, 0, 0, x, y, z);
            return distance;
        }

        public static double CalcDistanceToOrigin2D(double x, double y)
        {
            double distance = CalcDistance2D(0, 0, x, y);
            return distance;
        }
    }
}
