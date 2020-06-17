using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ObjEditor
{
    public partial class Form1 : Form
    {
        private ObjectInfo Figure;
        private ObjectInfo FigureOld;

        public Form1()
        {
            InitializeComponent();

            

        }

        private void Draw()
        {
            Bitmap Picture = new Bitmap(PictureBox.Width, PictureBox.Height);
            Graphics Canvas = Graphics.FromImage(Picture);
            Pen Pen = new Pen(Color.Black);
            Canvas.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var Element in Figure.GetConnectionsFVectorList())
            {
                FVector4 One = Figure.GetCoordinates(Element.X);
                FVector4 Two = Figure.GetCoordinates(Element.Y);
                Canvas.DrawLine(Pen, One.Y, One.Z, Two.Y, Two.Z);
            }

            PictureBox.Image = Picture;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            Figure = new ObjectInfo(PictureBox.Width, PictureBox.Height);
            FigureOld = new ObjectInfo(PictureBox.Width, PictureBox.Height);

            OpenFigure = new OpenFileDialog();
            OpenFigure.ShowDialog();

            if (OpenFigure.OpenFile() != null)
            {
                var SR = new StreamReader(OpenFigure.OpenFile());
                string AllLine = SR.ReadToEnd();
                string[] Line = AllLine.Split(';');

                foreach (var Element in Line)
                {
                    string[] ElementString = Element.Split(' ');

                    if (ElementString.Length == 4)
                    {
                        float ResultX;
                        float ResultY;
                        float ResultZ;
                        float ResultW;
                        float.TryParse(ElementString[0], out ResultX);
                        float.TryParse(ElementString[1], out ResultY);
                        float.TryParse(ElementString[2], out ResultZ);
                        float.TryParse(ElementString[3], out ResultW);

                        Figure.SetCoordinates(ResultX, ResultY, ResultZ, ResultW);
                        FigureOld.SetCoordinates(ResultX, ResultY, ResultZ, ResultW);
                    }

                    if (ElementString.Length == 3)
                    {
                        int PointPlaneOne;
                        int PointPlaneTwo;
                        int PointPlaneThree;
                        int.TryParse(ElementString[0], out PointPlaneOne);
                        int.TryParse(ElementString[1], out PointPlaneTwo);
                        int.TryParse(ElementString[2], out PointPlaneThree);
                        Figure.SetPlanePoint(new FVector(PointPlaneOne, PointPlaneTwo, PointPlaneThree));
                        FigureOld.SetPlanePoint(new FVector(PointPlaneOne, PointPlaneTwo, PointPlaneThree));
                    }
                }

                Draw();
            }
        }

        private void TranslationButton_Click(object sender, EventArgs e)
        {
            float ResultTranslationOX;
            float ResultTranslationOY;
            float ResultTranslationOZ;
            bool SuccessTranslationOX = float.TryParse(TranslationOX.Text, out ResultTranslationOX);
            bool SuccessTranslationOY = float.TryParse(TranslationOY.Text, out ResultTranslationOY);
            bool SuccessTranslationOZ = float.TryParse(TranslationOZ.Text, out ResultTranslationOZ);

            float[] Translation = new float[3] { ResultTranslationOX, ResultTranslationOY, ResultTranslationOZ };

            Figure.MoveObject(Translation);
            Draw();
        }

        private void RotationButton_Click(object sender, EventArgs e)
        {
            int ResultRotationOX;
            int ResultRotationOY;
            int ResultRotationOZ;
            bool SuccessRotationOX = int.TryParse(RotationOX.Text, out ResultRotationOX);
            bool SuccessRotationOY = int.TryParse(RotationOY.Text, out ResultRotationOY);
            bool SuccessRotationOZ = int.TryParse(RotationOZ.Text, out ResultRotationOZ);

            int[] Rotation = new int[3] { ResultRotationOX, ResultRotationOY, ResultRotationOZ };

            Figure.RotationObject(Rotation);
            Draw();
        }

        private void ScalingFactorButton_Click(object sender, EventArgs e)
        {
            float ResultScalingFactor;
            bool SuccessScalingFactor = float.TryParse(ScalingFactor.Text, out ResultScalingFactor);
            if (ResultScalingFactor == 0)
                ResultScalingFactor = 1;

            Figure.ScalingObject(ResultScalingFactor);
            Draw();
        }       

        private void ShiftButton_Click(object sender, EventArgs e)
        {
            float ResultShiftKxy;
            float ResultShiftKyx;

            float ResultShiftKxz;
            float ResultShiftKzx;

            float ResultShiftKyz;
            float ResultShiftKzy;

            bool SuccessShiftKxy = float.TryParse(KxyText.Text, out ResultShiftKxy);
            bool SuccessShiftKyx = float.TryParse(KyxText.Text, out ResultShiftKyx);

            bool SuccessShiftKxz = float.TryParse(KxzText.Text, out ResultShiftKxz);
            bool SuccessShiftKzx = float.TryParse(KzxText.Text, out ResultShiftKzx);

            bool SuccessShiftKyz = float.TryParse(KyzText.Text, out ResultShiftKyz);
            bool SuccessShiftKzy = float.TryParse(KzyText.Text, out ResultShiftKzy);

            float[] Shift = new float[6] 
            {
                ResultShiftKxy, ResultShiftKyx, ResultShiftKxz,
                ResultShiftKzx, ResultShiftKyz, ResultShiftKzy
            };

            Figure.ShiftObject(Shift);
            Draw();

        }

        private void SinglePointProjection_Click(object sender, EventArgs e)
        {
            float ResultSinglePointFx;
            float ResultSinglePointFy;
            float ResultSinglePointFz;

            bool SuccessSinglePointFx = float.TryParse(FxText.Text, out ResultSinglePointFx);
            bool SuccessSinglePointFy = float.TryParse(FyText.Text, out ResultSinglePointFy);
            bool SuccessSinglePointFz = float.TryParse(FzText.Text, out ResultSinglePointFz);

            float[] Point = new float[3]
            {
                ResultSinglePointFx, ResultSinglePointFy, ResultSinglePointFz
            };

            Figure.SinglePointObject(Point);
            Draw();
        }

        private void CentringButton_Click(object sender, EventArgs e)
        {
            Figure.CentringObject(PictureBox.Height / 2, PictureBox.Width / 2);
            Draw();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            Figure.RecoveryObject(FigureOld);
            Draw();
        }
    }

}
