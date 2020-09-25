/*
    Rebecca Edson
    Enclara Pharmacia - Coding Assessment
*/

using System;
using System.Collections.Generic;

namespace CodingAssessment {

    public class CharStr {
        private List<char> letters;

        public CharStr(List<char> charList) {

            letters = charList;
        
        }

        // override ToString method to convert char list to string
        public override string ToString() {

            string str = "";

            foreach(char curr in letters) {
                str += curr.ToString();
            }

            return str;

        }
    }
    
    public class Word {
        private string word;
        private int count;

        public Word(string w) {

            word = w;
            count = 1;

        }

        public void Increment() {

            count++;
        
        }

        public string GetWord() {

            return word;

        }

        public int GetCount() {

            return count;

        }
    }

    class Paragraph {

        private string text;
        private List<Word> uniqueWords;

        public Paragraph(string input) {
            text = input.Trim();  // remove leading and trailing whitespace characters
            uniqueWords = new List<Word>();
        }

        public void FindUniqueWords() {

            int index = 0;  // index of char in paragraph

            while(index < text.Length) {
                
                List<char> charList = new List<char>();

                // add char to list if it is a letter
                while(index < text.Length && ((text[index] >= 65 && text[index] <= 90) || (text[index] >= 97 && text[index] <= 122))) {
                    char curr = text[index];
                    if(text[index] < 97)
                        curr += (char)32;
                    charList.Add(curr);
                    index++;
                }

                if(charList.Count > 0) {
                    CharStr charStr = new CharStr(charList);
                    string currWord = charStr.ToString();  // convert char list to string
                    bool exists = false;
                    for(int i = 0; i < uniqueWords.Count && uniqueWords.Count > 0; i++) {
                        // instance of existing word
                        if(String.Equals(currWord, uniqueWords[i].GetWord())) {
                            uniqueWords[i].Increment();
                            exists = true;
                            break;
                        }
                    }
                    // unique word
                    if(!exists) {
                        Word newWord = new Word(currWord);
                        uniqueWords.Add(newWord);
                    }
                }
                else
                    index++;

            }

        }
        public void ListUniqueWords() {

            Console.WriteLine("List of unique words in paragraph: ");
            for(int i = 0; i < uniqueWords.Count; i++) {
                Console.WriteLine(uniqueWords[i].GetWord() + " : {0}", uniqueWords[i].GetCount());
            }
            Console.Write("\r\n");

        }
        public int GetNumPalWords() {
            
            int numPalWords = 0;

            for(int i = 0; i < uniqueWords.Count; i++) {
                bool isPal = true;
                int length = uniqueWords[i].GetWord().Length;
                // word must have multiple characters
                if(length > 1) {
                    // compare first and last characters of string
                    // increment chars towards center
                    string currWord = uniqueWords[i].GetWord();
                    int j = 0, k = length - 1;
                    while(j <= k) {
                        if(currWord[j] != currWord[k]) {
                            isPal = false;
                        }
                        j++;
                        k--;
                    }
                }
                else
                    isPal = false;
                if(isPal)
                    numPalWords++;
            }

            return numPalWords;

        }
        public int GetNumPalSentences() {

            int numPalSentences = 0;

            // text split into strings separated by periods
            string[] sentences = text.Split('.');

            foreach(string str in sentences) {

                bool isPal = true;
                List<char> charList = new List<char>();

                // reduce to strings containing only letters
                for(int i = 0; i < str.Length; i++) {
                    if((str[i] >= 65 && str[i] <= 90) || (str[i] >= 97 && str[i] <= 122)) {
                        char curr = str[i];
                        if(str[i] < 97)
                             curr += (char)32;
                        charList.Add(curr);
                    }
                }

                CharStr charStr = new CharStr(charList);
                string cleanStr = charStr.ToString();
                int length = cleanStr.Length;
                int j = 0, k = length - 1;

                if(length > 1) {
                    while(j <= k) {
                    if(cleanStr[j] != cleanStr[k])
                        isPal = false;
                    j++;
                    k--;
                    }
                }
                else
                    isPal = false;

                if(isPal)
                    numPalSentences++;

            }

            return numPalSentences;

        }

        public void ListWordsWithLetter(char letter) {

            List<string> wordsWithLetter = new List<string>();

            for(int i = 0; i < uniqueWords.Count; i++) {
                string currWord = uniqueWords[i].GetWord();
                for(int j = 0; j < currWord.Length; j++) {
                    if(currWord[j] == letter) {
                        wordsWithLetter.Add(currWord);
                        break;
                    }
                }
            }

            int length = wordsWithLetter.Count;

            Console.WriteLine("\r\n\r\nWords containing {0}:", letter);
            for(int i = 0; i < length; i++) {
                Console.WriteLine(wordsWithLetter[i]);
            }
        }

    }
    
    class ParseParagraph {
        static void Main(string[] args) {

            Console.WriteLine("Enter a paragraph:");
            string text = Console.ReadLine();
            Console.Write("\r\n");

            Paragraph p = new Paragraph(text);
            p.FindUniqueWords();
            p.ListUniqueWords();

            Console.WriteLine("numPalWords: {0}", p.GetNumPalWords());
            Console.WriteLine("numPalSentences: {0}\r\n", p.GetNumPalSentences());

            Console.Write("Type a letter: ");
            char letter = Console.ReadKey().KeyChar;
            p.ListWordsWithLetter(letter);

        }

    }

}