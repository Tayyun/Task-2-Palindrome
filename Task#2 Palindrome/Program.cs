namespace Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputString = "";
            string TrashSymbolsString = "";
            bool check;

            Console.WriteLine("---------Palindrome Checker-------\n");
            Console.Write("InputString: ");
            InputString = Console.ReadLine();

            check = PalindromeChecker(InputString, ref TrashSymbolsString);

            Console.Write("TrashSymbolsString: ");

            foreach (char c in TrashSymbolsString.Distinct())
            {
                Console.Write(c);
            }

            Console.WriteLine("\nResult: " + check);
            Console.WriteLine("\n----------------------------------");
        }

        public static bool PalindromeChecker(string InputString, ref string TrashSymbolsString)
        {
            bool end = true;
            return read(0, InputString.Length - 1, ref TrashSymbolsString, ref end);

            bool read(int first, int last, ref string TrashSymbolsString, ref bool end)
            {
                // Skip first NotFound until Found , last Remain Unchanged
                while (first < last && !char.IsLetterOrDigit(InputString[first]))
                {
                    TrashSymbolsString += InputString[first];
                    first += 1;
                }

                // Skip last NotFound until Found , first Remain Unchanged
                while (first < last && !char.IsLetterOrDigit(InputString[last]))
                {
                    TrashSymbolsString += InputString[last];
                    last -= 1;
                }

                // First != Last
                if (InputString.ToLower()[first] != InputString.ToLower()[last])
                {
                    if (first < last)
                    {
                        end = false;
                        return read(first + 1, last - 1, ref TrashSymbolsString, ref end);
                    }
                    return false;
                }

                // First > Last
                if (first >= last)
                {
                    if (end == false)
                    {
                        if (!char.IsLetterOrDigit(InputString[last]))
                        {
                            TrashSymbolsString += InputString[last];
                        }
                        return false;
                    }
                    if (!char.IsLetterOrDigit(InputString[last]))
                    {
                        TrashSymbolsString += InputString[last];
                    }
                    return true;
                }

                // Both is identical
                return read(first + 1, last - 1, ref TrashSymbolsString, ref end);
            }
        }  
    }
}



/*
 * 
 * 
 *  byte[] ascii = Encoding.ASCII.GetBytes(InputString);

      for (int i = 0; i < ascii!.Length; i++)
      {
       if ((ascii[i] < 65 || ascii[i] > 90) && (ascii[i] < 97 || ascii[i] > 122) && (ascii[i] < 48 || ascii[i] > 57))
       {
         TrashSymbolString += InputString[i];
       }
      }
 * 
 * 
 * a @ b ! ! b $ a
 * 0 1 2 3 4 5 6 7
 * 
 * First = 0 , Last = 7
 * Found, Found ; string[firstValid] != string[lastValid] ? not_palindrome : update firstValid & lastValid
 * 
 * First = 0 + 1, Last = 7 - 1
 * First = 1, Last = 6
 * Not Found, Not Found ; Skip both + update firstValid & lastValid
 * 
 * First = 2, Last = 5
 * Found, Found ; string[firstValid] != string[lastValid] ? not_palindrome : update firstValid & lastValid
 * 
 * First = 3, Last = 4
 * Not Found, Not Found ; Skip both + update firstValid & lastValid
 * 
 * First = 4, Last = 4
 * First = Last ; Stop
 * 
 * 
 * a @ b ! $ ! b $ a
 * 0 1 2 3 4 5 6 7 8
 * 
 * First = 0 , Last = 8
 * Found, Found ; string[firstValid] != string[lastValid] ? not_palindrome : update firstValid & lastValid
 * 
 * First = 0 + 1, Last = 8 - 1
 * First = 1, Last = 7
 * Not Found, Not Found ; Skip both + update firstValid & lastValid
 * 
 * First = 2, Last = 6
 * Found, Found ; string[firstValid] != string[lastValid] ? not_palindrome : update firstValid & lastValid
 * 
 * First = 3, Last = 5
 * Not Found, Not Found ; Skip both + update firstValid & lastValid
 * 
 * First = 4, Last = 5
 * Not Found, Not Found ; Skip both + update firstValid & lastValid
 * 
 * First = 5, Last = 5
 * First = Last ; Stop
 * 
 * 
 * ? A a # c
 * 0 1 2 3 4
 * 
 * First = 0, Last 4
 * Not Found, Found 
 * 
 * First = 1, Last = 4
 * Found, Found ; Different -> return false
 * 
 * First = 2, Last = 3
 * Found, Not Found
 * 
 * First = 3, Last = 3
 * FIrst = Last ; Stop
 * 
*/
