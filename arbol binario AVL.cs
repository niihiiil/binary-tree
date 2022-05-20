//script that generates an AVL binary tree
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL {
    class Program {
        static void Main(string[] args) {
            AVLTree<int> tree = new AVLTree<int>();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++) {
                tree.Insert(rnd.Next(0, 100));
            }
            tree.Print();
            Console.WriteLine("\n\n");
            tree.Delete(rnd.Next(0, 100));
            tree.Print();
            Console.ReadKey();
        }
    }

    class AVLTree<T> where T : IComparable {
        private AVLNode<T> root;

        public AVLTree() {
            root = null;
        }

        public void Insert(T value) {
            root = Insert(root, value);
        }

        private AVLNode<T> Insert(AVLNode<T> node, T value) {
            if (node == null) {
                return new AVLNode<T>(value);
            }
            if (value.CompareTo(node.Value) < 0) {
                node.Left = Insert(node.Left, value);
            } else if (value.CompareTo(node.Value) > 0) {
                node.Right = Insert(node.Right, value);
            }
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            return Balance(node);
        }

        public void Delete(T value) {
            root = Delete(root, value);
        }

        private AVLNode<T> Delete(AVLNode<T> node, T value) {
            if (node == null) {
                return null;
            }
            if (value.CompareTo(node.Value) < 0) {
                node.Left = Delete(node.Left, value);
            } else if (value.CompareTo(node.Value) > 0) {
                node.Right = Delete(node.Right, value);
            } else {
                if (node.Left == null) {
                    return node.Right;
                } else if (node.Right == null) {
                    return node.Left;
                }
                node.Value = MinValue(node.Right);
                node.Right = Delete(node.Right, node.Value);
            }
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            return Balance(node);
        }

        private T MinValue(AVLNode<T> node) {
            T min = node.Value;
            while (node.Left != null) {
                min = node.Left.Value; 
                node = node.Left;
            }
            return min;
        } else if (value.CompareTo(node.Value) > 0) {
                node.Right = Delete(node.Right, value);
            } else {
                if (node.Left == null) {
                    return node.Right;
                } else if (node.Right == null) {
                    return node.Left;
                }
                node.Value = MinValue(node.Right);
                node.Right = Delete(node.Right, node.Value);
            }
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            return Balance(node);
        } else if (value.CompareTo(node.Value) < 0) {
                node.Left = Delete(node.Left, value);
            } else {
                if (node.Left == null) {
                    return node.Right;
                } else if (node.Right == null) {
                    return node.Left;
                }
                node.Value = MinValue(node.Right);
                node.Right = Delete(node.Right, node.Value);
            }
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            return Balance(node);
        }

        private AVLNode<T> Balance(AVLNode<T> node) {
            if (BalanceFactor(node) == 2) {
                if (BalanceFactor(node.Right) < 0) {
                    node.Right = RotateRight(node.Right);
                }
                return RotateLeft(node);
            } else if (BalanceFactor(node) == -2) {
                if (BalanceFactor(node.Left) > 0) {
                    node.Left = RotateLeft(node.Left);
                }
                return RotateRight(node);
            }
            return node;
        } 
