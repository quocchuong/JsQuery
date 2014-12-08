using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace johnLib
{
    /// <summary>
    /// Image Utils provide some general utilities to interact with Image object - produce image with Jpeg format (LIB COMPLETE)
    /// </summary>
    public static class ImageUtils
    {
        //set the format for target image
        public static ImageFormat TargetFormat = ImageFormat.Jpeg;

        public enum AnchorPosition
        {
            Top,
            Center,
            Bottom,
            Left,
            Right
        }

        /// <summary>
        /// Scale the source file by Percentage
        /// </summary>
        /// <param name="sourceFile">Source file full path</param>
        /// <param name="targetFile">Target file full path</param>
        /// <param name="percent">Scale Percentage</param>
        /// <param name="bgBrush">Background Brush - Using "Brushes." to set value</param>
        public static void ScaleByPercent(string sourceFile, string targetFile, float percent, Brush bgBrush)
        {
            Image img = ScaleByPercent(Image.FromFile(sourceFile), percent, bgBrush);

            img.Save(targetFile, TargetFormat);
            img.Dispose();            
        }

        /// <summary>
        /// Scale the source file by width
        /// </summary>
        /// <param name="sourceFile">Source file full path</param>
        /// <param name="targetFile">Target File full path</param>
        /// <param name="targetWidth">Target file width</param>
        /// <param name="bgBrush">Brush Style - Using "Brushes." to set value</param>
        public static void ScaleByWidth(string sourceFile, string targetFile, int targetWidth, Brush bgBrush)
        {
            Image imgSource = Image.FromFile(sourceFile);
            float percent = (float)targetWidth / (float)imgSource.Width;
            ScaleByPercent(sourceFile, targetFile, percent * 100, bgBrush);
            imgSource.Dispose();
        }

        /// <summary>
        /// Scale the source file by height
        /// </summary>
        /// <param name="sourceFile">Source file full path</param>
        /// <param name="targetFile">Target File full path</param>
        /// <param name="targetHeight">Target file Height</param>
        /// <param name="bgBrush">Brush Style - Using "Brushes." to set value</param>
        public static void ScaleByHeight(string sourceFile, string targetFile, int targetHeight, Brush bgBrush)
        {
            Image imgSource = Image.FromFile(sourceFile);
            float percent = (float)targetHeight / (float)imgSource.Height;
            ScaleByPercent(sourceFile, targetFile, percent * 100, bgBrush);
            imgSource.Dispose();
        }

        /// <summary>
        /// Scale image by width with WHITE brush style
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="targetFile"></param>
        /// <param name="targetWidth">in pixel</param>
        public static void ScaleByWidth(string sourceFile, string targetFile, int targetWidth)
        {
            ScaleByWidth(sourceFile, targetFile, targetWidth, Brushes.White);
        }

        /// <summary>
        /// Scale image by height with WHITE brush style
        /// </summary>
        /// <param name="sourceFile"></param>
        /// <param name="targetFile"></param>
        /// <param name="targetHeight"></param>
        public static void ScaleByHeight(string sourceFile, string targetFile, int targetHeight)
        {
            ScaleByHeight(sourceFile, targetFile, targetHeight, Brushes.White);
        }

        /// <summary>
        /// Scale Image by width - THIS FUNCTION WORKS WITH AN IMAGE OBJECT - NOT IMAGE FILE
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <param name="targetWidth"></param>
        /// <returns></returns>
        public static Image ScaleByWidth(Image imgPhoto, int targetWidth)
        {
            float percent = (float)targetWidth / (float)imgPhoto.Width;
            Image img = ScaleByPercent(imgPhoto, percent * 100, Brushes.White);
            return img;
        }

        /// <summary>
        /// Scale Image by Percentage - THIS FUNCTION WORKS WITH AN IMAGE OBJECT - NOT IMAGE FILE
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <param name="Percent"></param>
        /// <param name="bgBrush"></param>
        /// <returns></returns>
        public static Image ScaleByPercent(Image imgPhoto, float Percent, Brush bgBrush)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight, PixelFormat.Format24bppRgb);//, PixelFormat.Format32bppArgb);

            //bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics g = Graphics.FromImage(bmPhoto);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            g.FillRectangle(bgBrush, 0, 0, destWidth, destHeight);
            g.DrawImage(imgPhoto, 0, 0, destWidth, destHeight);

            g.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }
        
        /// <summary>
        /// Crop IMAGE Object
        /// </summary>
        /// <param name="imgPhoto">Image object</param>
        /// <param name="Width">Image Width - in Pixel</param>
        /// <param name="Height">Image Heigh - in Pixel</param>
        /// <param name="Anchor">AnchorPosition object</param>
        /// <returns></returns>
        public static Image Crop(Image imgPhoto, int Width, int Height, AnchorPosition Anchor)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);

            if (nPercentH > nPercentW)
            {
                nPercent = nPercentW;
                switch (Anchor)
                {
                    case AnchorPosition.Top:
                        destY = 0;
                        break;
                    case AnchorPosition.Bottom:
                        destY = (int)
                            (Height - (sourceHeight * nPercent));
                        break;
                    default:
                        destY = (int)
                            ((Height - (sourceHeight * nPercent)) / 2);
                        break;
                }
            }
            else
            {
                nPercent = nPercentH;
                switch (Anchor)
                {
                    case AnchorPosition.Left:
                        destX = 0;
                        break;
                    case AnchorPosition.Right:
                        destX = (int)
                          (Width - (sourceWidth * nPercent));
                        break;
                    default:
                        destX = (int)
                          ((Width - (sourceWidth * nPercent)) / 2);
                        break;
                }
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width,
                    Height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                    imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode =
                    InterpolationMode.HighQualityBicubic;
            grPhoto.FillRectangle(Brushes.White, 0, 0, Width, Height);

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        /// <summary>
        /// Crop Image using IMAGE FILE
        /// </summary>
        /// <param name="sourceFile">Full source file name and path</param>
        /// <param name="destFile">Full destination file name and path</param>
        /// <param name="targetWidth">Target file width</param>
        /// <param name="targetHeight">Target file height</param>
        public static void Crop(string sourceFile, string destFile, int targetWidth, int targetHeight)
        {
            Image imgSource = Image.FromFile(sourceFile);
            Image img = Crop(imgSource, targetWidth, targetHeight, AnchorPosition.Center);
            img.Save(destFile);
            imgSource.Dispose();
            img.Dispose();
        }

        /// <summary>
        /// get encoderInfo
        /// </summary>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                {
                    return encoders[j];
                }
            }
            return null;
        }
    }
}
