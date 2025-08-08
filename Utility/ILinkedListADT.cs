using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public interface ILinkedListADT<T>
    {
        void Add(int index, T item);

        void AddFirst(T item);

        void AddLast(T item);

        void Replace(int index, T item);

        int Count();

        T GetValue(int index);

        int IndexOf(T item);

        bool Contains(T item);

        bool IsEmpty();

        void Clear();

        T Remove(int index);

        T RemoveFirst();

        T RemoveLast();

        T[] ToArray();
    }
}
