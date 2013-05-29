namespace FreeContent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    /// <summary>
    /// Represents the inrface for a catalog of items.
    /// </summary>
    public interface ICatalog
    {
        /// <summary>
        /// Adds content to the catalog.
        /// </summary>
        /// <param name="content">Content which will be added.</param>
        void Add(IContent content);

        /// <summary>
        /// Returns a collection of content. The content is filtered based on the
        /// title. If the numberOfContentElementsToList is bigger than the filtered content
        /// which is found, the method returns all the found content.
        /// </summary>
        /// <param name="title">The title which will filter the content.</param>
        /// <param name="numberOfContentElementsToList">The number of items to return.</param>
        /// <returns>Collection of filtered contend based on the chosen title.</returns>
        IEnumerable<IContent> GetListContent(string title, Int32 numberOfContentElementsToList);

        /// <summary>
        /// Updates all the content, which has Url <paramref name="oldUrl"/>
        /// to have a Url equal to <paramref name="newUrl"/>
        /// </summary>
        /// <param name="oldUrl">The Url of the content to be updated.</param>
        /// <param name="newUrl">The new Url to be set on the content.</param>
        /// <returns>The number of updated items.</returns>
        Int32 UpdateContent(string oldUrl, string newUrl);
    }
}
