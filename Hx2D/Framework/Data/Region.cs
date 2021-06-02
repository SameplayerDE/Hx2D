using System.IO;
using System.Xml.Serialization;

namespace Hx2D.Framework.Data
{
    public class Region
    {
        
        public readonly string Name;

        public readonly int Width;
        public readonly int Height;
        public readonly int Layers;
        
        public RegionLayer[] RegionData;
        
        public Region(string name, int width, int height, int layers)
        {
            Name = name;
            Width = width;
            Height = height;
            Layers = layers;
            
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            RegionData = new RegionLayer[layers];
            
            for (var i = 0; i < layers; i++)
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                RegionData[i] = new RegionLayer(this);
            }
        }

        #region Save and Load

        public static void SaveToXML(Region region, string path)
        {
            XmlRegion xmlRegion = XmlRegion.FromRegion(region);
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            XmlSerializer serializer = new XmlSerializer(typeof(XmlRegion));
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            TextWriter writer = new StreamWriter(path);
            serializer.Serialize(writer, xmlRegion);
            writer.Close();
        }
        
        public static Region LoadFromXML(string path)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            XmlSerializer serializer = new XmlSerializer(typeof(XmlRegion));
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            FileStream fileStream = new FileStream(path, FileMode.Open);
            XmlRegion xmlRegion = (XmlRegion) serializer.Deserialize(fileStream);
            
            return xmlRegion.ToRegion();
        }
        
        public static void LoadFromXML(ref Region region, string path)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            XmlSerializer serializer = new XmlSerializer(typeof(XmlRegion));
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            FileStream fileStream = new FileStream(path, FileMode.Open);
            XmlRegion xmlRegion = (XmlRegion) serializer.Deserialize(fileStream);
            region =  xmlRegion.ToRegion();
        }

        #endregion
    }

    public class RegionLayer
    {
        public Region Region;
        public int Width => Region.Width;   
        public int Height => Region.Height;
        
        public int[,] RegionLayerData;
        
        public RegionLayer(Region region)
        {
            Region = region;
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            RegionLayerData = new int[Width, Height];

            for (var y = 0; y < Height; y++)
            {
                for (var x = 0; x < Width; x++)
                {
                    RegionLayerData[x, y] = -1;
                }
            }
            
        }
    }

    public struct XmlRegion
    {
        public string Name;
        public int Width;
        public int Height;
        public int Layers;

        public XmlRegionLayer[] RegionData;

        public static XmlRegion FromRegion(Region region)
        {
            XmlRegion xmlRegion = new XmlRegion
            {
                Name = region.Name, Width = region.Width, Height = region.Height, Layers = region.Layers
            };

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            xmlRegion.RegionData = new XmlRegionLayer[xmlRegion.Layers];

            for (int i = 0; i < xmlRegion.Layers; i++)
            {
                xmlRegion.RegionData[i] = XmlRegionLayer.FromRegionLayer(region.RegionData[i]);
            }
            
            return xmlRegion;
        }

        public Region ToRegion()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            Region region = new Region(Name, Width, Height, Layers);
            for (int i = 0; i < Layers; i++)
            {
                RegionLayer regionLayer = RegionData[i].ToRegionLayer(region);
                region.RegionData[i] = regionLayer;
            }
            return region;
        }
    }
    
    public struct XmlRegionLayer
    {

        public int[] RegionLayerData;
        
        public static XmlRegionLayer FromRegionLayer(RegionLayer regionLayer)
        {
            XmlRegionLayer xmlRegionLayer = new XmlRegionLayer
            {
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                RegionLayerData = new int[regionLayer.Width * regionLayer.Height]
            };
            
            for (var y = 0; y < regionLayer.Height; y++)
            {
                for (var x = 0; x < regionLayer.Width; x++)
                {
                    xmlRegionLayer.RegionLayerData[x + regionLayer.Width * y] = regionLayer.RegionLayerData[x, y];
                }
            }
            
            return xmlRegionLayer;
        }
        
        public RegionLayer ToRegionLayer(Region region)
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            RegionLayer regionLayer = new RegionLayer(region);
            for (var y = 0; y < regionLayer.Height; y++)
            {
                for (var x = 0; x < regionLayer.Width; x++)
                {
                    regionLayer.RegionLayerData[x, y] = RegionLayerData[x + regionLayer.Width * y];
                }
            }
            return regionLayer;
        }
    }
}