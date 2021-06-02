using System;
using Hx2D.Framework.Data;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx2D.Framework.Graphics.Rendering
{
    public class RegionLayerRenderer : Renderer
    {
        public RegionLayerRenderer(GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }
        
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, RegionLayer regionLayer, TileSet tileSet)
        {
            //Render Layer
            for (var y = 0; y < regionLayer.Height; y++)
            {
                for (var x = 0; x < regionLayer.Width; x++)
                {
                    int index = regionLayer.RegionLayerData[x, y];
                    TileData tile = tileSet.GetTile(index);
                    if (!tile.IsValid)
                    {
                        continue;
                    }
                    // ReSharper disable once PossiblyImpureMethodCallOnReadonlyVariable
                    spriteBatch.Draw(tile.Tile, new Vector2(x, y) * tileSet.TileSize.ToVector2(), Color.White);
                }
            }
        }
    }
}