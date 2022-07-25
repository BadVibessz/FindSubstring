using System.Collections.Generic;
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

        public static int Find(string text, string subtext)
        {
            if (subtext.Length > text.Length) return -1;
            if (subtext == text) return 0;

            text = text.ToUpperInvariant();
            subtext = subtext.ToUpperInvariant();

            var dict = new Dictionary<int, int>(subtext.Length);

            var temp = new StringBuilder();
            for (int i = 0; i < subtext.Length; i++)
            {
                temp.Append(subtext[i]);
                dict.Add(i, PrefixFunction(temp.ToString()));
            }

            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < subtext.Length; j++)
                {
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
    }
}