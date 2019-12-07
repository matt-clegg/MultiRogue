using System;
using Toolbox.Graphics;

namespace MultiRogue.Core.World
{
    public class Tile
    {
        private static readonly Tile[] _tiles = new Tile[byte.MaxValue];

        public byte Id { get; }
        public Sprite Sprite { get; }
        public bool IsSolid { get; }

        public Tile(byte id, Sprite sprite, bool isSolid)
        {
            Id = id;
            Sprite = sprite;
            IsSolid = isSolid;

            if (id < 0 || id >= _tiles.Length)
            {
                throw new ArgumentOutOfRangeException($"Invalid tile id: {id}. Must be between 0 and {_tiles.Length}");
            }

            if (_tiles[Id] != null)
            {
                throw new InvalidOperationException($"Duplicate tile id: {Id}");
            }

            _tiles[id] = this;
        }

        public static Tile GetTile(byte id)
        {
            if (id < 0 || id >= _tiles.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            Tile tile = _tiles[id];

            if (tile == null)
            {
                throw new InvalidOperationException($"Unknown tile id: {id}");
            }

            return tile;
        }
    }
}
