using System;
using System.IO;

namespace Day_4
{
    class PartTwo
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
            Dictionary<int, int> cardsMap = new Dictionary<int, int>();
            string path = "input.txt";
            int total = 0;

            try
            {
                string[] lines = File.ReadAllLines(path);
                
                foreach (string line in lines)
                {
                    int matches = 0;
                    Dictionary<int, bool> numMap = new Dictionary<int, bool>();

                    string[] card = line.Split('|');
                    string[] cardContents = card[0].Split(':');

                    int cardId = int.Parse(cardContents[0].Replace("Card ", ""));
                    int[] cardNumbers = ConvertIntArray(cardContents[1].Split(' '));
                    int[] userNumbers = ConvertIntArray(card[1].Split(' '));
                    if (!cardsMap.ContainsKey(cardId)) {
                        cardsMap[cardId] = 0;
                    }
                    cardsMap[cardId]++;

                    foreach (int cardNumber in cardNumbers) {
                        numMap[cardNumber] = true;
                    }
                    
                    foreach (int userNumber in userNumbers) {
                        if (numMap.ContainsKey(userNumber)) {
                            matches++;
                        }
                    }

                    for (int i = cardId + 1; i < cardId + matches + 1; i++) {
                        if (!cardsMap.ContainsKey(i)) {
                            cardsMap[i] = 0;
                        }
                        cardsMap[i] += cardsMap[cardId];
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Damn: {ex.Message}");
            }

            foreach (int key in cardsMap.Keys) {
                Console.WriteLine($"Card {key}: {cardsMap[key]}");
            }

            foreach (int key in cardsMap.Keys) {
                total += cardsMap[key];
            }

            Console.WriteLine(total);
        }
    }
}
