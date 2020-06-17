using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjEditor
{
    static class DefaultMatrix
    {
        private static FVector4[] MatrixList = new FVector4[4]
        {
            new FVector4(1, 0, 0, 0),
            new FVector4(0, 1, 0, 0),
            new FVector4(0, 0, 1, 0),
            new FVector4(0, 0, 0, 1)
        };

        public static void ClearMatrix()
        {
            MatrixList[0] = new FVector4(1, 0, 0, 0);
            MatrixList[1] = new FVector4(0, 1, 0, 0);
            MatrixList[2] = new FVector4(0, 0, 1, 0);
            MatrixList[3] = new FVector4(0, 0, 0, 1);            
        }

        public static FVector4[] ScalingMatrix(float k)
        {
            ClearMatrix();
            MatrixList[0].X = k;
            MatrixList[1].Y = k;
            MatrixList[2].Z = k;
            MatrixList[3].W = k;

            return MatrixList;
        }

        public static FVector4[] MovingMatrix(float X, float Y, float Z)
        {
            ClearMatrix();
            MatrixList[3].X = X;
            MatrixList[3].Y = Y;
            MatrixList[3].Z = Z;

            return MatrixList;
        }

        public static FVector4[] XRotationMatrix(int Angle)
        {
            ClearMatrix();
            float Radian = (float)(Math.PI * Angle / 180.0);

            MatrixList[1].Y = (float)Math.Cos(Radian);
            MatrixList[1].Z = -(float)Math.Sin(Radian);
            MatrixList[2].Y = (float)Math.Sin(Radian);
            MatrixList[2].Z = (float)Math.Cos(Radian);

            return MatrixList;
        }
        public static FVector4[] YRotationMatrix(int Angle)
        {
            ClearMatrix();
            float Radian = (float)(Math.PI * Angle / 180.0);

            MatrixList[0].X = (float)Math.Cos(Radian);
            MatrixList[0].Z = (float)Math.Sin(Radian);
            MatrixList[2].X = -(float)Math.Sin(Radian);
            MatrixList[2].Z = (float)Math.Cos(Radian);

            return MatrixList;
        }
        public static FVector4[] ZRotationMatrix(int Angle)
        {
            ClearMatrix();
            float Radian = (float)(Math.PI * Angle / 180.0);

            MatrixList[0].X = (float)Math.Cos(Radian);
            MatrixList[0].Y = -(float)Math.Sin(Radian);
            MatrixList[1].X = (float)Math.Sin(Radian);
            MatrixList[1].Y = (float)Math.Cos(Radian);

            return MatrixList;
        }

        public static FVector4[] ShiftMatrix(float[] Shift)
       {
            //float Kxy, float Kyx, float Kxz, float Kzx, float Kyz, float Kzy

            ClearMatrix();
            MatrixList[0].Y = Shift[0];
            MatrixList[0].Z = Shift[1];

            MatrixList[1].X = Shift[2];
            MatrixList[1].Z = Shift[3];

            MatrixList[2].X = Shift[4];
            MatrixList[2].Y = Shift[5];

           return MatrixList;
       }

        public static FVector4[] SinglePointMatrix(float[] Point)
        {
            ClearMatrix();  
            
            if(Point[0] != 0)
                MatrixList[0].W = - 1/Point[0];

            if (Point[1] != 0)
                MatrixList[1].W = - 1/Point[1];

            if (Point[2] != 0)
                MatrixList[2].W = - 1/Point[2];

            return MatrixList;
        }

        public static FVector4 MultiplicationMatrix(FVector4 Point, FVector4[] Matrix)
        {
            FVector4 PointReturn = new FVector4(0,0,0,1);

            float[] PointArray = new float[4] { Point.X, Point.Y, Point.Z, Point.W };

            float[,] MatrixArray = new float[4, 4] 
            { 
                { Matrix[0].X, Matrix[0].Y, Matrix[0].Z, Matrix[0].W }, 
                { Matrix[1].X, Matrix[1].Y, Matrix[1].Z, Matrix[1].W },
                { Matrix[2].X, Matrix[2].Y, Matrix[2].Z, Matrix[2].W },
                { Matrix[3].X, Matrix[3].Y, Matrix[3].Z, Matrix[3].W }
            };            

            for (int Index = 0; Index < 4; ++Index)
            {
                PointReturn.X += PointArray[Index] * MatrixArray[Index, 0];
                PointReturn.Y += PointArray[Index] * MatrixArray[Index, 1];
                PointReturn.Z += PointArray[Index] * MatrixArray[Index, 2];
                PointReturn.W += PointArray[Index] * MatrixArray[Index, 3];                
            }
            
            return PointReturn;
        }
    }
}
