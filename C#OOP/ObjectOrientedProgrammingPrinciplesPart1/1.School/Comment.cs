using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public abstract class CommentCollection
    {
        private List<string> comments;

        protected CommentCollection()
        {
            comments = new List<string>();
        }

        public int CommentsCount
        {
            get
            {
                return this.comments.Count();
            }
        }

        public List<string> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public void AddComment(string comment)
        {
            if (!this.comments.Contains(comment))
            {
                this.comments.Add(comment);
            }
        }

        public void RemoveComment(string comment)
        {
            this.comments.Remove(comment);
        }

        public void RemoveCommentAt(int index)
        {
            if (index < 0 || index >= this.comments.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                this.comments.RemoveAt(index);
            }
        }

        public void ClearComments()
        {
            this.comments.Clear();
        }

        public void DisplayComments()
        {
            foreach (string comment in comments)
            {
                Console.WriteLine(comment);
            }
        }
    }
}
