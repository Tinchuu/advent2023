using System;
using System.IO;

namespace HelloWorld
{
  class PartOne
  {

    static int[] ConvertIntArray(string[] numbers) {
      List<int> numbersList = new List<int>();

      foreach (string number in numbers) {
        try {
          numbersList.Add(int.Parse(number));
        }
        catch (Exception) {
        }
      }

      return numbersList.ToArray();
    }


    static void Main(string[] args)
    {
      string path = "input.txt";
      int total = 0;

      try
      {
        string[] lines = File.ReadAllLines(path);
        
        foreach (string line in lines)
        {
          int cardTotal = 0;
          Dictionary<int, bool> numMap = new Dictionary<int, bool>();

          string[] card = line.Split('|');
          string[] cardContents = card[0].Split(':');

          int cardId = int.Parse(cardContents[0].Replace("Card ", ""));
          int[] cardNumbers = ConvertIntArray(cardContents[1].Split(' '));
          int[] userNumbers = ConvertIntArray(card[1].Split(' '));

          foreach (int cardNumber in cardNumbers) {
            numMap[cardNumber] = true;
          }

          foreach (int userNumber in userNumbers) {
            if (numMap.ContainsKey(userNumber)) {
              if (cardTotal == 0) {
                cardTotal++;
              } else {
                cardTotal *= 2;
              }
            }
          }

          total += cardTotal;
         }

      }
      catch (Exception ex)
      {
        Console.WriteLine($"Damn: {ex.Message}");
      }

      Console.WriteLine(total);
    }
  }
}