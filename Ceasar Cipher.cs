using System.Net;
using System.Runtime.InteropServices;

namespace CaesarCipher
{
    class Program
    {
        
        static char Encode(char code, int shift) 
        {
                char letter = (char)(code + shift);
                if (letter < 'a')
                {
                    letter = (char)(code + shift + 26);
                }
                else if (letter > 'z')   
                {
                    letter = (char)(code + shift - 26);
                }

                
                return letter;
        }
        static string Decrypt(string cipherText, int shift)
        {
            shift %= 26;
            char[] buffer = cipherText.ToCharArray();
            for (int i = 0; i < buffer.Length; i++)
            {
                char code = buffer[i];
                if (code != ' ')
                {
                    code = Encode(code, shift);
                }
                
                
                
                
                buffer[i] = code;
            }
            return new string(buffer);
        }
        static void Main(string[] args)
        { 
            bool Continue = true;
            /*
            NetSpell.SpellChecker.Dictionary.WordDictionary oDict = new NetSpell.SpellChecker.Dictionary.WordDictionary(); 

            oDict.DictionaryFile = "en-US.dic"; 
            oDict.Initialize();
            
            NetSpell.SpellChecker.Spelling oSpell = new NetSpell.SpellChecker.Spelling(); 
            oSpell.Dictionary = oDict;  */
            while (Continue)
            {
                try
                {
                    bool correct = false;
                    string plainText = null;
                    Console.WriteLine("\nType a string to Decrypt:");
                    string cipherText = Console.ReadLine();
                    cipherText = cipherText.ToLower();
                    
                    if (!correct)
                    {
                        for (int key = 1; key < 26; key++) 
                        {
                            plainText = Decrypt(cipherText, key);
                            Console.WriteLine("  ");
                            Console.WriteLine(plainText);
                            //Console.WriteLine(key);
                            //if plainText 
                            /*
                            char[] chars = plainText.ToCharArray();
                            plainText = new string(chars.Where(c => !char.IsPunctuation(c)).ToArray());
                            string[] solution = plainText.Split();
                            
                            for (int i = 0; i < solution.Length; i++)
                            {

                                correct = true;
                                if(!oSpell.TestWord(solution[i]))
                                {
                                    correct = false;
                                }
                            }*/
                        }

                    }
                    if (correct)
                    {
                        //Console.WriteLine(plainText);
                    }
                    

                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Entry");
                }
            }

        }
    }
}