using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx2D.Framework
{
    public static class Util
    {

        public static Texture2D CutTexture(GraphicsDevice graphics, Texture2D sheet, int x, int y, int w, int h)
        {
            // Get your texture
            Texture2D texture = sheet;

            // Calculate the cropped boundary
            Rectangle newBounds = new Rectangle(x, y, w, h);
            

            // Create a new texture of the desired size
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            Texture2D croppedTexture = new Texture2D(graphics, newBounds.Width, newBounds.Height);

            // Copy the data from the cropped region into a buffer, then into the new texture
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            Color[] data = new Color[newBounds.Width * newBounds.Height];
            texture.GetData(0, newBounds, data, 0, newBounds.Width * newBounds.Height);
            croppedTexture.SetData(data);
            return croppedTexture;
        }

    }
}
