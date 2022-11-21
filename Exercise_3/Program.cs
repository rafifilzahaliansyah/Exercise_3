﻿using System;
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
            Console.WriteLine("\nMasukkan Nama Mahasiswa : ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukkan Nama Mahasiswa : ");
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
            //if list empty
            if (listempty())
                Console.WriteLine("\nList Is Empty : ");
            //menampilkan data
            else
            {
                Console.WriteLine("\nRecord in the list are : ");
                node currentNode;

                currentNode = LAST.Next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollno + " " + currentNode.nama + "\n");
                    currentNode = currentNode.Next;
                }
                Console.Write(LAST.rollno + " " + LAST.nama + "\n");
            }
        }
        public bool listempty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }

    }

    class Program
    {
        public void Demo()
        {
            Console.WriteLine("=========================");
            Console.WriteLine("------- DATA ANDA -------");
            Console.WriteLine("=========================");
            Console.WriteLine("1. Add a record to the list");
            Console.WriteLine("2. Delete a record from the list");
            Console.WriteLine("3. View all records in list");
            Console.WriteLine("4. Search for a record in the list");
            Console.WriteLine("5. Exit\n");
            Console.WriteLine("Enter your choice (1-6): ");
        }
        static void Main(string[] args)
        {
            Program menu = new Program();
            CircularLinkedList data = new CircularLinkedList();
            node a = new node();

            while(true)
            {
                try
                {
                    Console.WriteLine();
                    menu.Demo();
                    char ch = Convert.ToChar(Console.ReadLine());

                    switch(ch)
                    {
                        //add data
                        case '1':
                            {
                                data.addnode();
                            }
                            break;
                    }
                }
            }
        }
    }
}
