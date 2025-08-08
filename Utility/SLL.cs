using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Utility
{
    [Serializable]
    public class SLL<T> : ILinkedListADT<T>
    {
        // Properties
        private Node<T> head;
        private int count;

        // Constructor
        public SLL()
        {
            head = null;
            count = 0;
        }

        // Add item at a specific index
        public void Add(int index, T item)
        {
            // Check if index is valid
            if (index < 0 || index > count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            // If adding at the beginning
            if (index == 0)
            {
                AddFirst(item);
                return;
            }

            // If adding at the end
            if (index == count)
            {
                AddLast(item);
                return;
            }

            // Adding somewhere in the middle
            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            Node<T> newNode = new Node<T>(item);
            newNode.Next = current.Next;
            current.Next = newNode;
            count++;
        }

        // Add item to the beginning of the list
        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);
            newNode.Next = head;
            head = newNode;
            count++;
        }

        // Add item to the end of the list
        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            // If list is empty
            if (head == null)
            {
                head = newNode;
                count++;
                return;
            }

            // Find the last node
            Node<T> current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
            count++;
        }

        // Replace an item at a specific index
        public void Replace(int index, T item)
        {
            // Check if index is valid
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Data = item;
        }

        // Get the count of items in the list
        public int Count()
        {
            return count;
        }

        // Get the value at a specific index
        public T GetValue(int index)
        {
            // Check if index is valid
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node<T> current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Data;
        }

        // Get the index of a specific item
        public int IndexOf(T item)
        {
            Node<T> current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1; // Item not found
        }

        // Check if the list contains a specific item
        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        // Check if the list is empty
        public bool IsEmpty()
        {
            return count == 0;
        }

        // Clear all items from the list
        public void Clear()
        {
            head = null;
            count = 0;
        }

        // Remove an item at a specific index
        public T Remove(int index)
        {
            // Check if index is valid
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            // If removing the first item
            if (index == 0)
            {
                return RemoveFirst();
            }

            // If removing the last item
            if (index == count - 1)
            {
                return RemoveLast();
            }

            // Removing from somewhere in the middle
            Node<T> current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            T removedData = current.Next.Data;
            current.Next = current.Next.Next;
            count--;

            return removedData;
        }

        // Remove the first item in the list
        public T RemoveFirst()
        {
            // Check if the list is empty
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from an empty list.");
            }

            T removedData = head.Data;
            head = head.Next;
            count--;

            return removedData;
        }

        // Remove the last item in the list
        public T RemoveLast()
        {
            // Check if the list is empty
            if (IsEmpty())
            {
                throw new InvalidOperationException("Cannot remove from an empty list.");
            }

            // If only one item in the list
            if (count == 1)
            {
                return RemoveFirst();
            }

            // Find the second-to-last node
            Node<T> current = head;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }

            T removedData = current.Next.Data;
            current.Next = null;
            count--;

            return removedData;
        }

        // Additional functionality: Copy list to array
        public T[] ToArray()
        {
            T[] array = new T[count];
            Node<T> current = head;

            for (int i = 0; i < count; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }

            return array;
        }
    }
}

