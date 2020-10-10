using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class PhoneBook
    {
        private Dictionary<int, string> phonebook;

        public PhoneBook()
        {
            phonebook = new Dictionary<int, string>();
        }

        public void Add_phone(string str, int key)
        {
            Console.WriteLine("Enter phone");
            str = Console.ReadLine();
            Console.WriteLine("Enter key");
            key = int.Parse(Console.ReadLine());
            bool ok = true;
            foreach (var item in phonebook)
            {
                if(item.Key == key)
                {
                    Console.WriteLine("Error, enter enother key!");
                    ok = false;
                }
            }

            if(ok == true)
                phonebook.Add(key, str);
        }

        public void Find_number_by_key(int find)
        {
            foreach (var item in phonebook)
            {
                if(item.Key == find)
                {
                    Console.WriteLine(item.Value);
                }
            }
        }

        public void Delete_by_key(int find)
        {
            bool ok = false;
            foreach (var item in phonebook)
            {
                if(item.Key == find)
                {
                    ok = true;
                }
            }

            if(ok == true)
                phonebook.Remove(find);
            else
                Console.WriteLine("Error, there are no this key in phonebook!");
        }

        public void Show_all_numbers_and_thear_keys()
        {
            foreach (var item in phonebook)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }

        public void Change_number_by_key(int key, string str)
        {
            Delete_by_key(key);
            Add_phone(str, key);
        }

    }

    public class Card : IComparable<Card>
    {
        public string Name { get; set; }
        public string Mast { get; set; }
        public int count_to_sort;

        public Card(string name, string mast)
        {
            Name = name;
            Mast = mast;
            count_to_sort = -1;
        }

        public Card()
        {

        }

        public int CompareTo(Card other)
        {
            return count_to_sort.CompareTo(other.count_to_sort);
        }

        public int Get_count_to_sort()
        {
            return count_to_sort;
        }

        public void Set_count_to_sort(int c)
        {
            count_to_sort = c;
        }

        public void Show_card()
        {
            Console.WriteLine(Name + " " + Mast);
        }
    }

    public class Deck_of_cards
    {
         
        Queue<Card> deck_of_cards = new Queue<Card>(36);
        Card[] cards = new Card[36];
        public Deck_of_cards()
        {
            deck_of_cards.Enqueue(new Card("6", "Hearts"));
            deck_of_cards.Enqueue(new Card("6", "Diamonds"));
            deck_of_cards.Enqueue(new Card("6", "Clubs"));
            deck_of_cards.Enqueue(new Card("6", "Spades "));
            deck_of_cards.Enqueue(new Card("7", "Hearts"));
            deck_of_cards.Enqueue(new Card("7", "Diamonds"));
            deck_of_cards.Enqueue(new Card("7", "Clubs"));
            deck_of_cards.Enqueue(new Card("7", "Spades "));
            deck_of_cards.Enqueue(new Card("8", "Hearts"));
            deck_of_cards.Enqueue(new Card("8", "Diamonds"));
            deck_of_cards.Enqueue(new Card("8", "Clubs"));
            deck_of_cards.Enqueue(new Card("8", "Spades "));
            deck_of_cards.Enqueue(new Card("9", "Hearts"));
            deck_of_cards.Enqueue(new Card("9", "Diamonds"));
            deck_of_cards.Enqueue(new Card("9", "Clubs"));
            deck_of_cards.Enqueue(new Card("9", "Spades "));
            deck_of_cards.Enqueue(new Card("10", "Hearts"));
            deck_of_cards.Enqueue(new Card("10", "Diamonds"));
            deck_of_cards.Enqueue(new Card("10", "Clubs"));
            deck_of_cards.Enqueue(new Card("10", "Spades "));
            deck_of_cards.Enqueue(new Card("Jackn", "Hearts"));
            deck_of_cards.Enqueue(new Card("Jack", "Diamonds"));
            deck_of_cards.Enqueue(new Card("Jack", "Clubs"));
            deck_of_cards.Enqueue(new Card("Jack", "Spades "));
            deck_of_cards.Enqueue(new Card("Queen", "Hearts"));
            deck_of_cards.Enqueue(new Card("Queen", "Diamonds"));
            deck_of_cards.Enqueue(new Card("Queen", "Clubs"));
            deck_of_cards.Enqueue(new Card("Queen", "Spades "));
            deck_of_cards.Enqueue(new Card("King", "Hearts"));
            deck_of_cards.Enqueue(new Card("King", "Diamonds"));
            deck_of_cards.Enqueue(new Card("King", "Clubs"));
            deck_of_cards.Enqueue(new Card("King", "Spades "));
            deck_of_cards.Enqueue(new Card("Ace", "Hearts"));
            deck_of_cards.Enqueue(new Card("Ace", "Diamonds"));
            deck_of_cards.Enqueue(new Card("Ace", "Clubs"));
            deck_of_cards.Enqueue(new Card("Ace", "Spades "));
        }

        public void Sort(IComparer<Card> comparer)
        {
            Array.Sort(cards, comparer);
        }

        public void Shuffle_deck()
        {
            Random rnd = new Random();
            int random;

            foreach (var item in deck_of_cards)
            {
                random = rnd.Next(0, 1000);
                item.Set_count_to_sort(random);
            }

            int a = 0;
            foreach (var item in deck_of_cards)
            {
                cards[a] = item;
                a++;
            }

            Sort(new CompareByCount_to_sort());

            Queue<Card> temp = new Queue<Card>(36);
            foreach (var item in cards)
            {
                temp.Enqueue(item);
            }

            deck_of_cards = temp;
        }

        public void Get_card_from_deck()
        {
            deck_of_cards.Dequeue();
        }

        public void Get_6_cards()
        {
            for (int i = 0; i < 6; i++)
            {
                Get_card_from_deck();
            }
        }

        public void Put_card_to_deck()
        {
            deck_of_cards.Enqueue(new Card());
        }

        public void Show_deck_of_card()
        {
            foreach (var item in deck_of_cards)
            {
                item.Show_card();
            }
        }
    }

    class CompareByCount_to_sort : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            return x.count_to_sort.CompareTo(y.count_to_sort);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1
            //ArrayList arrayList = new ArrayList();
            //int x = 2, y = 15, z = -20;
            //double s = 1.5, f = 5.5, p = 78.3;
            //bool t1 = false, t2 = true;
            //arrayList.Add(x);
            //arrayList.Add(y);
            //arrayList.Add(z);
            //arrayList.Add(s);
            //arrayList.Add(f);
            //arrayList.Add(p);
            //arrayList.Add(t1);
            //arrayList.Add(t2);
            //List<int> intList = new List<int>();
            //List<double> doubleList = new List<double>();
            //List<bool> boolList = new List<bool>();
            //foreach (var item in arrayList)
            //{
            //    if (item is int)
            //    {
            //        intList.Add((int)item);
            //    }
            //    else if (item is double)
            //    {
            //        doubleList.Add((double)item);
            //    }
            //    else if (item is bool)
            //    {
            //        boolList.Add((bool)item);
            //    }
            //}
            //foreach (var item in intList)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in doubleList)
            //{
            //    Console.WriteLine(item);
            //}
            //foreach (var item in boolList)
            //{
            //    Console.WriteLine(item);
            //}

            //2
            //List<string> stringList = new List<string>();
            //stringList.Add("lol");
            //stringList.Add("kek");
            //stringList.Add("fleks");
            //stringList.Add("omegalul");
            //stringList.Add("amegalol");
            //stringList.Sort();
            //int max_lenght = stringList[0].Length;
            //int index = 0, i = 0;
            //foreach (var item in stringList)
            //{
            //    if (item.Length > max_lenght)
            //    {
            //        max_lenght = item.Length;
            //        index = i;
            //    }
            //    i++;
            //}
            //Console.WriteLine(stringList[index]);

            //4
            Deck_of_cards deck_Of_Cards = new Deck_of_cards();
            deck_Of_Cards.Show_deck_of_card();
            deck_Of_Cards.Shuffle_deck();
            Console.WriteLine();
            deck_Of_Cards.Show_deck_of_card();
            //deck_Of_Cards.Lol();


        } 
    }      
}

