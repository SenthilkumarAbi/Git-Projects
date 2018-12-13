using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Assignments
{
  class Program
  {
    /*
    1.Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.
    Change some of the array elements and execute the same query again.
    Hint : use the logical operators of C# to combine the conditions
    2. Given a list of participants for a tennis match.Split the list into 2 equal halves and display all the possible combination of matches possible between the participants in the two lists.A condition is that no player should have an opponent who is from his own his own country.
    3. Create an Order class that has order id, item name, order date and quantity.Create a collection of Order objects.Display the data day wise from most recently ordered to least recently ordered and by quantity from highest to lowest.
    4. For the previous exercise, write a LINQ query that displays the details grouped by the month in the descending order of the order date.
    5. You have created Order class in the previous exercise and that has order id, item name, order date and quantity.Create another class called Item that has item name and  price.Write a LINQ query such that it returns order id, item name, order date and the total price(price* quantity) grouped by the month in the descending order of the order date.
    6. Do the previous exercise using anonymous types.
    7. Check if all the quantities in the Order collection is >0.
    Get the name of the item that was ordered in largest quantity in a single order. (Hint: use LINQ methods to sort)
    Find if there are any orders placed before Jan of this year.
    8. Rewrite the last two example of that used Count using LINQ query methods entirely.
    9. Given the array of numbers.Count and display even numbers.
    Write LINQ to get the sum of quantities for each item and also find out and display the item that has overall maximum orders.

    */

    static void Main(string[] args)
    {

      #region 1
      /*
      1.Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.
        Change some of the array elements and execute the same query again.
        */

      int[] n = { 2, 3, 4, 5, 8, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43 };
      var r = from i in n
              where (i * i * i) > 100 && (i * i * i) < 1000
              orderby i ascending
              select i;

      Console.WriteLine("Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.        Number list : 2, 3, 4, 5,8,  10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43");

      foreach (var k in r)
        Console.WriteLine(" Number is {0} , its cube values is {1}", k, (k * k * k));

      Console.WriteLine();
      Console.WriteLine("Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.        Number list : 2, 3, 4, 6,7,  9, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43");

      int[] n1 = { 2, 3, 4, 6, 7, 9, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43 };
      var r1 = from i in n1
               where (i * i * i) > 100 && (i * i * i) < 1000
               orderby i ascending
               select i;

      foreach (var k in r1)
        Console.WriteLine(" Number is {0} , its cube values is {1}", k, (k * k * k));

      Console.WriteLine();
      Console.WriteLine("Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.        Number list : 2, 3, 4, 5,6,7 , 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43");

      int[] n2 = { 2, 3, 4, 5, 6, 7, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43 };
      var r2 = from i in n2
               where (i * i * i) > 100 && (i * i * i) < 1000
               orderby i ascending
               select i;

      foreach (var k in r2)
        Console.WriteLine(" Number is {0} , its cube values is {1}", k, (k * k * k));
      Console.WriteLine();
      Console.WriteLine("Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.        Number list : 2, 3, 4, ,8, 9, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43");

      int[] n3 = { 2, 3, 4, 8, 9, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43 };
      var r3 = from i in n3
               where (i * i * i) > 100 && (i * i * i) < 1000
               orderby i ascending
               select i;

      foreach (var k in r3)
        Console.WriteLine(" Number is {0} , its cube values is {1}", k, (k * k * k));

      Console.ReadLine();

      #endregion

      #region 2
      /*
       * 2.Given a list of participants for a tennis match.Split the list into 2 equal halves and display all the possible combination of matches possible between the participants in the two lists.
       * A condition is that no player should have an opponent who is from his own his own country.
       * 
      */

      List<TennisPlayer> Group1 = new List<TennisPlayer>() { new TennisPlayer { PlayerName = "1.Feddrer", Country = "Swiss" },
                                                             new TennisPlayer { PlayerName = "3.Roger", Country = "Swiss" },
                                                             new TennisPlayer {PlayerName ="5.Andrew",Country="USA" },
                                                             new TennisPlayer {PlayerName ="7.DevenPort",Country="Sweden" },
                                                             new TennisPlayer {PlayerName ="9.Tim",Country="Australia" },
                                                             new TennisPlayer {PlayerName ="11.Payes",Country="India" }
                                                            };

      //{ "1.Feddrer", "3.Roger", "5.Andrew", "Devenport" };
      List<TennisPlayer> Group2 = new List<TennisPlayer>{ new TennisPlayer { PlayerName = "2.Rafel", Country = "Spanish" },
                                                             new TennisPlayer { PlayerName = "3.Roger", Country = "Swiss" },
                                                             new TennisPlayer {PlayerName ="5.Agassi",Country="USA" },
                                                             new TennisPlayer {PlayerName ="7.Henmen",Country="Australia" },
                                                             new TennisPlayer {PlayerName ="9.Sales",Country="Sweden" },
                                                             new TennisPlayer {PlayerName ="11.Leyander",Country="India" }
                                                            };

      //{ "2.Rafel", "4.Samprass", "6.Agassi", "Staffy" };
      //var res = (from l1 in Group1
      //           from l2 in Group1
      //           where l1 != l2
      //           select l1 + " vs " + l2
      //          );

      //var res1 = (from l1 in Group2
      //           from l2 in Group2
      //           where l1 != l2
      //           select l1 + " vs " + l2
      //        );
      Console.Clear();

      var res3 = (from l1 in Group1
                  from l2 in Group2
                  where l1.Country != l2.Country
                  select l1.PlayerName+"("+l1.Country +")" + " vs " + l2.PlayerName + "(" + l2.Country + ")"
              );

      //Console.WriteLine("*******************");
      //foreach (var item in res)
      //{
      //  Console.WriteLine(item);
      //}

      //Console.WriteLine("*******************");
      //foreach (var item in res1)
      //{
      //  Console.WriteLine(item);
      //}

      Console.WriteLine("*******************");
      foreach (var item in res3)
      {
        Console.WriteLine(item);
      }

      Console.ReadLine();
      Console.Clear();
      #endregion

      #region 3
      /*
       * 3. Create an Order class that has order id, item name, order date and quantity.Create a collection of Order objects.
       * Display the data day wise from most recently ordered to least recently ordered and by quantity from highest to lowest.
       * 
      */

      List<Order> Orderlst = new List<Order>() { new Order { OrderId = 1, ItemName = "Chair" , OrderDate = DateTime.Now.AddDays(10), Quantity = 10 },
                                                  new Order { OrderId =2, ItemName = "Shoe" , OrderDate = DateTime.Now.AddDays(3), Quantity = 16  },
                                                  new Order { OrderId = 3, ItemName = "Shirt" , OrderDate = DateTime.Now.AddDays(5), Quantity = 50  },
                                                  new Order { OrderId = 4, ItemName = "Bike" , OrderDate = DateTime.Now.AddDays(6), Quantity = 3  },
                                                  new Order { OrderId = 5, ItemName = "T-Shirt" , OrderDate = DateTime.Now.AddDays(8), Quantity = 25  },
                                                  new Order { OrderId = 6, ItemName = "Watch" , OrderDate = DateTime.Now.AddDays(2), Quantity = 30  },
                                                   new Order { OrderId = 7, ItemName = "Mobile" , OrderDate = DateTime.Now.AddDays(12), Quantity = 3  },
                                                  new Order { OrderId = 8, ItemName = "HeadSet" , OrderDate = DateTime.Now.AddDays(32), Quantity = 4  },
                                                  new Order { OrderId = 9, ItemName = "TV" , OrderDate = DateTime.Now.AddDays(15), Quantity = 1  },
                                                  new Order { OrderId = 10, ItemName = "Radio" , OrderDate = DateTime.Now.AddDays(8), Quantity = 4  }
                                                            };

      var OrderByDateWise = from i in Orderlst
                            orderby i.OrderDate  , i.Quantity 
                            select i;

      var OrderByQuantityWise = from i in Orderlst
                                orderby i.Quantity descending
                                select i;

      Console.WriteLine("Order Places from most recently ordered to least recently ordered");
      Console.WriteLine("  OrderId                                    ItemName                                      OrderDate                          Quantity");
      Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------");
      foreach (var item in OrderByDateWise)
      {
      
        Console.WriteLine("  {0}  |    {1}  |   {2}  |   {3} ", item.OrderId , item.ItemName, item.OrderDate.ToShortDateString(), item.Quantity);
      }

      Console.WriteLine();
      Console.WriteLine();
      Console.WriteLine();

      Console.WriteLine("Order Places by quantity from highest to lowest");
      Console.WriteLine("  OrderId           ItemName           OrderDate          Quantity");
      Console.WriteLine("------------------------------------------------------------------------");
      foreach (var item in OrderByQuantityWise)
      {

        Console.WriteLine("  {0}  |    {1}  |   {2}  |   {3} ", item.OrderId, item.ItemName, item.OrderDate.ToShortDateString(), item.Quantity);
      }

      Console.ReadLine();
      Console.Clear();
      #endregion  
    }
  }

  class TennisPlayer
  {
    public string PlayerName { get; set; }
    public string Country { get; set; }
  }

  class Order
  {
    //order id, item name, order date and quantity
    public int OrderId { get; set; }
    public string ItemName { get; set; }
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
  }
}
