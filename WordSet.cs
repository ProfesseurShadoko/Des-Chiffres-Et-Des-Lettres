using System.IO;
using System;

public class WordSet {

    private string[] words; //ordonnés par ordre alphabétique
    private int lastLine;

    public WordSet(string filename) {
        this.words = WordSet.collect(filename);
        this.lastLine=0;
    }

    public static string[] collect(string filename) {
        return File.ReadAllLines(filename);
    }

    public bool contains(string word) {
        return containsRec(word, this.words.Length);
    }

    public bool containsRec(string word, int stop) {

        if (lastLine>=stop-1) {
            return this.words[lastLine].Equals(word);
        }

        int middle=(lastLine+stop)/2;
        string middleWord = this.words[middle];
        string startWord = this.words[lastLine];
        string stopWord = this.words[stop-1]; //stop excluded

        int c = String.Compare(word,middleWord);
        if (c==0) {return true;}
        else if (c<0) {return this.containsRec(word,middle);}
        else if (c>0) {
            lastLine=middle;
            return this.containsRec(word,stop);}



        return false;
    }

    public void eraseSearchHistory() {
        lastLine = 0;
    }

    public string currentWord() {
        return this.words[lastLine+1];
    }

    public int getLastLine() {
        return this.lastLine;
    }
}