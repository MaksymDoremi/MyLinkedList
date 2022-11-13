using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenericList1311
{
    internal class MyLinkedList<T> : IListInterface<T>, IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        private int count;


        public MyLinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public int Count
        {
            get { return count; }
        }

        public void AddFirst(T value)
        {
            Node<T> node = new Node<T>(value);
            if (head == null)
            {
                head = node;
                tail = node;
                count = 1;
                return;
            }
            head.Previous = node;
            node.Next = head;
            head = node;
            count++;

        }

        public void AddLast(T value)
        {
            Node<T> node = new Node<T>(value);
            if (head == null)
            {
                head = node;
                tail = node;
                count = 1;
                return;
            }

            tail.Next = node;
            node.Previous = tail;
            tail = node;
            count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyLinkedListEnumerator<T>(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T GetValueAt(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of bounds. Cannot get value at index" + index + " while Count is " + Count);
            }
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is less than zero");
            }

            Node<T> curr = head;
            for (int i = 0; i < index; i++)
            {
                curr = curr.Next;
            }

            return curr.Value;
        }

        public void Remove(int index)
        {
            if (index >= Count)
            {
                throw new IndexOutOfRangeException("Index is out of bounds. Cannot remove value at index" + index + " while Count is " + Count);
            }
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is less than zero");
            }
            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node<T> curr = head;
                for (int i = 0; i < index - 1; i++)
                {
                    curr = curr.Next;
                }

                curr.Next = curr.Next.Next;

                if (index == Count - 1)
                {
                    tail = curr;
                }

            }


        }


    }
    public class Node<T>
    {
        private Node<T> previous;
        private Node<T> next;
        private T value;

        public Node(T value)
        {
            Value = value;
        }

        public T Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public Node<T> Previous
        {
            get { return previous; }
            set { previous = value; }
        }

        public Node<T> Next
        {
            get { return next; }
            set { next = value; }
        }
    }

    class MyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> current;
        private int index = -1;

        public MyLinkedListEnumerator(Node<T> node)
        {
            current = node;

        }
        public T Current => current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (index == -1)
            {
                index++;
                return current != null;
            }

            index++;
            current = current.Next;
            return (current != null);

        }

        public void Reset()
        {
            index = -1;
        }
    }
}

