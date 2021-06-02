using Hx2D.Framework.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx2D.Framework.Graphics.Rendering
{
    public class RegionRenderer : Renderer
    {

        private readonly RegionLayerRenderer _layerRenderer;
        
        public RegionRenderer(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _layerRenderer = new RegionLayerRenderer(graphicsDevice);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Region region, TileSet tileSet)
        {
            foreach (var regionLayer in region.RegionData)
            {
                _layerRenderer.Draw(spriteBatch, gameTime, regionLayer, tileSet);
            }
        }
        
    }
}