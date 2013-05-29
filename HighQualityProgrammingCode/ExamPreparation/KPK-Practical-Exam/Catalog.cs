namespace FreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Catalog : ICatalog
    {
        private MultiDictionary<string, IContent> url;
        private OrderedMultiDictionary<string, IContent> title;

        public Catalog()
        {
            bool allowDuplicateValues = true;
            this.title = new OrderedMultiDictionary<string, IContent>(allowDuplicateValues);
            this.url = new MultiDictionary<string, IContent>(allowDuplicateValues);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.Url, content);
        }

        
        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            int itemsToSelect = Math.Min(numberOfContentElementsToList, this.title[title].Count);
            int itemsSelected = 0;
            List<IContent> result = new List<IContent>();
            foreach (var item in this.title[title])
            {
                if (itemsSelected >= itemsToSelect)
                {
                    break;
                }
                result.Add(item);
                itemsSelected++;
            }
            return result;
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            int theElements = 0;

            List<IContent> contentToList = this.url[oldUrl].ToList();
            theElements = contentToList.Count();


            foreach (Content content in contentToList)
            {
                content.Url = newUrl;
            }

            return theElements;
        }
    }
}
