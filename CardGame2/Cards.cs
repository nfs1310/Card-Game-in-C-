using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame2
{
    public struct card
    {
        public string id;
        public string value;
               
        public card(string name, string val)
        {
            id = name;
            value = val;
        }
    }
    
    class Cards
    {

        Stack<card> slot1 = new Stack<card>();
        Stack<card> slot2 = new Stack<card>();
        Stack<card> slot3 = new Stack<card>();
        Stack<card> slot4 = new Stack<card>();

        static int points;
        List<card> lst;
        public List<card> shList;
        public static int count = 0;

        public void Execute()
        {
            card spade = new card();
            card hearts = new card();
            card dice = new card();
            card clubs = new card();

            lst = new List<card>();

            for (int i = 1; i <= 13; i++)
            {
                hearts.id = "(♥) Hearts";
                if (i == 1) hearts.value = "A";
                else if (i == 11) hearts.value = "J";
                else if (i == 12) hearts.value = "Q";
                else if (i == 13) hearts.value = "K";
                else
                {
                    string inputVal = Convert.ToString(i);
                    hearts.value = inputVal;
                }

                lst.Add(hearts);
                count++;
            }

            for (int i = 1; i <= 13; i++)
            {
                dice.id = "(♦) Dice";
                if (i == 1) dice.value = "A";
                else if (i == 11) dice.value = "J";
                else if (i == 12) dice.value = "Q";
                else if (i == 13) dice.value = "K";
                else
                {
                    string inputVal = Convert.ToString(i);
                    dice.value = inputVal;
                }

                lst.Add(dice);
                count++;
            }

            for (int i = 1; i <= 13; i++)
            {
                clubs.id = "(♣) Clubs";
                if (i == 1) clubs.value = "A";
                else if (i == 11) clubs.value = "J";
                else if (i == 12) clubs.value = "Q";
                else if (i == 13) clubs.value = "K";
                else
                {
                    string inputVal = Convert.ToString(i);
                    clubs.value = inputVal;
                }

                lst.Add(clubs);
                count++;
            }

            for (int i = 1; i <= 13; i++)
            {
                spade.id = "(♠) Spade";
                if (i == 1) spade.value = "A";
                else if (i == 11) spade.value = "J";
                else if (i == 12) spade.value = "Q";
                else if (i == 13) spade.value = "K";
                else
                {
                    string inputVal = Convert.ToString(i);
                    spade.value = inputVal;
                }

                lst.Add(spade);
                count++;
            }
                       
            shuffleCards();
        }

        public void shuffleCards()
        {
            Random rnd = new Random();
            //randomization complete
            var shuffleList = lst.OrderBy(x => rnd.Next().ToString());
            //adding the randomized numbers in another list, shList
            shList = new List<card>();


            //adding in the list
            foreach (card ccc in shuffleList)
            {
                shList.Add(ccc);
            }

            play();
            
        }

        public void play()
        {
        //START:
            int count = 0;
            card cTest1, cTest2;

            card stackEmpty = new card();
            stackEmpty.id = "$";
            stackEmpty.value = "•";

            card initialStack = new card();
            initialStack.id = "!!! ☻";
            initialStack.value = "0";

            slot1.Push(initialStack);
            slot2.Push(initialStack);
            slot3.Push(initialStack);
            slot4.Push(initialStack);


        DealCard:
            if (count == 52)
            {
                goto END;
            }

            int i = 0;
            int currentIndex = slot1.Count();
            bool confirmDel = false;

            while (i != 4)
            {
                slot1.Push(shList[count]); count++; i++;
                slot2.Push(shList[count]); count++; i++;
                slot3.Push(shList[count]); count++; i++;
                slot4.Push(shList[count]); count++; i++;
            }

        NextCard:
            Console.Clear();
            card ccc1 = slot1.Peek(); 
            Console.WriteLine("\nSlot 1:\t{0} {1}", ccc1.id, ccc1.value);

            card ccc2 = slot2.Peek();
            Console.WriteLine("\nSlot 2:\t{0} {1}", ccc2.id, ccc2.value);

            card ccc3 = slot3.Peek();
            Console.WriteLine("\nSlot 3:\t{0} {1}", ccc3.id, ccc3.value);

            card ccc4 = slot4.Peek();
            Console.WriteLine("\nSlot 4:\t{0} {1}", ccc4.id, ccc4.value);
            
            Console.WriteLine("\n\nCards Left:\t{0}\nPoints:\t{1}", 52 - count, points);

            Console.WriteLine("\n\n\t\t\t\t~~~ OPTIONS ~~~");
            Console.WriteLine("1. Deal Card\n2. Discard Card\n3. Move Card\n4. Exit\n5. Play Again");
            Console.Write("\n\nYour Choice:\t");
            int inputChoice = (int)Convert.ToInt32(Console.ReadLine());

            if (inputChoice == 1)
            {
                Console.Clear();
                goto DealCard;
            }
            else if (inputChoice == 2)
            {
                Console.Write("Enter Slot number:\t");
                int delSlot = (int)Convert.ToInt32(Console.ReadLine());

                if (delSlot == 1)
                {
                    cTest1 = slot1.Peek();
                    cTest2 = slot2.Peek();                          //slot 1 & 2 works fine...
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto next1;
                    }
                    else if (confirmDel == true)
                    {
                       // Console.WriteLine("popping 1 & 2");
                        slot1.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                next1:
                    //Console.WriteLine("\t\tExecuting next1");
                    cTest1 = slot1.Peek();
                    cTest2 = slot3.Peek();                          //slot 1 & 3 works fine...
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto next2;
                    }
                    else if (confirmDel == true)
                    {
                        //Console.WriteLine("popping 1 & 3");
                        slot1.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                next2:
                    //Console.WriteLine("\t\tExecuting next2");
                    cTest1 = slot1.Peek();
                    cTest2 = slot4.Peek();                      //slot 1 & 4 works fine.....
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto NextCard;
                    }
                    else if (confirmDel == true)
                    {
                        //Console.WriteLine("popping 1 & 4");
                        slot1.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }                    
                }
                else if (delSlot == 2)
                {
                    cTest1 = slot2.Peek();
                    cTest2 = slot1.Peek();                          //slot 2 & 1 works fine...
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto next3;
                    }
                    else if (confirmDel == true)
                    {
                        // Console.WriteLine("popping 1 & 2");
                        slot2.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                next3:
                    //Console.WriteLine("\t\tExecuting next1");
                    cTest1 = slot2.Peek();
                    cTest2 = slot3.Peek();                          //slot 2 & 3 works fine...
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto next4;
                    }
                    else if (confirmDel == true)
                    {
                        //Console.WriteLine("popping 1 & 3");
                        slot2.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                next4:
                    //Console.WriteLine("\t\tExecuting next2");
                    cTest1 = slot2.Peek();
                    cTest2 = slot4.Peek();                      //slot 2 & 4 works fine.....
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto NextCard;
                    }
                    else if (confirmDel == true)
                    {
                        //Console.WriteLine("popping 1 & 4");
                        slot2.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                }
                else if (delSlot == 3)
                {
                    cTest1 = slot3.Peek();
                    cTest2 = slot1.Peek();                          //slot 3 & 1 works fine...
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto next5;
                    }
                    else if (confirmDel == true)
                    {
                        // Console.WriteLine("popping 1 & 2");
                        slot3.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                next5:
                    //Console.WriteLine("\t\tExecuting next1");
                    cTest1 = slot3.Peek();
                    cTest2 = slot2.Peek();                          //slot 3 & 2 works fine...
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto next6;
                    }
                    else if (confirmDel == true)
                    {
                        //Console.WriteLine("popping 1 & 3");
                        slot3.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                next6:
                    //Console.WriteLine("\t\tExecuting next2");
                    cTest1 = slot3.Peek();
                    cTest2 = slot4.Peek();                      //slot 3 & 4 works fine.....
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto NextCard;
                    }
                    else if (confirmDel == true)
                    {
                        //Console.WriteLine("popping 1 & 4");
                        slot3.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                }
                else if (delSlot == 4)
                {
                    cTest1 = slot4.Peek();
                    cTest2 = slot1.Peek();                          //slot 4 & 1 works fine...
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto next7;
                    }
                    else if (confirmDel == true)
                    {
                        // Console.WriteLine("popping 1 & 2");
                        slot4.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                next7:
                    //Console.WriteLine("\t\tExecuting next1");
                    cTest1 = slot4.Peek();
                    cTest2 = slot2.Peek();                          //slot 4 & 2 works fine...
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto next8;
                    }
                    else if (confirmDel == true)
                    {
                        //Console.WriteLine("popping 1 & 3");
                        slot4.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                next8:
                    //Console.WriteLine("\t\tExecuting next2");
                    cTest1 = slot4.Peek();
                    cTest2 = slot3.Peek();                      //slot 4 & 3 works fine.....
                    confirmDel = Compare(cTest1, cTest2);
                    if (confirmDel == false)
                    {
                        goto NextCard;
                    }
                    else if (confirmDel == true)
                    {
                        //Console.WriteLine("popping 1 & 4");
                        slot4.Pop();
                        points++;
                        Console.Clear();
                        goto NextCard;
                    }
                }
            }
            else if (inputChoice == 3)
            {
                Console.Write("From Slot:\t");
                int frmSlot = (int)Convert.ToInt32(Console.ReadLine());
                Console.Write("To Slot:\t");
                int toSlot = (int)Convert.ToInt32(Console.ReadLine());

                MoveCard(frmSlot, toSlot);
                goto NextCard;
            }
            else if (inputChoice == 5)
            {
                Console.Clear();
                shuffleCards();
            }

            else if (inputChoice == 4)
            {
                Console.Clear();
                goto END;
            }
            else
            {
                Console.Clear();
                goto NextCard;
            }

            END:
                Console.Clear();
                Console.WriteLine("GAME OVER...!!!!\n\nYour Points:\t{0}", points);
                Console.Write("Play Again...??? ( y/ n ) :\t");
                string againPlay = Console.ReadLine().ToString().ToUpper();
                if (againPlay == "Y")
                {
                    shuffleCards();
                }
                Console.WriteLine();            
        }

        public static bool Compare(card cc1, card cc2) 
        {
            int val_1, val_2;
            string valA, valB;

            valA = cc1.value;
            if (valA == "A")
            {
                val_1 = 14;
            }
            else if (valA == "K")
            {
                val_1 = 13;
            }
            else if (valA == "Q")
            {
                val_1 = 12;
            }
            else if (valA == "J")
            {
                val_1 = 11;
            }
            else 
            {
                val_1 = (int)Convert.ToInt32(cc1.value);
                //Console.WriteLine("*****************************val_1:\t" + val_1);
            }


            valB = cc2.value;
            if (valB == "A")
            {
                val_2 = 14;
            }
            else if (valB == "K")
            {
                val_2 = 13;
            }
            else if (valB == "Q")
            {
                val_2 = 12;
            }
            else if (valB == "J")
            {
                val_2 = 11;
            }
            else
            {
                val_2 = (int)Convert.ToInt32(cc2.value);
                //Console.WriteLine("*****************************val_2:\t" + val_2);
            }

            if ((cc1.id == cc2.id) && (val_1 < val_2)) return true;
            else return false;

        }


        public void MoveCard(int frmSlot1, int toSlot2)
        {

            if ((toSlot2 == 1) && (frmSlot1 == 2))
            {
                slot1.Push(slot2.Pop());
            }
            if ((toSlot2 == 1) && (frmSlot1 == 3))
            {
                slot1.Push(slot3.Pop());
            }
            if ((toSlot2 == 1) && (frmSlot1 == 4))
            {
                slot1.Push(slot4.Pop());
            }
            
            if ((toSlot2 == 2) && (frmSlot1 == 1))
            {
                slot2.Push(slot1.Pop());
            }
            if ((toSlot2 == 2) && (frmSlot1 == 3))
            {
                slot2.Push(slot3.Pop());
            }
            if ((toSlot2 == 2) && (frmSlot1 == 4))
            {
                slot2.Push(slot4.Pop());
            }

            if ((toSlot2 == 3) && (frmSlot1 == 1))
            {
                slot3.Push(slot1.Pop());
            }
            if ((toSlot2 == 3) && (frmSlot1 == 2))
            {
                slot3.Push(slot2.Pop());
            }
            if ((toSlot2 == 3) && (frmSlot1 == 4))
            {
                slot3.Push(slot4.Pop());
            }

            if ((toSlot2 == 4) && (frmSlot1 == 1))
            {
                slot4.Push(slot1.Pop());
            }
            if ((toSlot2 == 4) && (frmSlot1 == 2))
            {
                slot4.Push(slot2.Pop());
            }
            if ((toSlot2 == 4) && (frmSlot1 == 3))
            {
                slot4.Push(slot3.Pop());
            }
        }
        
    }
}
