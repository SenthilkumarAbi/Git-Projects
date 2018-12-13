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
      /*
      1.Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.
        Change some of the array elements and execute the same query again.
        */

      int[] n = { 2, 3, 4, 5,8,  10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43 };
      var r = from i in n
              where (i * i * i) >100  && (i * i * i) < 1000
              orderby i ascending
              select i;

      Console.WriteLine("Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.        Number list : 2, 3, 4, 5,8,  10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43");
    
      foreach (var k in r)
        Console.WriteLine(" Number is {0} , its cube values is {1}",k, (k * k * k));

      Console.WriteLine();
      Console.WriteLine("Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.        Number list : 2, 3, 4, 6,7,  9, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43");

      int[] n1 = { 2, 3, 4,  6, 7,  9, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43 };
      var r1 = from i in n1
              where (i * i * i) > 100 && (i * i * i) < 1000
              orderby i ascending
              select i;

      foreach (var k in r1)
        Console.WriteLine(" Number is {0} , its cube values is {1}", k, (k * k * k));

      Console.WriteLine();
      Console.WriteLine("Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.        Number list : 2, 3, 4, 5,6,7 , 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43");

      int[] n2 = { 2, 3, 4, 5, 6, 7,   10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43 };
      var r2 = from i in n2
               where (i * i * i) > 100 && (i * i * i) < 1000
               orderby i ascending
               select i;

      foreach (var k in r2)
        Console.WriteLine(" Number is {0} , its cube values is {1}", k, (k * k * k));
      Console.WriteLine();
      Console.WriteLine("Given an array of numbers.Find the cube of the numbers that are greater than 100 but less than 1000 using LINQ.        Number list : 2, 3, 4, ,8, 9, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43");

      int[] n3 = { 2, 3, 4,   8, 9, 10, 12, 23, 34, 45, 56, 67, 78, 89, 98, 76, 65, 54, 43 };
      var r3 = from i in n3
               where (i * i * i) > 100 && (i * i * i) < 1000
               orderby i ascending
               select i;

      foreach (var k in r3)
        Console.WriteLine(" Number is {0} , its cube values is {1}", k, (k * k * k));

      Console.ReadLine();
    }
  }
}
