using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class MyTree
    {
        public int Value { get; set; }
        private MyTree _lower;
        private MyTree _higher;
        private MyTree _previous;

        public MyTree() { }

        public MyTree(int value, MyTree previous)
        {
            this.Value = value;
            this._previous = previous;
        }

        public MyTree(int value)
        {
            this.Value = value;
            _previous = new MyTree();
        }

        public bool Add(int value)
        {
            MyTree cur = MoveToLast(value);

            if (value > cur.Value)
            {
                cur._higher = new MyTree(value, cur);
                return true;
            }
            else if (value < cur.Value)
            {
                cur._lower = new MyTree(value, cur);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Add(MyTree tree)
        {
            MyTree cur = MoveToLast(tree.Value);

            if (tree.Value > cur.Value)
            {
                cur._higher = tree;
                tree._previous = cur;
                return true;
            }
            else if (tree.Value < cur.Value)
            {
                cur._lower = tree;
                tree._previous = cur;
                return true;
            }
            else
            {
                return false;
            }
        }

        public MyTree Find(int value)
        {
            MyTree cur = this.MoveToLast(value);
            if (cur.Value == value)
            {
                return cur;
            }
            else
            {
                return null;
            }
        }

        public bool Remove(int value)
        {
            MyTree tree = this.Find(value);
            if (tree != null)
            {
                if (tree._previous.Value > tree.Value)
                {
                    MyTree higher = tree._higher;
                    tree._previous._lower = tree._lower;
                    Add(higher);
                    return true;
                }
                else
                {
                    MyTree lower = tree._lower;
                    tree._previous._higher = tree._higher;
                    Add(lower);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public MyTree MoveToLast(int value)
        {
            MyTree cur = this;
            while (cur.Value != value)
            {

                if (value > cur.Value)
                {
                    if (cur._higher != null)
                    {
                        cur = cur._higher;
                    }
                    else
                    {
                        return cur;
                    }
                }
                else
                {
                    if (cur._lower != null)
                    {
                        cur = cur._lower;
                    }
                    else
                    {
                        return cur;
                    }
                }
            }
            return cur;
        }

        public bool Contains(int value)
        {
            MyTree tree = Find(value);
            if(tree is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
