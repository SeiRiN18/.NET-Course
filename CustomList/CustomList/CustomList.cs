using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _size;

        public int Count => _size;
        public int Capacity => _items.Length;

        public CustomList() {
            _items = new T[0];
            _size = 0;
        }

        public CustomList(T[] items)
        {
            _items = items;
            _size = items.Length;
        }

        public CustomList(int capacity)
        {
            if (capacity < 0)
            {
                capacity = 0;
            }
            _items = new T[capacity];
            _size = 0;
        }
        
        private void Resize()
        {
            int newCapacity = _items.Length == 0 ? 1 : _items.Length * 2;
            T[] newItems = new T[newCapacity];

            if (_size > 0)
            {
                Array.Copy(_items, newItems, _size);
            }

            _items = newItems;
            
        }
        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                    throw new ArgumentOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _size)
                    throw new ArgumentOutOfRangeException();
                _items[index] = value;
            }
           

        }
        public void Add(T item)
        {

            if (_size == _items.Length)
            {
                Resize();
            }
            _items[_size++] = item;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _size)
            {
                throw new ArgumentOutOfRangeException();
            }
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
