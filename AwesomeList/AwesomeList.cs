using System;
using System.Collections;
using System.Collections.Generic;

namespace AwesomeListNamespace
{
    public class AwesomeList<T> : IEnumerable, IEnumerator, IEnumerable<T>, IEnumerator<T> where T : IComparable
    {
        private T[] array = new T[0];
        private int position = -1;

        public int Lenght { get { return array.Length; } }

        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public void Add(T newObj)
        {
            T[] newArray = new T[Lenght + 1];
            for(int i = 0; i < Lenght; i++)
            {
                newArray[i] = array[i];
            }
            newArray[Lenght] = newObj;
            array = newArray;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 && index > Lenght) return;

            try
            {
                T[] newArray = new T[Lenght - 1];
                for (int i = 0; i < index; i++)
                {
                    newArray[i] = array[i];
                }
                for (int i = index + 1; i < Lenght; i++)
                {
                    newArray[i - 1] = array[i];
                }
                array = newArray;
            }
            catch (IndexOutOfRangeException){ }
        }

        public void Sort()
        {
            T temp;

            for (int write = 0; write < array.Length; write++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    int res = array[sort].CompareTo(array[sort + 1]);
                    if (res > 0)
                    {
                        temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }
        }

        public void Reverse()
        {
            T[] newArray = new T[Lenght];
            for (int i = 0, j = Lenght - 1; i < Lenght; i++, j--)
            {
                newArray[i] = array[j];
            }
            array = newArray;
        }

        public List<T> ToList()
        {
            List<T> list = new List<T>();
            foreach(var item in array)
            {
                list.Add(item);
            }
            return list;
        }

        public void CopyTo(AwesomeList<T> target)
        {
            foreach (var item in array)
            {
                target.Add(item);
            }
        }

        public void Clear()
        {
            array = new T[0];
        }

        public void Insert(T item, int index)
        {
            if (index < 0 && index > Lenght) return;

            try
            {
                T[] newArray = new T[Lenght + 1];
                for (int i = 0; i < index; i++)
                {
                    newArray[i] = array[i];
                }
                newArray[index] = item;
                for (int i = index + 1; i < Lenght + 1; i++)
                {
                    newArray[i] = array[i - 1];
                }
                array = newArray;
            }
            catch (IndexOutOfRangeException) { }
        }

        public void AddRange(T[] source)
        {
            foreach(var item in source)
            {
                Add(item);
            }
        }

        public IEnumerator GetEnumerator()
        {
            return this as IEnumerator;
        }

        public bool MoveNext()
        {
            if (position < Lenght - 1)
            {
                position++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return array[position]; }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this as IEnumerator<T>;
        }

        T IEnumerator<T>.Current
        {
            get { return array[position]; }
        }

        public void Dispose() { }
    }
}