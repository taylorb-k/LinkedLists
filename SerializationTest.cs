using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProblemDomain;
using Utility;

namespace UnitTest
{
    [TestClass]
    public class SerializationTests
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

            // Add users to the list
            sll.AddLast(user1);
            sll.AddLast(user2);
            sll.AddLast(user3);
        }

        [TestMethod]
        public void TestSerialization()
        {
            // Serialize the linked list
            MemoryStream ms = new MemoryStream();
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, sll);

            // Reset the stream position
            ms.Position = 0;

            // Deserialize the linked list
            SLL<User> deserializedList = (SLL<User>)formatter.Deserialize(ms);
#pragma warning restore SYSLIB0011 // Type or member is obsolete

            // Verify the deserialized list contents
            Assert.AreEqual(sll.Count(), deserializedList.Count());

            for (int i = 0; i < sll.Count(); i++)
            {
                User originalUser = sll.GetValue(i);
                User deserializedUser = deserializedList.GetValue(i);

                Assert.AreEqual(originalUser.FirstName, deserializedUser.FirstName);
                Assert.AreEqual(originalUser.LastName, deserializedUser.LastName);
                Assert.AreEqual(originalUser.EmailAddress, deserializedUser.EmailAddress);
            }

            // Close the stream
            ms.Close();
        }
    }
}