using System;
using System.Collections.Generic;
using FreeContent;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreeContentTests
{
    [TestClass]
    public class ICatalogTests
    {
        private int CountContentFound(IEnumerable<IContent> contentFound)
        {
            int count = 0;
            foreach (var content in contentFound)
            {
                count++;
            }

            return count;
        }

        [TestMethod]
        public void Add_SingleBook()
        {
            ICatalog catalog = new Catalog();
            catalog.Add(new Content(ContentType.Book, new string[] 
            {
                "TestTitle", "TestAuthor", "432943", "http://www.testingcatalog.com/"
            }));

            IEnumerable<IContent> foundContent = catalog.GetListContent("TestTitle", 10);
            int numberOfItemsFound = this.CountContentFound(foundContent);

            Assert.AreEqual(1, numberOfItemsFound);
        }

        [TestMethod]
        public void Add_DuplicateBooks()
        {
            ICatalog catalog = new Catalog();
            for (int i = 0; i < 10; ++i)
            {
                catalog.Add(new Content(ContentType.Book, new string[] 
                {
                    "TestTitle", "TestAuthor", "432943", "http://www.testingcatalog.com/"
                }));
            }

            IEnumerable<IContent> foundContent = catalog.GetListContent("TestTitle", 100);
            int numberOfItemsFound = this.CountContentFound(foundContent);

            Assert.AreEqual(10, numberOfItemsFound);
        }

        [TestMethod]
        public void Add_DuplicateAndNonDuplicateItems()
        {
            ICatalog catalog = new Catalog();
            for (int i = 0; i < 10; ++i)
            {
                catalog.Add(new Content(ContentType.Book, new string[] 
                {
                    "TestTitle", "TestAuthor", "432943", @"http://www.testingcatalog.com/"
                }));
            }

            catalog.Add(new Content(ContentType.Application, new string[]
            {
                "TestTitle", "TestAppAuthor", "111", @"http://www.testingappcatalog.com/"
            }));

            catalog.Add(new Content(ContentType.Movie, new string[]
            {
                "TestTitle", "TestMoveAuthor", "22", @"http://www.testingmoviecatalog.com/"
            }));

            catalog.Add(new Content(ContentType.Music, new string[]
            {
                "TestTitle", "TestMusicAuthor", "3333", @"http://www.testingmusiccatalog.com/"
            }));

            IEnumerable<IContent> foundContent = catalog.GetListContent("TestTitle", 100);
            int numberOfItemsFound = this.CountContentFound(foundContent);

            Assert.AreEqual(13, numberOfItemsFound);
        }

        [TestMethod]
        public void GetListContent_WithoutMatchingElement()
        {
            ICatalog catalog = new Catalog();
            catalog.Add(new Content(ContentType.Music, new string[]
            {
                "TestTitle", "TestMusicAuthor", "3333", @"http://www.testingmusiccatalog.com/"
            }));

            IEnumerable<IContent> foundContent = catalog.GetListContent("TestTitle1", 100);
            int numberOfItemsFound = this.CountContentFound(foundContent);

            Assert.AreEqual(0, numberOfItemsFound);
        }

        [TestMethod]
        public void GetListContent_WithMathingElementsMoreThanTheRequestedCount()
        {

            ICatalog catalog = new Catalog();
            for (int i = 0; i < 10; ++i)
            {
                catalog.Add(new Content(ContentType.Book, new string[] 
                {
                    "TestTitle", "TestAuthor", "432943", "http://www.testingcatalog.com/"
                }));
            }

            IEnumerable<IContent> foundContent = catalog.GetListContent("TestTitle", 3);
            int numberOfItemsFound = this.CountContentFound(foundContent);

            Assert.AreEqual(3, numberOfItemsFound);
        }

        [TestMethod]
        public void GetListContent_CheckSorting()
        {
            ICatalog catalog = new Catalog();
            for (int i = 9; i >= 0; --i)
            {
                catalog.Add(new Content(ContentType.Book, new string[] 
                {
                    "TestTitle", "TestAuthor" + i, "432943" + i, "http://www.testingcatalog.com/"
                }));
            }

            IEnumerable<IContent> foundContent = catalog.GetListContent("TestTitle", 100);

            bool contentIsSorted = true;
            int currentIndex = 0;
            foreach (var item in foundContent)
            {
                if (!item.Author.EndsWith(currentIndex.ToString()))
                {
                    contentIsSorted = false;
                    break;
                }
                currentIndex++;
            }

            Assert.IsTrue(contentIsSorted);
        }

        [TestMethod]
        public void UpdateContent_WithNoMatchingElemet()
        {
            ICatalog catalog = new Catalog();
            catalog.Add(new Content(ContentType.Music, new string[]
            {
                "TestTitle", "TestMusicAuthor", "3333", @"http://www.test1.com/"
            }));

            int itemsUpdated = catalog.UpdateContent("http://www.test.com/", "http://www.modified.com/");

            Assert.AreEqual(0, itemsUpdated);
        }

        [TestMethod]
        public void UpdateContent_WithSingleMatchingElement_ShouldReturn1()
        {
            string oldUrl = "http://www.test0.com/";
            string newUrl = "http://www.modified.com/";
            ICatalog catalog = new Catalog();
            for (int i = 0; i < 10; ++i)
            {
                catalog.Add(new Content(ContentType.Music, new string[]
                {
                    "TestTitle", "TestMusicAuthor", "3333", @"http://www.test" + i + ".com/"
                }));
            }

            int itemsUpdated = catalog.UpdateContent(oldUrl, newUrl);

            Assert.AreEqual(1, itemsUpdated);
        }

        [TestMethod]
        public void UpdateContent_WithMultipleItemsmatch_TestIfUrlsAreUpdated()
        {
            string oldUrl = "http://www.test0.com/";
            string newUrl = "http://www.modified.com/";
            ICatalog catalog = new Catalog();
            for (int i = 0; i < 10; ++i)
            {
                catalog.Add(new Content(ContentType.Music, new string[]
                {
                    "TestTitle", "TestMusicAuthor", "3333", @"http://www.test" + (i % 2) + ".com/"
                }));
            }

            int itemsUpdated = catalog.UpdateContent(oldUrl, newUrl);
            IEnumerable<IContent> updated = catalog.GetListContent("TestTitle", 1000);

            bool allAreUpdated = true;
            foreach (var item in updated)
            {
                if (item.Url == oldUrl)
                {
                    allAreUpdated = false;
                    break;
                }
            }

            Assert.IsTrue(allAreUpdated);
        }

        [TestMethod]
        public void UpdateContent_WithAllElementsMatching()
        {
            string oldUrl = "http://www.test.com/";
            string newUrl = "http://www.modified.com/";

            ICatalog catalog = new Catalog();
            for (int i = 0; i < 10; ++i)
            {
                catalog.Add(new Content(ContentType.Music, new string[]
                {
                    "TestTitle", "TestMusicAuthor", "3333", oldUrl
                }));
            }

            int itemsUpdated = catalog.UpdateContent(oldUrl, newUrl);

            Assert.AreEqual(10, itemsUpdated);
        }
    }
}
