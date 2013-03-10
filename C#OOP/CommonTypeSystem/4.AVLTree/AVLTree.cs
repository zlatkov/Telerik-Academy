using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.AVLTree
{
    public class AVLTree<TKey, TValue> : IEnumerable<AVLNode<TKey, TValue>> where TKey : IComparable<TKey>
    {
        private AVLNode<TKey, TValue> root;

        public AVLTree()
        {
            this.root = null;
        }

        /// <summary>
        /// Tree indexer.
        /// </summary>
        public TValue this[TKey key]
        {
            set
            {
                this.Insert(key, value);
            }
            get
            {
                TValue result;
                //If the key is not found, we cannot modify it's value.
                if (!this.TryGetValue(key, out result))
                {
                    throw new KeyNotFoundException();
                }
                return result;   
            }
        }

        ///<summary>
        ///If there is a node with the given key, we set the result parameter with its value and return true,
        ///otherwise return false, and set the result parameter to its default value.
        ///</summary>
        public bool TryGetValue(TKey key, out TValue result)
        {
            AVLNode<TKey, TValue> current = root;
            while (current != null)
            {
                if (current.Key.CompareTo(key) == -1)
                {
                    current = current.RightChild;
                }
                else if (current.Key.CompareTo(key) == 1)
                {
                    current = current.LeftChild;
                }
                else
                {
                    result = current.Value;
                    return true;
                }
            }
            result = default(TValue);
            return false;
        }

        /// <summary>
        /// Checks if a node with the given key exists in the tree.
        /// </summary>
        public bool ContainsKey(TKey key)
        {
            TValue tmp;
            return this.TryGetValue(key, out tmp);
        }

        /// <summary>
        /// Inserts the Key-Value pair node in the tree.
        /// </summary>
        public void Insert(TKey key, TValue value)
        {
            //If the tree is empty, set the root to be the new node.
            if (this.root == null)
            {
                this.root = new AVLNode<TKey, TValue>(key, value);
            }
            else
            {
                AVLNode<TKey, TValue> currentNode = root;
                while (currentNode != null)
                {
                    if (currentNode.Key.CompareTo(key) == -1)
                    {
                        if (currentNode.RightChild == null)
                        {
                            currentNode.RightChild = new AVLNode<TKey, TValue>(key, value, currentNode);
                            /*
                             * Since we insert the node in the right child of the current node, the height of the
                             * right subtree increases, so the difference 
                             * height(left-subtree) - height(right-subtree) decreases by 1.
                             */
                            
                            InsertBalanceTree(currentNode, -1);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.RightChild;
                        }
                    }
                    else if (currentNode.Key.CompareTo(key) == 1)
                    {
                        if (currentNode.LeftChild == null)
                        {
                            currentNode.LeftChild = new AVLNode<TKey, TValue>(key, value, currentNode);
                            /*
                             * Since we insert the node in the left child of the current node, the height of the
                             * left subtree increases, so the difference 
                             * height(left-subtree) - height(right-subtree) increases by 1.
                             */
                            InsertBalanceTree(currentNode, 1);
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.LeftChild;
                        }
                    }
                    else
                    {
                        currentNode.Value = value;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Clears the tree.
        /// </summary>
        public void Clear()
        {
            this.root = null;
        }

        /// <summary>
        /// Adjusts the balance factors for affected tree nodes.
        /// </summary>
        private void InsertBalanceTree(AVLNode<TKey, TValue> node, int addBalance)
        {
            while (node != null)
            {
                //Add the new balance value to the current node balance.
                node.Balance += addBalance; 

                /*
                 * If the balance was -1 or +1, the tree is still balanced so
                 * we don't have to balanced it further
                */
                if (node.Balance == 0)
                {
                    break;
                }
                //If the height(left-subtree) - height(right-subtree) == 2
                else if (node.Balance == 2)
                {
                    if (node.LeftChild.Balance == 1)
                    {
                        RotateLeftLeft(node);
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }
                    break;
                }

                //If the height(left-subtree) - height(right-subtree) == -2
                else if (node.Balance == -2)
                {
                    if (node.RightChild.Balance == -1)
                    {
                        RotateRightRight(node);
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }
                    break;
                }
  
                if (node.Parent != null)
                {
                    /*
                     * If the current node is the left child of the parent node
                     * we need to increase the height of the parent node. 
                     * */
                    if (node.Parent.LeftChild == node)
                    {
                        addBalance = 1;
                    }
                    /*
                     * If it is the right child, 
                     * we decrease the height of the parent node
                     * */
                    else
                    {
                        addBalance = -1;
                    }
                }
                node = node.Parent;
            }
        }

        /// <summary>
        /// Makes right-right rotation.
        /// </summary>
        private void RotateRightRight(AVLNode<TKey, TValue> node)
        {
            AVLNode<TKey, TValue> rightChild = node.RightChild;
            AVLNode<TKey, TValue> rightLeftChild = null;
            AVLNode<TKey, TValue> parent = node.Parent;

            if (rightChild != null)
            {
                rightLeftChild = rightChild.LeftChild;
                rightChild.Parent = parent;
                rightChild.LeftChild = node;
                rightChild.Balance++;
                node.Balance = -rightChild.Balance;
            }

            node.RightChild = rightLeftChild;
            node.Parent = rightChild;

            if (rightLeftChild != null)
            {
                rightLeftChild.Parent = node;
            }
            if (node == this.root)
            {
                this.root = rightChild;
            }
            else if (parent.RightChild == node)
            {
                parent.RightChild = rightChild;
            }
            else
            {
                parent.LeftChild = rightChild;
            }
        }


        /// <summary>
        /// Makes left-left rotation.
        /// </summary>
        private void RotateLeftLeft(AVLNode<TKey, TValue> node)
        {
            AVLNode<TKey, TValue> leftChild = node.LeftChild;
            AVLNode<TKey, TValue> leftRightChild = null;
            AVLNode<TKey, TValue> parent = node.Parent;

            if (leftChild != null)
            {
                leftRightChild = leftChild.RightChild;
                leftChild.Parent = parent;
                leftChild.RightChild = node;
                leftChild.Balance--;
                node.Balance = -leftChild.Balance;
            }

            node.Parent = leftChild;
            node.LeftChild = leftRightChild;

            if (leftRightChild != null)
            {
                leftRightChild.Parent = node;
            }

            if (node == this.root)
            {
                this.root = leftChild;
            }
            else if (parent.LeftChild == node)
            {
                parent.LeftChild = leftChild;
            }
            else
            {
                parent.RightChild = leftChild;
            }

        }


        /// <summary>
        /// Makes right-left rotation.
        /// </summary>
        private void RotateRightLeft(AVLNode<TKey, TValue> node)
        {
            AVLNode<TKey, TValue> rightChild = node.RightChild;
            AVLNode<TKey, TValue> rightLeftChild = null;
            AVLNode<TKey, TValue> rightLeftRightChild = null;

            if (rightChild != null)
            {
                rightLeftChild = rightChild.LeftChild;
            }
            if (rightLeftChild != null)
            {
                rightLeftRightChild = rightLeftChild.RightChild;
            }

            node.RightChild = rightLeftChild;

            if (rightLeftChild != null)
            {
                rightLeftChild.Parent = node;
                rightLeftChild.RightChild = rightChild;
                rightLeftChild.Balance--;
            }

            if (rightChild != null)
            {
                rightChild.Parent = rightLeftChild;
                rightChild.LeftChild = rightLeftRightChild;
                rightChild.Balance--;
            }

            if (rightLeftRightChild != null)
            {
                rightLeftRightChild.Parent = rightChild;
            }

            RotateRightRight(node);
        }


        /// <summary>
        /// Makes left-right rotation.
        /// </summary>
        private void RotateLeftRight(AVLNode<TKey, TValue> node)
        {
            AVLNode<TKey, TValue> leftChild = node.LeftChild;
            AVLNode<TKey, TValue> leftRightChild = leftChild.RightChild;
            AVLNode<TKey, TValue> leftRightLeftChild = null;
            if (leftRightChild != null)
            {
                leftRightLeftChild = leftRightChild.LeftChild;
            }

            node.LeftChild = leftRightChild;

            if (leftRightChild != null)
            {
                leftRightChild.Parent = node;
                leftRightChild.LeftChild = leftChild;
                leftRightChild.Balance++;
            }

            if (leftChild != null)
            {
                leftChild.Parent = leftRightChild;
                leftChild.RightChild = leftRightLeftChild;
                leftChild.Balance++;
            }

            if (leftRightLeftChild != null)
            {
                leftRightLeftChild.Parent = leftChild;
            }


            RotateLeftLeft(node);
        }

        /// <summary>
        /// Delets the node from the tree with the given key.
        /// </summary>
        public void Delete(TKey key)
        {
            AVLNode<TKey, TValue> current = this.root;
            while (current != null)
            {
                if (current.Key.CompareTo(key) == -1)
                {
                    current = current.RightChild;
                }
                else if (current.Key.CompareTo(key) == 1)
                {
                    current = current.LeftChild;
                }
                else //Found the key.
                {
                    if (current.LeftChild == null && current.RightChild == null)
                    {
                        if (current == root)
                        {
                            root = null;
                        }
                        else if (current.Parent.RightChild == current)
                        {
                            current.Parent.RightChild = null;
                            DeleteBalanceTree(current.Parent, 1);
                        }
                        else
                        {
                            current.Parent.LeftChild = null;
                            DeleteBalanceTree(current.Parent, -1);
                        }
                    }
                    else if (current.LeftChild != null) //Get the biggest node from the left subtree.
                    {
                        AVLNode<TKey, TValue> rightMost = current.LeftChild;
                        while (rightMost.RightChild != null)
                        {
                            rightMost = rightMost.RightChild;
                        }


                        ReplaceNodes(current, rightMost);
                        DeleteBalanceTree(rightMost.Parent, 1);
                    }
                    else //Get the smallest node from the right subtree.
                    {
                        AVLNode<TKey, TValue> leftMost = current.RightChild;
                        while (leftMost.LeftChild != null)
                        {
                            leftMost = leftMost.LeftChild;
                        }

                        ReplaceNodes(current, leftMost);
                        DeleteBalanceTree(leftMost.Parent, -1);
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Replaces two nodes and adjusts the children and parent connections.
        /// </summary>
        private void ReplaceNodes(AVLNode<TKey, TValue> sourceNode, AVLNode<TKey, TValue> subtreeNode)
        {
            sourceNode.Key = subtreeNode.Key;
            sourceNode.Value = subtreeNode.Value;

            if (subtreeNode.Parent != null)
            {
                if (subtreeNode.LeftChild != null)
                {
                    subtreeNode.LeftChild.Parent = subtreeNode.Parent;
                    if (subtreeNode.Parent.LeftChild == subtreeNode)
                    {
                        subtreeNode.Parent.LeftChild = subtreeNode.LeftChild;
                    }
                    else
                    {
                        subtreeNode.Parent.RightChild = subtreeNode.LeftChild;
                    }
                }
                else if (subtreeNode.RightChild != null)
                {
                    subtreeNode.RightChild.Parent = subtreeNode.Parent;
                    if (subtreeNode.Parent.LeftChild == subtreeNode)
                    {
                        subtreeNode.Parent.LeftChild = subtreeNode.RightChild;
                    }
                    else
                    {
                        subtreeNode.Parent.RightChild = subtreeNode.RightChild;
                    }
                }
                else
                {
                    if (subtreeNode.Parent.LeftChild == subtreeNode)
                    {
                        subtreeNode.Parent.LeftChild = null;
                    }
                    else
                    {
                        subtreeNode.Parent.RightChild = null;
                    }
                }
            }
        }

        /// <summary>
        /// Adjusts the balance factors of the tree nodes, after deleting a node.
        /// </summary>
        private void DeleteBalanceTree(AVLNode<TKey, TValue> node, int addBalance)
        {
            while (node != null)
            {
                node.Balance += addBalance;
                addBalance = node.Balance; 

                if (node.Balance == 2)
                {
                    if (node.LeftChild != null && node.LeftChild.Balance >= 0)
                    {
                        RotateLeftLeft(node);

                        if (node.Balance == -1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        RotateLeftRight(node);
                    }
                }
                else if (node.Balance == -2)
                {
                    if (node.RightChild != null && node.RightChild.Balance <= 0)
                    {
                        RotateRightRight(node);

                        if (node.Balance == 1)
                        {
                            return;
                        }
                    }
                    else
                    {
                        RotateRightLeft(node);
                    }
                }
                else if (node.Balance != 0)
                {
                    return;
                }

                AVLNode<TKey, TValue> parent = node.Parent;

                if (parent != null)
                {
                    if (parent.LeftChild == node)
                    {
                        addBalance = -1;
                    }
                    else
                    {
                        addBalance = 1;
                    }
                }
                node = parent;
            }
        }

        public static bool operator ==(AVLTree<TKey, TValue> a, AVLTree<TKey, TValue> b)
        {
            return AVLTree<TKey, TValue>.Equals(a, b);
        }

        public static bool operator !=(AVLTree<TKey, TValue> a, AVLTree<TKey, TValue> b)
        {
            return !AVLTree<TKey, TValue>.Equals(a, b);
        }

        //Traverses the tree in pre-order.
        public IEnumerator<AVLNode<TKey, TValue>> GetEnumerator()
        {
            Queue<AVLNode<TKey, TValue>> queue = new Queue<AVLNode<TKey, TValue>>();
            queue.Enqueue(this.root);

            AVLNode<TKey, TValue> tmp;
            while (queue.Count > 0)
            {
                tmp = queue.Dequeue();

                if (tmp.LeftChild != null)
                {
                    queue.Enqueue(tmp.LeftChild);
                }
                if (tmp.RightChild != null)
                {
                    queue.Enqueue(tmp.RightChild);
                }

                yield return tmp;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");

            Stack<AVLNode<TKey, TValue>> stack = new Stack<AVLNode<TKey, TValue>>();
            if (this.root != null)
            {
                stack.Push(root);
                AVLNode<TKey, TValue> tmpNode;
                while (stack.Count > 0)
                {
                    tmpNode = stack.Pop(); 

                    if (tmpNode.Parent == null)
                    {
                        result.AppendLine(tmpNode + " is root.");
                    }
                    else if (tmpNode.Parent.RightChild == tmpNode)
                    {
                        result.AppendLine(tmpNode.Parent + " has right child: " + tmpNode);
                    }
                    else
                    {
                        result.AppendLine(tmpNode.Parent + " has left child: " + tmpNode);
                    }

                    if (tmpNode.RightChild != null)
                    {
                        stack.Push(tmpNode.RightChild);
                    }
                    if (tmpNode.LeftChild != null)
                    {
                        stack.Push(tmpNode.LeftChild);
                    }
                }
            }
            return result.ToString();
        }

        /// <summary>
        /// Checks if every node in the current tree matches the corresponding node in the other tree.
        /// </summary>
        public override bool Equals(object obj)
        {
            AVLTree<TKey, TValue> tree = obj as AVLTree<TKey, TValue>;
            if (tree == null)
            {
                return false;
            }
            else
            {
                Queue<Tuple<AVLNode<TKey, TValue>, AVLNode<TKey, TValue>>> queue = 
                    new Queue<Tuple<AVLNode<TKey, TValue>, AVLNode<TKey, TValue>>>();

                AVLNode<TKey, TValue> item1, item2;

                queue.Enqueue(Tuple.Create(this.root, tree.root));
                while (queue.Count > 0)
                {
                    item1 = queue.Peek().Item1;
                    item2 = queue.Peek().Item2;
                    queue.Dequeue();

                    if (!item1.Equals(item2))
                    {
                        return false;
                    }
                    else if (item1.LeftChild == null && item2.LeftChild != null)
                    {
                        return false;
                    }
                    else if (item1.LeftChild != null && item2.LeftChild == null)
                    {
                        return false;
                    }
                    else if (item1.RightChild == null && item2.RightChild != null)
                    {
                        return false;
                    }
                    else if (item1.RightChild != null && item2.RightChild == null)
                    {
                        return false;
                    }
                    if (item1.LeftChild != null && item2.LeftChild != null)
                    {
                        queue.Enqueue(Tuple.Create(item1.LeftChild, item2.LeftChild));
                    }
                    if (item1.RightChild != null && item2.RightChild != null)
                    {
                        queue.Enqueue(Tuple.Create(item1.RightChild, item2.RightChild));
                    }
                }
                return true;
            }
        }

        /// <summary>
        ///Just XORs all hash codes of the nodes using pre-order traversal.
        /// </summary>
        public override int GetHashCode()
        {
            int treeHashCode = 0;
            Queue<AVLNode<TKey, TValue>> queue = new Queue<AVLNode<TKey, TValue>>();

            AVLNode<TKey, TValue> tmp;

            queue.Enqueue(this.root);
            while (queue.Count > 0)
            {
                tmp = queue.Dequeue();
                treeHashCode ^= tmp.GetHashCode();

                if (tmp.LeftChild != null)
                {
                    queue.Enqueue(tmp.LeftChild);
                }
                if (tmp.RightChild != null)
                {
                    queue.Enqueue(tmp.RightChild);
                }
            }
            return treeHashCode;
        }
    }
}
