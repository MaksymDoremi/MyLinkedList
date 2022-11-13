namespace GenericList1311 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyLinkedList<String> list = new MyLinkedList<String>();

            list.AddLast("aa");
            list.AddLast("bb");
            list.AddLast("cc");
            list.AddLast("aa");

            foreach(var a in list)
            {
                Console.WriteLine(a);
            }
        }
    }
}