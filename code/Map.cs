using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WMPio
{
    class Map
    {
        public List<Vertex> Vertices;
        public List<Region> Regions;
        public List<Wall> Walls;
        public List<PlayerStart> PlayerStarts;
        public List<Thing> Things;
        public List<Actor> Actors;
        public List<Way> Ways;

        public Map()
        {
            Vertices = new List<Vertex>();
            Regions = new List<Region>();
            Walls = new List<Wall>();
            PlayerStarts = new List<PlayerStart>();
            Things = new List<Thing>();
            Actors = new List<Actor>();
            Ways = new List<Way>();
        }

        public void Parse(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                Regex comment = new Regex(@"^[ \t]*#.*$");
                while ((line = reader.ReadLine()) != null)
                {
                    if (!comment.IsMatch(line) && !string.IsNullOrWhiteSpace(line))
                    {
                        string[] data = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] values = data[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        int index = int.Parse(Regex.Replace(data[1], @"[ \t#index]", ""));

                        string id = values[0].ToLower();
                        switch (id)
                        {
                            case "vertex":
                                AddVertex(index, values);
                                break;

                            case "region":
                                AddRegion(index, values);
                                break;

                            case "actor":
                                AddActor(index, values);
                                break;

                            case "thing":
                                AddThing(index, values);
                                break;

                            case "wall":
                                AddWall(index, values);
                                break;

                            case "player_start":
                                AddPlayerStart(index, values);
                                break;

                            case "way":
                                AddWay(index, values);
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void AddVertex(int index, string[] values)
        {
            float x = float.Parse(values[1], CultureInfo.InvariantCulture);
            float y = float.Parse(values[2], CultureInfo.InvariantCulture);
            float z = float.Parse(values[3], CultureInfo.InvariantCulture);

            Vertices.Add(new Vertex(x, y, z, index));
        }

        private void AddRegion(int index, string[] values)
        {
            string name = values[1];
            float floorHeight = float.Parse(values[2], CultureInfo.InvariantCulture);
            float ceilingHeight = float.Parse(values[3], CultureInfo.InvariantCulture);

            Region region = new Region(name, floorHeight, ceilingHeight, index);
            Regions.Add(region);
        }

        private void AddActor(int index, string[] values)
        {
            string name = values[1];
            float x = float.Parse(values[2], CultureInfo.InvariantCulture);
            float y = float.Parse(values[3], CultureInfo.InvariantCulture);
            float angle = float.Parse(values[4], CultureInfo.InvariantCulture);
            Region region = FindRegion(values[5]);

            Actor actor = new Actor(name, x, y, angle, region, index);
            Actors.Add(actor);
        }

        private void AddThing(int index, string[] values)
        {
            string name = values[1];
            float x = float.Parse(values[2], CultureInfo.InvariantCulture);
            float y = float.Parse(values[3], CultureInfo.InvariantCulture);
            float angle = float.Parse(values[4], CultureInfo.InvariantCulture);
            Region region = FindRegion(values[5]);

            Thing thing = new Thing(name, x, y, angle, region, index);
            Things.Add(thing);
        }

        private void AddWall(int index, string[] values)
        {
            string name = values[1];
            int vertex1Index = int.Parse(values[2]);
            int vertex2Index = int.Parse(values[3]);
            Region region1 = FindRegion(values[4]);
            Region region2 = FindRegion(values[5]);
            float offsetX = float.Parse(values[6], CultureInfo.InvariantCulture);
            float offsetY = float.Parse(values[7], CultureInfo.InvariantCulture);
            Vertex vertex1 = Vertices.Find(v => v.Index == vertex1Index);
            Vertex vertex2 = Vertices.Find(v => v.Index == vertex2Index);

            Wall wall = new Wall(name, vertex1, vertex2, region1, region2, offsetX, offsetY, index);
            Walls.Add(wall);
        }

        private void AddPlayerStart(int index, string[] values)
        {
            float x = float.Parse(values[1], CultureInfo.InvariantCulture);
            float y = float.Parse(values[2], CultureInfo.InvariantCulture);
            float angle = float.Parse(values[3], CultureInfo.InvariantCulture);
            Region region = FindRegion(values[4]);

            PlayerStart playerStart = new PlayerStart(x, y, angle, region, index);
            PlayerStarts.Add(playerStart);
        }

        private void AddWay(int index, string[] values)
        {
            string name = values[1];
            List<Point> points = new List<Point>();
            for (int i = 2; i < values.Length; i += 2)
            {
                float x = float.Parse(values[i], CultureInfo.InvariantCulture);
                float y = float.Parse(values[i + 1], CultureInfo.InvariantCulture);
                points.Add(new Point(x, y));
            }
            Ways.Add(new Way(name, points, index));
        }

        private Region FindRegion(string name)
        {
            Region region;
            if (int.TryParse(name, out int regionIndex))
                region = Regions.Find(r => r.Index == regionIndex); //new format
            else
            {
                region = Regions.Find(r => r.Name == name); //old format
                if (region == null)
                {
                    region = new Region(name);
                    Regions.Add(region);
                }
            }
            return region;
        }

    }
}
