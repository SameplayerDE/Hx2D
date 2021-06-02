using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Hx2D.Framework.Graphics
{
    public class TileSet
    {
        public Texture2D Texture = null;
        public Texture2D[] Tiles;
        private readonly int _count = 0;
        public readonly Point TileSize;

        public TileSet(GraphicsDevice graphics, Texture2D texture, int tileW, int tileH)
        {
            TileSize = new Point(tileW, tileH);
            Texture = texture;
            var tileXCount = Texture.Width / tileW;
            var tileYCount = Texture.Height / tileH;
            _count = tileXCount * tileYCount;
            Tiles = new Texture2D[_count];

            for (var y = 0; y < tileYCount; y++)
            {
                for (var x = 0; x < tileXCount; x++)
                {
                    Tiles[x + tileXCount * y] = Util.CutTexture(graphics, texture, x * tileW, y * tileH, tileW, tileH);
                }
            }

        }

        public TileData GetTile(int index)
        {
            if (index < 0 || index >= _count)
            {
                return new TileData(null, false);
            }

            return new TileData(Tiles[index], true);
        }
    }

    public struct Tile
    {
        public bool IsValid;
        
    }

    public struct AnimatedTile
    {
        
    }

    public struct TileAnimation
    {
        
    }
    
    public struct TileAnimationStep
    {
        
    }
    
    public struct TileData
    {
        public Texture2D Tile;
        public bool IsValid;

        public TileData(Texture2D tile, bool valid)
        {
            Tile = tile;
            IsValid = valid;
        }
    }
    
}