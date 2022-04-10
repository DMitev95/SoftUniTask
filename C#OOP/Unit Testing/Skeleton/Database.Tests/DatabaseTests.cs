namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        [TestCase(new [] {5})]
        [TestCase(new[] { 5,6,9,12,13,154 })]
        [TestCase(new[] { int.MinValue, int.MaxValue, 9 })]
        public void ConstructorShoudPass(int[] parameters)
        {
            Database db = new Database(parameters);
            Assert.AreEqual(parameters.Length,db.Count);
        }


        [TestCase(new int[] { 5,20 },new int[] {15,12},4)]
        [TestCase(new int[0], new int[] { int.MinValue, int.MaxValue,23523}, 3)]
        [TestCase(new int[0], new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16}, 16)]
        public void AddValidData(int[] constructorParams,int[] paramsAdd,int count)
        {
            Database database = new Database(constructorParams);
            for (int i = 0; i < paramsAdd.Length; i++)
            {
                database.Add(paramsAdd[i]);
            }
            Assert.AreEqual(count,database.Count);
        }


        [TestCase(new int[] { 5, 20 }, new int[] { 1,2,3,4,5,6,7,8,9,10,11,12,13,14}, 1)]        
        public void AddInvalidData(int[] constructorParams, int[] paramsAdd, int count)
        {
            Database database = new Database(constructorParams);
            for (int i = 0; i < paramsAdd.Length; i++)
            {
                database.Add(paramsAdd[i]);
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(count));
        }
        [TestCase(new int[] { 5, 20,30 }, new int[] {20,11,23,42,54 }, 3,5)]
        public void RemoveValidData(int[] constructorParams, int[] paramsAdd, int count,int left)
        {
            Database database = new Database(constructorParams);
            foreach (var i in paramsAdd)
            {
                database.Add(i);
            }
            for (int i = 0; i < count; i++)
            {
                database.Remove();
            }
            Assert.AreEqual(left,database.Count);
        }
        [TestCase(new int[] { 1 }, 1 )]
        public void RemoveInvalidData(int[] constructorParams , int count)
        {
            Database database = new Database(constructorParams);

            for (int i = 0; i < count; i++)
            {
                database.Remove();
            }
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [TestCase(new int[] { 1,2,3 },new int[] {5,6,7}, 2,new int[] {1,2,3,5})]
        public void FetchValidData(int[] constructorParams, int[] paramsAdd, int count, int[] newArray)
        {
            Database database = new Database(constructorParams);
            foreach (var i in paramsAdd)
            {
                database.Add(i);
            }
            for (int i = 0; i < count; i++)
            {
                database.Remove();
            }
            int[] array = database.Fetch();
            Assert.AreEqual(newArray,array);
        }
    }
}
