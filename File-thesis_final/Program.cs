using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace File_thesis_final
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream FS = new System.IO.FileStream("Test_Cases.txt", FileMode.OpenOrCreate, FileAccess.Read);//craete or open file
            StreamReader SR = new StreamReader(FS);//used to read from file
            List<Record> record_list = new List<Record>();
            Record r1 = new Record();
            List<int> mylist = new List<int>();
            string r_line, r_operation, r_id, r_size; //temp variables for reading from file
            char choice;
            int list_num = 1;
            Console.WriteLine("Enter [1] for First Fit Strategy  ||  Enter [2] for Best Fit Strategy :-");
            choice = char.Parse(Console.ReadLine());
            while (SR.Peek() != -1)
            {
                if (SR.Peek() == '~')
                {
                    Console.WriteLine("\t");
                    Console.WriteLine("List " + list_num);
                    Console.WriteLine("~~~~~~~~");
                    list_num++;
                    foreach (Record record in record_list)
                    {
                        record.Display_data();
                    };
                    Console.WriteLine("\t");
                    Console.WriteLine("\t");
                    SR.ReadLine();
                    mylist.Clear();
                    record_list.Clear();
                }
                r_line = SR.ReadLine();
                Console.WriteLine(r_line);
                Console.WriteLine("==========");
                if (r_line != null)
                {
                    var parts = r_line.Split(',');
                    r_operation = parts[0];
                    r_id = parts[1];
                    if (r_operation == "Add" && choice == '1') //first fit strategy
                    {
                        r_size = parts[2];
                        bool found = false;
                        Record r = new Record
                        {
                            ID = r_id,
                            size = int.Parse(r_size)
                        };
                        if (record_list.Count == 0)
                        {
                            record_list.Add(r);
                        }
                        else
                        {
                            for (int i = mylist.Count - 1; i >= 0; i--)
                            {
                                int x = mylist[i];
                                if (x >= r.size)
                                {
                                    foreach (Record element in record_list)
                                    {
                                        if (element.size == x && element.ID == "-1")
                                        {
                                            element.ID = r.ID;
                                            element.fragment += x - r.size;
                                            element.size = r.size;
                                            //Console.WriteLine("\t");
                                            //Console.WriteLine("item " + r.ID + " has been placed in first fit !");
                                            mylist.Remove(x);
                                            found = true;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            if (found != true)
                            {
                                record_list.Add(r);
                            }
                        }
                    }
                    else if (r_operation == "Add" && choice == '2') //best fit strategy
                    {
                        r_size = parts[2];
                        bool found = false;
                        Record r = new Record
                        {
                            ID = r_id,
                            size = int.Parse(r_size)
                        };
                        if (record_list.Count == 0)
                        {
                            record_list.Add(r);
                        }
                        else
                        {
                            mylist.Sort();
                            foreach (int y in mylist.ToList())
                            {
                                if (y >= r.size)
                                {
                                    foreach (Record element in record_list)
                                    {
                                        if (element.size == y)
                                        {
                                            element.ID = r.ID;
                                            element.fragment += y - r.size;
                                            element.size = r.size;
                                            //Console.WriteLine("\t");
                                            //Console.WriteLine("Item " + r.ID + " has been placed in best fit !");
                                            mylist.Remove(y);
                                            found = true;
                                            break;
                                        }
                                    }
                                    break;
                                }
                            }
                            if (found != true)
                            {
                                record_list.Add(r);
                            }
                        }
                    }
                    else
                    {
                        var parts_2 = record_list.FirstOrDefault(o => o.ID == r_id);
                        if (parts_2 != null)
                        {
                            mylist.Add(parts_2.size);
                            parts_2.ID = "-1";
                        }
                    }

                }
            }
            SR.Close();
            FS.Close();
        }
    }
    public class Record
    {
        public string ID;
        public int size;
        public int fragment;
        public void Display_data()
        {
            Console.WriteLine("-------------------");
            Console.Write("ID : ");
            if (ID == "-1")
            {
                Console.Write(ID + " (Empty)");
            }
            else
            {
                Console.Write(ID);
            }
            Console.WriteLine("\t");
            Console.Write("Size : ");
            Console.Write(size);
            Console.WriteLine("\t");
            if (fragment > 0) {
                Console.WriteLine("Fragmentation : " + fragment);
            }
        }
    }
}
