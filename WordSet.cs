

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

    public bool contains(string word,bool resume=false) {
        int beginAt=0;
        if (resume) {beginAt=this.lastLine;}

        return containsRec(word, beginAt, this.words.Length);
    }

    public bool containsRec(string word, int start,int stop) {
        this.lastLine = start;

        if (start>=stop-1) {
            return this.words[start].Equals(word);
        }

        int middle=(start+stop)/2;
        string middleWord = this.words[middle];
        string startWord = this.words[start];
        string stopWord = this.words[stop-1]; //stop excluded

        int c = String.Compare(word,middleWord);
        if (c==0) {return true;}
        else if (c<0) {return this.containsRec(word,start,middle);}
        else if (c>0) {return this.containsRec(word,middle,stop);}



        return false;
    }

    public void eraseSearchHistory() {
        lastLine = 0;
    }
}