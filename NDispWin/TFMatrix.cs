using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using NSW.Net;

namespace NDispWin
{
    class TFMatrix
    {
        public static bool HeightLeastSquareFit(TPos2 pts, List<TPos3> points, ref double val)
        {
            // _h = mean of h
            // a0 = _a0, a1 = _a1, b = _h - _a0*_x - _a1*_y
            // h = a0*x + a1*y + b
            // h - _h = _a1*(x - _x) + _a1*(y - _y) + b

            double barX = 0; double barY = 0; double barH = 0; double barA0 = 0; double barA1 = 0;

            if (!Height3DMatrixPara(points, ref barX, ref barY, ref barH, ref barA0, ref barA1)) return false;

            val = barH + barA0 * (pts.X - barX) + barA1 * (pts.Y - barY);

            return true;
        }
        private static bool Height3DMatrixPara(List<TPos3> points, ref double barX, ref double barY, ref double barH, ref double barA0, ref double barA1)
        {
            var length = points.Count;
            TPos3 mean = new TPos3(0, 0, 0);

            //Mean of points
            for (int i = 0; i < length; i++)
                mean = new TPos3(mean.X + points[i].X, mean.Y + points[i].Y, mean.Z + points[i].Z);

            mean = new TPos3(mean.X / length, mean.Y / length, mean.Z / length);

            //Linear system matrix and vector elements
            double xxSum = 0; double xySum = 0; double xhSum = 0; double yySum = 0; double yhSum = 0;
            for (int i = 0; i < length; i++)
            {
                TPos3 diff = new TPos3(points[i].X - mean.X, points[i].Y - mean.Y, points[i].Z - mean.Z);
                xxSum += diff.X * diff.X;
                xySum += diff.X * diff.Y;
                xhSum += diff.X * diff.Z;
                yySum += diff.Y * diff.Y;
                yhSum += diff.Y * diff.Z;
            }

            double det = xxSum * yySum - xySum * xySum;
            if (det != 0)
            {
                barX = mean.X;
                barY = mean.Y;
                barH = mean.Z;
                barA0 = (yySum * xhSum - xySum * yhSum) / det;
                barA1 = (xxSum * yhSum - xySum * xhSum) / det;
                return true;
            }
            else
            {
                barX = 0;
                barY = 0;
                barH = 0;
                barA0 = 0;
                barA1 = 0;
                return false;
            }
        }
    }
}
