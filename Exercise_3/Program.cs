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

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
