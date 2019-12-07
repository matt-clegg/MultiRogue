using System;
using System.Collections;
using System.Collections.Generic;

namespace Toolbox
{
    public class SafeList<T> : IEnumerable<T>, IEnumerable, IReadOnlyList<T>
    {
        private readonly List<T> _entities;
        private readonly List<T> _toAdd;
        private readonly List<T> _toRemove;

        private readonly HashSet<T> _current;
        private readonly HashSet<T> _adding;
        private readonly HashSet<T> _removing;

        public SafeList()
        {
            _entities = new List<T>();
            _toAdd = new List<T>();
            _toRemove = new List<T>();

            _current = new HashSet<T>();
            _adding = new HashSet<T>();
            _removing = new HashSet<T>();
        }

        public void UpdateLists()
        {
            if (_toAdd.Count > 0)
            {
                for (int i = 0; i < _toAdd.Count; i++)
                {
                    var T = _toAdd[i];
                    if (!_current.Contains(T))
                    {
                        _current.Add(T);
                        _entities.Add(T);
                    }
                }
            }

            if (_toRemove.Count > 0)
            {
                for (int i = 0; i < _toRemove.Count; i++)
                {
                    var T = _toRemove[i];
                    if (_entities.Contains(T))
                    {
                        _current.Remove(T);
                        _entities.Remove(T);
                    }
                }

                _toRemove.Clear();
                _removing.Clear();
            }

            if (_toAdd.Count > 0)
            {
                _toAdd.Clear();
                _adding.Clear();
            }
        }

        public void Add(T T)
        {
            if (!_adding.Contains(T) && !_current.Contains(T))
            {
                _adding.Add(T);
                _toAdd.Add(T);
            }
        }

        public void Remove(T T)
        {
            if (!_removing.Contains(T) && _current.Contains(T))
            {
                _removing.Add(T);
                _toRemove.Add(T);
            }
        }

        public void Add(IEnumerable<T> entities)
        {
            foreach (var T in entities)
            {
                Add(T);
            }
        }

        public void Remove(IEnumerable<T> entities)
        {
            foreach (var T in entities)
            {
                Remove(T);
            }
        }

        public void Add(params T[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                Add(entities[i]);
            }
        }

        public void Remove(params T[] entities)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                Remove(entities[i]);
            }
        }

        public int Count => _entities.Count;

        public T this[int index] {
            get {
                if (index < 0 || index >= _entities.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return _entities[index];
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T[] ToArray()
        {
            return _entities.ToArray();
        }
    }
}
