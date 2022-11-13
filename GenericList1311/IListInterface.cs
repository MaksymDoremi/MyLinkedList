using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList1311
{
    internal interface IListInterface<T>
    {
        public void AddFirst(T item);

        public void AddLast(T item);

        public T GetValueAt(int index);

        public void Remove(int index);

        public int Count { get; }
    }
}
