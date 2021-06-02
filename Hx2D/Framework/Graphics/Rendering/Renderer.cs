using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx2D.Framework.Graphics.Rendering
{
    public abstract class Renderer
    {
        protected GraphicsDevice GraphicsDevice;
        
        protected Renderer(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
        }
        
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime) {}
    }
}