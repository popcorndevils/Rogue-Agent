using SkiaSharp;
using SColor = SFML.Graphics.Color;
using SImage = SFML.Graphics.Image;
using STexture = SFML.Graphics.Texture;

namespace RogueAgent.Extensions
{
    public static class SKBitmapExtensions
    {
        public static STexture[]? ToSFML(this SKBitmap[] bmps)
        {
            if(bmps is not null)
            {
                STexture[] output = new STexture[bmps.Length];
                
                for(int i = 0; i < bmps.Length; i++)
                {
                    if(bmps[i] is not null)
                    {
                        STexture? t = bmps[i].ToSFML();
                        if(t is not null)
                        {
                            output[i] = t;
                        }
                    }
                }
                return output;
            }
            else
            {
                return null;
            }
        }
        
        public static STexture? ToSFML(this SKBitmap? bmp)
        {
            // TODO Move away from Bitmap which is windows only
            if(bmp is not null && OperatingSystem.IsWindows())
            {
                // set array to switch dimensions to rotate image
                SColor[,] sfml_color_array = new SColor[bmp.Width, bmp.Height];
                STexture new_image;

                for (int x = 0; x < bmp.Width; x++)
                {
                    for (int y = 0; y < bmp.Height; y++)
                    {
                        SKColor cs_color = bmp.GetPixel(x, y);
                        sfml_color_array[x, y] = new SColor(
                            cs_color.Red,
                            cs_color.Green,
                            cs_color.Blue,
                            cs_color.Alpha);
                    }
                }

                new_image = new STexture(new SImage(sfml_color_array));
                return new_image;
            }
            else
            {
                return null;
            }
        }
    }
}