# Enclara Pharmacia - Coding Assessment


<p>This program prompts the user to enter a paragraph into the console and reads it as a single string. Adjacent letters of the English alphabet (words) are determined and stored as strings. Each of these strings is subsequently compared against the list unique words stored as objects from class Word, and if it matches one, the instance count of that Word is incremented by 1. Otherwise a new instance of Word is created for the string and added to the list. The program then writes the words and their instance counts to the console.</p>

<p>The number of palindrome words in the paragraph is calculated by iterating through the list of unique words, where the first and last characters of the word are compared. If they are equal, the next and next-to-last character compared, and so forth until this iteration reaches the center of the word. If each comparison succeeds, the counter for the number of palindrome words is incremented.</p>

<p>For calculating the number of palindrome sentences in the paragraph, the string of text is separated by periods into an array of strings. Each string in this array is now considered a sentence. The alphabetic letters in each sentence are identified and stored as strings. Then these strings are determined to be palindromes by the same process used for words.</p>

<p>The user is prompted to type a letter into the console, and the letter is compared to each unique word's characters. If the word contains the letter, it is added to  a list of words also containing the letter.</p>
