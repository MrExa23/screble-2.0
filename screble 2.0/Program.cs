using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        Points points = new Points();
        Player player = new Player(points);

        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string W = Console.ReadLine();
            player.words.Add(W);
        }
        string LETTERS = Console.ReadLine();
        for (int i = 0; i < LETTERS.Length; i++)
        {
            if (player.letters.ContainsKey(LETTERS[i]))
            {
                player.letters[LETTERS[i]]++;
            }
            else
            {
                player.letters.Add(LETTERS[i], 1);
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(player.Game());
    }
}
class Points
{
    static List<char> point1 = new List<char>() { 'e', 'a', 'i', 'o', 'n', 'r', 't', 'l', 's', 'u' };
    static List<char> point2 = new List<char>() { 'd', 'g' };
    static List<char> point3 = new List<char>() { 'b', 'c', 'm', 'p' };
    static List<char> point4 = new List<char>() { 'f', 'h', 'v', 'w', 'y' };
    static List<char> point5 = new List<char>() { 'k' };
    static List<char> point8 = new List<char>() { 'j', 'x' };
    static List<char> point10 = new List<char>() { 'q', 'z' };
    public Dictionary<char, int> letterPoints = GivingLettersToLetterPoints();
    static Dictionary<char, int> GivingLettersToLetterPoints()
    {
        Dictionary<char, int> result = new Dictionary<char, int>();
        for (int i = 0; i < point1.Count; i++)
        {
            result.Add(point1[i], 1);
            if (i < point2.Count)
            {
                result.Add(point2[i], 2);
            }
            if (i < point3.Count)
            {
                result.Add(point3[i], 3);
            }
            if (i < point4.Count)
            {
                result.Add(point4[i], 4);
            }
            if (i < point5.Count)
            {
                result.Add(point5[i], 5);
            }
            if (i < point8.Count)
            {
                result.Add(point8[i], 8);
            }
            if (i < point10.Count)
            {
                result.Add(point10[i], 10);
            }
        }
        return result;
    }
    public int RatingWords(string w)
    {
        int wordPoint = 0;
        for (int i = 0; i < w.Length; i++)
        {
            wordPoint = wordPoint + letterPoints[w[i]];
        }
        return wordPoint;
    }
}
class Player
{
    public Dictionary<char, int> letters = new Dictionary<char, int>();
    public Dictionary<int, string> possibleWords = new Dictionary<int, string>();
    public List<string> words = new();
    public Points points { get; set; }
    public int key = 0;
    public Player(Points points)
    {
        this.points = points;
    }
    public string Game()
    {
        foreach (string word in words)
        {
            if (FiltringWords(word))
            {
                if (points.RatingWords(word) > key)
                {
                    key = points.RatingWords(word);
                    possibleWords.Add(points.RatingWords(word), word);
                }
            }
        }
        return possibleWords[key];
    }
    public bool FiltringWords(string word)
    {
        Dictionary<char, int> l = new Dictionary<char, int>(letters);
        if (word.Length <= 7)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (l.ContainsKey(word[i]))
                {
                    if (l[word[i]] > 0)
                    {
                        l[word[i]]--;
                    }
                    else return false;
                }

                else return false;
            }
            return true;
        }
        return false;
    }
}



