
public class LettresSolver {

    public static WordSet validWords = new WordSet("WordData.txt");

    private CardSetString cards;
    private string currentWord;
    public string bestWord;
    public int bestResult=0;
    

    public LettresSolver(string[] cards) {
        this.cards = new CardSetString(cards);
        currentWord="";
        bestWord="";
        validWords.eraseSearchHistory();
    }

    public void updateBestResult() {
        if (!LettresSolver.isValid(currentWord)) {return;}
        if (currentWord.Length <= bestResult ) {return;}

        this.bestResult = currentWord.Length;
        this.bestWord = currentWord;
    }

    public static bool isValid(string word) {
        return LettresSolver.validWords.contains(word);
    }

    public bool isSolved() {
        return (this.bestResult==10);
    }

    public void run() {
        this.updateBestResult();

        if (!prefixEquals(currentWord,validWords.currentWord())) {
            return;
            }

        if (cards.getCardinal()==0) {return;}
        for (int i=0; i<10; i++){
            if (this.cards.isActive(i)) {
                this.cards.deactivate(i);
                currentWord+=this.cards.set[i];
                
                run();

                currentWord=currentWord.Remove(currentWord.Length-1);
                this.cards.activate(i);
            }
        }
    }

    public bool prefixEquals(string prefix, string word) {
        if (prefix.Length > word.Length) {return false;}
        return prefix.Equals(word.Substring(0,prefix.Length));
    }

    

    
}