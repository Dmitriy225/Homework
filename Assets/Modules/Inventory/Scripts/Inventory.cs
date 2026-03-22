using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

namespace Modules.Inventories
{
    public class Inventory : IEnumerable<Item>
    {
        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        public int Width => _width;
        public int Height => _height;
        public int Count => _items.Count;

        private readonly int _width;
        private readonly int _height;
        private readonly Dictionary<Item, Vector2Int> _items;
        private readonly Item[,] _matrix;

        public Inventory(int width, int height)
        {
            if (!IsValidSize(width, height))
            {
                throw new ArgumentException();
            }

            _width = width;
            _height = height;
            _items = new Dictionary<Item, Vector2Int>();
            _matrix = new Item[width, height];
        }

        public Inventory(
            int width,
            int height,
            params KeyValuePair<Item, Vector2Int>[] items
        ) : this(width, height, (IEnumerable<KeyValuePair<Item, Vector2Int>>)items)
        {

        }

        public Inventory(
            int width,
            int height,
            params Item[] items
        ) : this(width, height, (IEnumerable<Item>)items)
        {

        }

        public Inventory(
            int width,
            int height,
            IEnumerable<KeyValuePair<Item, Vector2Int>> items
        ) : this(width, height)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in items)
            {
                AddItemSilently(item.Key, item.Value);
            }
        }

        public Inventory(
            int width,
            int height,
            IEnumerable<Item> items
        ) : this(width, height)
        {
            if (items == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in items)
            {
                AddItemSilently(item);
            }
        }

        /// <summary>
        /// Creates new inventory 
        /// </summary>
        public Inventory(Inventory inventory) : this(inventory.Width, inventory.Height)
        {
            inventory.CopyTo(_matrix);
        }

        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(Item item, Vector2Int position)
        {
            return CanAddItem(item, position.x, position.y);
        }

        public bool CanAddItem(Item item, int startX, int startY)
        {
            if (item == null)
            {
                return false;
            }

            var size = item.Size;

            if (!IsValidSize(size.x, size.y))
            {
                throw new ArgumentException();
            }

            return !_items.ContainsKey(item)
                && IsFreeSpace(startX, startY, size.x, size.y);
        }

        /// <summary>
        /// Adds an item on a specified position
        /// </summary>
        public bool AddItem(Item item, Vector2Int position)
        {
            return AddItem(item, position.x, position.y);
        }

        public bool AddItem(Item item, int startX, int startY)
        {
            if (!AddItemSilently(item, startX, startY))
            {
                return false;
            }

            OnAdded?.Invoke(item, new Vector2Int(startX, startY));
            return true;
        }

        private bool AddItemSilently(Item item, Vector2Int position)
        {
            return AddItemSilently(item, position.x, position.y);
        }

        private bool AddItemSilently(Item item, int startX, int startY)
        {
            if (!CanAddItem(item, startX, startY))
            {
                return false;
            }

            _items.Add(item, new Vector2Int(startX, startY));

            var size = item.Size;
            FillMatrixSpace(startX, startY, size.x, size.y, item);

            return true;
        }

        private void FillMatrixSpace(int startX, int startY, int sizeX, int sizeY, Item item)
        {
            for (int x = startX; x < startX + sizeX; x++)
            {
                for (int y = startY; y < startY + sizeY; y++)
                {
                    _matrix[x, y] = item;
                }
            }
        }

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(Item item)
        {
            return FindFreePosition(item, out var position)
                && CanAddItem(item, position);
        }

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(Item item)
        {
            if (!AddItemSilently(item, out var position))
            {
                return false;
            }

            OnAdded?.Invoke(item, new Vector2Int(position.x, position.y));
            return true;
        }

        private bool AddItemSilently(Item item)
        {
            return FindFreePosition(item, out var position)
                && AddItemSilently(item, position.x, position.y);
        }

        private bool AddItemSilently(Item item, out Vector2Int position)
        {
            return FindFreePosition(item, out position)
                && AddItemSilently(item, position.x, position.y);
        }

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(Item item, out Vector2Int position)
        {
            if (item == null)
            {
                position = new Vector2Int();
                return false;
            }

            return FindFreePosition(item.Size, out position);
        }

        public bool FindFreePosition(Vector2Int size, out Vector2Int position)
        {
            return FindFreePosition(size.x, size.y, out position);
        }

        public bool FindFreePosition(int sizeX, int sizeY, out Vector2Int position)
        {
            if (!IsValidSize(sizeX, sizeY))
            {
                throw new ArgumentException();
            }

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    if (IsOccupied(x, y))
                    {
                        continue;
                    }

                    if (IsFreeSpace(x, y, sizeX, sizeY))
                    {
                        position = new Vector2Int(x, y);
                        return true;
                    }
                }
            }

            position = new Vector2Int();
            return false;
        }

        private bool IsFreeSpace(int startX, int startY, int width, int height)
        {
            if (!ContainsSpace(startX, startY, width, height))
            {
                return false;
            }

            for (int x = startX; x < startX + width; x++)
            {
                for (int y = startY; y < startY + height; y++)
                {
                    if (IsOccupied(x, y))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool ContainsSpace(int startX, int startY, int width, int height)
        {
            return startX >= 0
                && startY >= 0
                && startX + width <= _width
                && startY + height <= _height;
        }

        private bool ContainsPosition(int x, int y)
        {
            return x >= 0
                && y >= 0
                && x < _width
                && y < _height;
        }

        private bool IsValidSize(int width, int height)
        {
            return width > 0 && height > 0;
        }

        private bool IsValidItem(Item item)
        {
            return item != null && _items.ContainsKey(item);
        }

        /// <summary>
        /// Checks if the specified element exists
        /// </summary>
        public bool Contains(Item item)
        {
            return item != null && _items.ContainsKey(item);
        }

        /// <summary>
        /// Checks if the specified position is occupied
        /// </summary>
        public bool IsOccupied(Vector2Int position)
        {
            return _matrix[position.x, position.y] != null;
        }

        public bool IsOccupied(int x, int y)
        {
            return _matrix[x, y] != null;
        }

        /// <summary>
        /// Checks if the specified position is free
        /// </summary>
        public bool IsFree(Vector2Int position)
        {
            return _matrix[position.x, position.y] == null;
        }

        public bool IsFree(int x, int y)
        {
            return _matrix[x, y] == null;
        }

        /// <summary>
        /// Removes specified item
        /// </summary>
        public bool RemoveItem(Item item)
        {
            return RemoveItem(item, out Vector2Int _);
        }

        public bool RemoveItem(Item item, out Vector2Int position)
        {
            if (!RemoveItemSilently(item, out position))
            {
                return false;
            }

            OnRemoved?.Invoke(item, position);
            return true;
        }

        private bool RemoveItemSilently(Item item)
        {
            return RemoveItemSilently(item, out Vector2Int _);
        }

        private bool RemoveItemSilently(Item item, out Vector2Int position)
        {
            if (!IsValidItem(item))
            {
                position = Vector2Int.zero;
                return false;
            }

            if (_items.Remove(item, out position))
            {
                var size = item.Size;
                FillMatrixSpace(position.x, position.y, size.x, size.y, null);
            }          

            return true;
        }

        /// <summary>
        /// Returns an item at specified position 
        /// </summary>
        public Item GetItem(Vector2Int position)
        {
            return _matrix[position.x, position.y];
        }

        public Item GetItem(int x, int y)
        {
            return _matrix[x, y];
        }

        public bool TryGetItem(Vector2Int position, out Item item)
        {
            return TryGetItem(position.x, position.y, out item);
        }

        public bool TryGetItem(int x, int y, out Item item)
        {
            if (!ContainsPosition(x, y))
            {
                item = null;
                return false;
            }

            item = _matrix[x, y];
            return item != null;
        }

        /// <summary>
        /// Returns positions of a specified item 
        /// </summary>
        public Vector2Int[] GetPositions(Item item)
        {
            var size = item.Size;
            int sizeX = size.x;
            int sizeY = size.y;

            var pivot = _items[item];
            int pivotX = pivot.x;
            int pivotY = pivot.y;

            var positions = new Vector2Int[sizeX * sizeY];
            int count = 0;

            for (int x = pivotX; x < pivotX + sizeX; x++)
            {
                for (int y = pivotY; y < pivotY + sizeY; y++)
                {
                    positions[count] = new Vector2Int(x, y);
                    count++;
                }
            }

            return positions;
        }

        public bool TryGetPositions(Item item, out Vector2Int[] positions)
        {
            if (!IsValidItem(item))
            {
                positions = null;
                return false;
            }

            positions = GetPositions(item);
            return true;
        }

        /// <summary>
        /// Clears all items 
        /// </summary>
        public void Clear()
        {
            if (_items.Count == 0)
            {
                return;
            }

            _items.Clear();            
            FillMatrixSpace(0, 0, _width, _height, null);

            OnCleared?.Invoke();
        }

        /// <summary>
        /// Returns count of items with a specified name
        /// </summary>
        public int GetItemCount(string name)
        {
            int count = 0;

            foreach (var item in _items)
            {
                if (item.Key.Name == name)
                {
                    count++;
                }
            }

            return count;
        }

        public bool MoveItem(Item item, Vector2Int position)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            if (!_items.ContainsKey(item)
                || !ContainsPosition(position.x, position.y)
                || !FindFreePosition(item, out Vector2Int _)
            )
            {
                return false;
            }

            RemoveItemSilently(item);
            AddItemSilently(item);
            OnMoved?.Invoke(item, position);
            return true;
        }

        /// <summary>
        /// Rearranges an inventory space with max free slots 
        /// </summary>
        public void OptimizeSpace()
        {
            var items = new Item[_items.Keys.Count];
            _items.Keys.CopyTo(items, 0);
            Clear();
            
            var sortedItems = Sort(items);

            foreach (var item in sortedItems)
            {
                AddItemSilently(item);
            }
        }

        private List<Item> Sort(Item[] items)
        {
            var sortedItems = new List<Item>(items);
            int count = sortedItems.Count;

            for (int i = 1; i < count; i++)
            {
                Item item = sortedItems[i];
                int space = item.Size.x * item.Size.y;
                int j = i - 1;

                while (j >= 0 && (sortedItems[j].Size.x * sortedItems[j].Size.y) < space)
                {
                    sortedItems[j + 1] = sortedItems[j];
                    j--;
                }

                sortedItems[j + 1] = item;
            }

            return sortedItems;
        }

        /// <summary>
        /// Iterates by all items 
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return _items.Keys.GetEnumerator();
        }

        /// <summary>
        /// Copies items to a specified matrix
        /// </summary>
        public void CopyTo(Item[,] matrix)
        {
            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    matrix[x, y] = _matrix[x, y];
                }
            }
        }

        /// <summary>
        /// Returns an inventory matrix in string format
        /// </summary>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            for (int x = 0; x < _width; x++)
            {
                builder.Append("{ ");

                for (int y = 0; y < _height; y++)
                {
                    var item = _matrix[x, y];
                    string name;

                    if (item == null)
                    {
                        name = "null";
                    }
                    else
                    {
                        name = item.Name;
                    }

                    if (y != _height - 1)
                    {
                        builder.Append($"{name}, ");
                    }
                    else
                    {
                        builder.Append($"{name}");
                    }
                }

                builder.Append(" }\n");
            }

            return builder.ToString();
        }
    }
}