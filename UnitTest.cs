using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemDomain;
using Utility;

namespace UnitTest
{
    [TestClass]
    public class LinkedListTest
    {
        private SLL<User> sll;
        private User user1, user2, user3;

        [TestInitialize]
        public void TestInitialize()
        {
            // Create a new linked list for each test
            sll = new SLL<User>();

            // Create some test users
            user1 = new User("Alice", "Johnson", "alice@example.com");
            user2 = new User("Bob", "Smith", "bob@example.com");
            user3 = new User("Charlie", "Brown", "charlie@example.com");
        }

        [TestMethod]
        public void TestEmptyList()
        {
            // Verify that a new list is empty
            Assert.IsTrue(sll.IsEmpty());
            Assert.AreEqual(0, sll.Count());
        }

        [TestMethod]
        public void TestPrepend()
        {
            // Add an item to the beginning of the list
            sll.AddFirst(user1);

            // Verify the item was added
            Assert.AreEqual(1, sll.Count());
            Assert.IsFalse(sll.IsEmpty());
            Assert.AreEqual(user1, sll.GetValue(0));

            // Add another item to the beginning
            sll.AddFirst(user2);

            // Verify the new item is at the beginning
            Assert.AreEqual(2, sll.Count());
            Assert.AreEqual(user2, sll.GetValue(0));
            Assert.AreEqual(user1, sll.GetValue(1));
        }

        [TestMethod]
        public void TestAppend()
        {
            // Add an item to the end of the list
            sll.AddLast(user1);

            // Verify the item was added
            Assert.AreEqual(1, sll.Count());
            Assert.IsFalse(sll.IsEmpty());
            Assert.AreEqual(user1, sll.GetValue(0));

            // Add another item to the end
            sll.AddLast(user2);

            // Verify the new item is at the end
            Assert.AreEqual(2, sll.Count());
            Assert.AreEqual(user1, sll.GetValue(0));
            Assert.AreEqual(user2, sll.GetValue(1));
        }

        [TestMethod]
        public void TestInsertAtIndex()
        {
            // Add some items to the list
            sll.AddLast(user1);
            sll.AddLast(user3);

            // Insert an item at index 1
            sll.Add(1, user2);

            // Verify the item was inserted
            Assert.AreEqual(3, sll.Count());
            Assert.AreEqual(user1, sll.GetValue(0));
            Assert.AreEqual(user2, sll.GetValue(1));
            Assert.AreEqual(user3, sll.GetValue(2));
        }

        [TestMethod]
        public void TestReplace()
        {
            // Add some items to the list
            sll.AddLast(user1);
            sll.AddLast(user2);

            // Replace an item
            sll.Replace(1, user3);

            // Verify the item was replaced
            Assert.AreEqual(2, sll.Count());
            Assert.AreEqual(user1, sll.GetValue(0));
            Assert.AreEqual(user3, sll.GetValue(1));
        }

        [TestMethod]
        public void TestRemoveFirst()
        {
            // Add some items to the list
            sll.AddLast(user1);
            sll.AddLast(user2);
            sll.AddLast(user3);

            // Remove the first item
            User removed = sll.RemoveFirst();

            // Verify the item was removed
            Assert.AreEqual(user1, removed);
            Assert.AreEqual(2, sll.Count());
            Assert.AreEqual(user2, sll.GetValue(0));
            Assert.AreEqual(user3, sll.GetValue(1));
        }

        [TestMethod]
        public void TestRemoveLast()
        {
            // Add some items to the list
            sll.AddLast(user1);
            sll.AddLast(user2);
            sll.AddLast(user3);

            // Remove the last item
            User removed = sll.RemoveLast();

            // Verify the item was removed
            Assert.AreEqual(user3, removed);
            Assert.AreEqual(2, sll.Count());
            Assert.AreEqual(user1, sll.GetValue(0));
            Assert.AreEqual(user2, sll.GetValue(1));
        }

        [TestMethod]
        public void TestRemoveMiddle()
        {
            // Add some items to the list
            sll.AddLast(user1);
            sll.AddLast(user2);
            sll.AddLast(user3);

            // Remove the middle item
            User removed = sll.Remove(1);

            // Verify the item was removed
            Assert.AreEqual(user2, removed);
            Assert.AreEqual(2, sll.Count());
            Assert.AreEqual(user1, sll.GetValue(0));
            Assert.AreEqual(user3, sll.GetValue(1));
        }

        [TestMethod]
        public void TestIndexOfAndContains()
        {
            // Add some items to the list
            sll.AddLast(user1);
            sll.AddLast(user2);
            sll.AddLast(user3);

            // Find existing items
            Assert.AreEqual(0, sll.IndexOf(user1));
            Assert.AreEqual(1, sll.IndexOf(user2));
            Assert.AreEqual(2, sll.IndexOf(user3));
            Assert.IsTrue(sll.Contains(user1));
            Assert.IsTrue(sll.Contains(user2));
            Assert.IsTrue(sll.Contains(user3));

            // Try to find a non-existent item
            User user4 = new User("David", "Jones", "david@example.com");
            Assert.AreEqual(-1, sll.IndexOf(user4));
            Assert.IsFalse(sll.Contains(user4));
        }

        [TestMethod]
        public void TestClear()
        {
            // Add some items to the list
            sll.AddLast(user1);
            sll.AddLast(user2);
            sll.AddLast(user3);

            // Clear the list
            sll.Clear();

            // Verify the list is empty
            Assert.IsTrue(sll.IsEmpty());
            Assert.AreEqual(0, sll.Count());
        }

        [TestMethod]
        public void TestToArray()
        {
            // Add some items to the list
            sll.AddLast(user1);
            sll.AddLast(user2);
            sll.AddLast(user3);

            // Convert to array
            User[] array = sll.ToArray();

            // Verify the array contents
            Assert.AreEqual(3, array.Length);
            Assert.AreEqual(user1, array[0]);
            Assert.AreEqual(user2, array[1]);
            Assert.AreEqual(user3, array[2]);
        }
    }
}