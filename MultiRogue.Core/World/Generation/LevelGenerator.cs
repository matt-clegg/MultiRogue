using Toolbox;
using Toolbox.Rng;

namespace MultiRogue.Core.World.Generation
{
    public class LevelGenerator : BaseGenerator<Level>
    {
        private readonly int _width;
        private readonly int _height;

        private Array2D<byte> _tiles;

        public LevelGenerator(int width, int height, IRandom random) : base(random)
        {
            _width = width;
            _height = height;
        }

        public override Level Build()
        {
            return new Level(_tiles);
        }

        protected override void DoGeneration()
        {
            Tile wall = null;
            Tile floor = null;

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (x == 0 || y == 0 || x == _width - 1 || y == _height - 1)
                    {
                        SetTile(x, y, wall);
                    }
                    else
                    {
                        SetTile(x, y, floor);
                    }
                }
            }
        }

        private void SetTile(int x, int y, Tile tile)
        {
            _tiles[x, y] = tile.Id;
        }

        public Tile GetTile(int x, int y)
        {
            return Tile.GetTile(_tiles[x, y]);
        }

        protected override bool IsValid()
        {
            return true;
        }

        protected override void Reset()
        {
            _tiles = new Array2D<byte>(_width, _height);
        }
    }
}
