using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjEditor
{
    struct FVector4
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public FVector4(float SetX, float SetY, float SetZ, float SetW)
        {
            X = SetX;
            Y = SetY;
            Z = SetZ;
            W = SetW;
        }

        public static FVector4 operator +(FVector4 C1, FVector4 C2)
        {
           return new FVector4(C1.X + C2.X, C1.Y + C2.Y, C1.Z + C2.Z, C1.W);
        }

        public static FVector4 operator -(FVector4 C1, FVector4 C2)
        {
            return new FVector4(C1.X - C2.X, C1.Y - C2.Y, C1.Z - C2.Z, C1.W);
        }
    }

    struct FVector2D
    {
        public int X;
        public int Y;
        public FVector2D(int SetX, int SetY)
        {
            X = SetX;
            Y = SetY;
        }
    }
}
