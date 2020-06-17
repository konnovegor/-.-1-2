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

        public static FVector4 operator -(FVector4 C1)
        {
            return new FVector4(-C1.X, -C1.Y, -C1.Z, C1.W);
        }

        public static float OperatorDotProduct(FVector4 C1, FVector4 C2)
        {
            float X = C1.X * C2.X;
            float Y = C1.Y * C2.Y;
            float Z = C1.Z * C2.Z;

            return X + Y + Z;
        }

        public static FVector4 OperatorCrossProduct(FVector4 C1, FVector4 C2)
        {
            float I = C1.Y * C2.Z - C2.Y * C1.Z;
            float J = C1.X * C2.Z - C2.X * C1.Z;
            float K = C1.X * C2.Y - C2.X * C1.Y;

            return new FVector4(I, -J, K, 1);
        }

        public static float ModuleVector(FVector4 C1)
        {
            float I = C1.X * C1.X;
            float J = C1.Y * C1.Y;
            float K = C1.Z * C1.Z;

            return (float)Math.Sqrt((double)(I + J + K));
        }
    }

    struct FVector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public FVector(int SetX, int SetY, int SetZ)
        {
            X = SetX;
            Y = SetY;
            Z = SetZ;
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
