using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace WindowsFormsApp1
{
    class fun
    {
        IplImage src, gry, sobelX, sobely, tempx, tempy, lap, temp;


        public void LoadOriginalImage()
        {
            src = Cv.LoadImage("building.jpg", LoadMode.Color);
            Cv.SaveImage("1.jpg", src);
        }

        public void cnvertGray()
        {

            gry = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            Cv.CvtColor(src, gry, ColorConversion.RgbToGray);
            Cv.SaveImage("2.jpg", gry);

        }
        public void sobel() // detect edges
        {
            cnvertGray();
            sobelX = Cv.CreateImage(src.Size, BitDepth.U8, 1);
            sobely = Cv.CreateImage(src.Size, BitDepth.U8, 1);

            // create temp images
            tempx = Cv.CreateImage(src.Size, BitDepth.S16, 1);
            tempy = Cv.CreateImage(src.Size, BitDepth.S16, 1);

            Cv.Sobel(gry, tempx, 1, 0, ApertureSize.Size3);
            Cv.Sobel(gry, tempy, 0, 1, ApertureSize.Size3);

            // convert singed 16 to unsinged 8

            Cv.ConvertScaleAbs(tempx, sobelX);
            Cv.ConvertScaleAbs(tempy, sobely);

            //save

            Cv.SaveImage("sobelx.jpg", sobelX);
            Cv.SaveImage("sobely.jpg", sobely);
        }
        public void laplation() // detect edges
        {
            cnvertGray();
            lap = Cv.CreateImage(src.Size, BitDepth.U8, 1);


            // create temp images
            temp = Cv.CreateImage(src.Size, BitDepth.S16, 1);


            Cv.Laplace(gry, temp, ApertureSize.Size3);


            // convert singed 16 to unsinged 8

            Cv.ConvertScaleAbs(temp, lap);


            //save

            Cv.SaveImage("lap.jpg", lap);

        }
        public void laplationwithoutnoice() // detect edges
        {
            cnvertGray();
            Cv.Smooth(gry, gry, SmoothType.Gaussian);
            lap = Cv.CreateImage(src.Size, BitDepth.U8, 1);


            // create temp images
            temp = Cv.CreateImage(src.Size, BitDepth.S16, 1);


            Cv.Laplace(gry, temp, ApertureSize.Size3);


            // convert singed 16 to unsinged 8

            Cv.ConvertScaleAbs(temp, lap);


            //save

            Cv.SaveImage("lap2.jpg", lap);

        }




    }
}
