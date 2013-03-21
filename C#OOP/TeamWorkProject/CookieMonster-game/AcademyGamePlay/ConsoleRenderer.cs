using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyGamePlay
{
    /// <summary>
    /// Renders the game objects on the console.
    /// </summary>
    public class ConsoleRenderer : IRenderer
    {
        private Queue<IRenderable> renderingQueue;
        private List<IRenderable> currentlyRenderedObjects;
        private List<int> indexesFound;

        /// <summary>
        /// Creates a console renderer with the largest possible screenHeight and screenHeight.
        /// </summary>
        public ConsoleRenderer()
            : this(Console.LargestWindowHeight, Console.LargestWindowWidth)
        {
        }

        /// <summary>
        /// Creates a console renderer with the specified with and screenHeight.
        /// </summary>
        /// <param name="consoleWidth">The screenHeight of the console.</param>
        /// <param name="consoleHeight">The screenHeight of the console.</param>
        public ConsoleRenderer(int consoleHeight, int consoleWidth)
        {
            this.renderingQueue = new Queue<IRenderable>();
            this.currentlyRenderedObjects = new List<IRenderable>();
            this.indexesFound = new List<int>();

            Console.CursorVisible = false;

            Console.BufferWidth = Console.WindowWidth = consoleWidth;
            Console.BufferHeight = Console.WindowHeight = consoleHeight;
        }

        /// <summary>
        /// Gets the size of the rendering queue.
        /// </summary>
        public int QueueSize
        {
            get
            {
                return this.renderingQueue.Count;
            }
        }

        public void EnqueueForRendering(IRenderable obj)
        {
            int foundIndex = this.currentlyRenderedObjects.FindIndex(x => x.Equals(obj));
            if (foundIndex > -1)
            {
                this.indexesFound.Add(foundIndex);
            }
            else
            {
                this.renderingQueue.Enqueue(obj);
            }
        }

        public void RenderAllObjects()
        {
            IRenderable tmpObject;
            GridPosition objectPosition;
            ObjectColor objectColor;

            if (this.indexesFound.Count != this.currentlyRenderedObjects.Count)
            {
                for (int i = 0; i < this.currentlyRenderedObjects.Count; ++i)
                {
                    if (!this.indexesFound.Contains(i))
                    {
                        tmpObject = this.currentlyRenderedObjects[i];
                        objectPosition = tmpObject.GetObjectPosition();
                        objectColor = tmpObject.GetObjectColor();

                        Console.SetCursorPosition(objectPosition.Y, objectPosition.X);
                        Console.Write(" ");
                    }
                }
            }

            List<IRenderable> tmpList = new List<IRenderable>();

            foreach (var index in this.indexesFound)
            {
                tmpList.Add(this.currentlyRenderedObjects[index]);
            }

            this.currentlyRenderedObjects = tmpList;
            this.indexesFound.Clear();

            while (this.renderingQueue.Count > 0)
            {
                tmpObject = this.renderingQueue.Dequeue();
                this.currentlyRenderedObjects.Add(new StaticObject(tmpObject.GetObjectPosition(), tmpObject.GetObjectImage(), tmpObject.GetObjectColor()));

                objectPosition = tmpObject.GetObjectPosition();
                objectColor = tmpObject.GetObjectColor();

                //Translates the ObjectColor to a ConsoleColor.
                switch (objectColor)
                {
                    case ObjectColor.Black: Console.ForegroundColor = ConsoleColor.Black; break;
                    case ObjectColor.Blue: Console.ForegroundColor = ConsoleColor.Blue; break;
                    case ObjectColor.Cyan: Console.ForegroundColor = ConsoleColor.Cyan; break;
                    case ObjectColor.DarkBlue: Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                    case ObjectColor.DarkCyan: Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                    case ObjectColor.DarkGray: Console.ForegroundColor = ConsoleColor.DarkGray; break;
                    case ObjectColor.DarkMagenta: Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                    case ObjectColor.DarkRed: Console.ForegroundColor = ConsoleColor.DarkRed; break;
                    case ObjectColor.DarkYellow: Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                    case ObjectColor.Gray: Console.ForegroundColor = ConsoleColor.Gray; break;
                    case ObjectColor.Green: Console.ForegroundColor = ConsoleColor.Green; break;
                    case ObjectColor.Magenta: Console.ForegroundColor = ConsoleColor.Magenta; break;
                    case ObjectColor.Red: Console.ForegroundColor = ConsoleColor.Red; break;
                    case ObjectColor.White: Console.ForegroundColor = ConsoleColor.White; break;
                    case ObjectColor.Yellow: Console.ForegroundColor = ConsoleColor.Yellow; break;
                    default: Console.ForegroundColor = ConsoleColor.White; break;
                }

                Console.SetCursorPosition(objectPosition.Y, objectPosition.X);
                Console.Write(tmpObject.GetObjectImage());
            }
        }

        public void ClearQueue()
        {
            this.renderingQueue.Clear();
        }
    }
}
