using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmLibrary
{
    public static class KnuthMorrisPratt
    {
        private static string GetPrefix(string str, int n)
        {
            var res = new StringBuilder();

            for (int i = 0; i < n; i++)
                res.Append(str[i]);

            return res.ToString();
        }

        private static string GetPostfix(string str, int n)
        {
            var res = new StringBuilder();

            for (int i = str.Length - n; i < str.Length; i++)
                res.Append(str[i]);
            return res.ToString();
        }

        private static int PrefixFunction(string str)
        {
            if (str.Length == 0) return 0;

            int max = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                if (GetPrefix(str, i + 1) == GetPostfix(str, i + 1))
                    max = i + 1;
            }

            return max;
        }

        public static int Find(string text, string subtext, int from = 0, int to = 0)
        {
            if (subtext.Length > text.Length) return -1;
            if (subtext == text) return 0;

            if (to == 0) to = text.Length;
            
            text = text.ToUpperInvariant();
            subtext = subtext.ToUpperInvariant();

            var dict = new Dictionary<int, int>(subtext.Length);

            var temp = new StringBuilder();
            for (int i = 0; i < subtext.Length; i++)
            {
                temp.Append(subtext[i]);
                dict.Add(i, PrefixFunction(temp.ToString()));
            }

            for (int i = from; i < to; i++)
            {
                for (int j = 0; j < subtext.Length; j++)
                {
                    if (i == text.Length - 1)
                    {
                        if (subtext.Length == 1 && text[text.Length - 1] == Convert.ToChar(subtext)) return text.Length - 1;
                        break;
                    }
                    
                    if (subtext[j] != text[i++])
                    {
                        if (j == 0)
                        {
                            j--;
                            continue;
                        }

                        j = dict[j - 1] - 1;
                        i--;
                        continue;
                    }

                    if (j == subtext.Length - 1) return i - subtext.Length;
                }
            }

            return -1;
        }

        public static int[] FindAll(string text, string subtext)
        {
            var res = new List<int>();
            
            int ind = Find(text, subtext);
            while (ind != -1)
            {
                res.Add(ind);
                ind = Find(text, subtext,ind+subtext.Length);
            }

            if (res.Count == 0) return null;
            return res.ToArray();
        }
    }
}