using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class node
    {
        //deklarasi variabel
        public int rollno;
        public string nama;
        public node Next;
    }

    class CircularLinkedList
    {
        node LAST;
        public CircularLinkedList()
        {
            LAST = null;
        }

        //menambahkan node
        public void addnode()
        {
            int number;
            string nm;

            //deklarasi element
            Console.WriteLine("\nMasukkan No.Barang : ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan Nama Barang : ");
            nm = Console.ReadLine();

            node newnode = new node();

            //membuat penyimpanan
            newnode.rollno = number;
            newnode.nama = nm;


            //if list empty
            if (listempty())
            {
                newnode.Next = newnode;
                LAST = newnode;
            }
            //mulai proses pengurutan proses pengurutan data
            else if (number < LAST.Next.rollno)//node dari kiri
            {
                newnode.Next = LAST.Next;
                LAST.Next = newnode;
            }
            else if (number > LAST.rollno)//node dari kanan
            {
                newnode.Next = LAST.Next;
                LAST.Next = newnode;
                LAST = newnode;
            }
            //menambahkan node di tengah tengah
            else
            {
                node current, previous;
                current = previous = LAST.Next;

                int i = 0;
                while (i < number - 1)
                {
                    previous = current;
                    current = current.Next;
                    i++;
                }
                newnode.Next = current;
                previous.Next = newnode;
            }
        }
        //menambahkan medhod mencari
        public bool Search(int rollnumber, ref node previous, ref node current)
        {
            for (previous = current = LAST.Next; current != LAST; previous = current, current = current.Next)
            {
                if (rollnumber == current.rollno)
                    return true;//return true if the node is found
            }
            if (rollnumber == LAST.rollno)
                return true;
            else
                return (false);
        }
        //menambahkan method delete
        public bool delNode(int number)
        {
            node previous, current;
            previous = current = LAST.Next;

            //mengecek spesifikasi isi nod sekarang masih ada didalam list atau tidak
            if (Search(number, ref previous, ref current) == false)
                return false;
            previous.Next = current.Next;

            //proses mendelete data
            if (LAST.Next.rollno == LAST.rollno)
            {
                LAST.Next = null;
                LAST = null;
            }
            else if (number == LAST.rollno)
            {
                LAST.Next = current.Next;
            }
            else
            {
                LAST = LAST.Next;
            }
            return true;
        }
        //mendisplay atau traverse semua node di list
        public void display()
        {

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
