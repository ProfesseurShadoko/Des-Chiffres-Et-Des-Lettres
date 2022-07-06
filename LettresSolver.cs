

public class LettresSolver { //pour accélerer le tout on peut trier la liste de lettres dans l'ordre alphabétique au départ. A partir de là les mots seront générés dans l'ordre alphabétique et il sera plus facile pour wordset de trouver le bon resultat

    public static WordSet validWords = new WordSet("WordData.txt");

    private CardSetString cards;
    private string currentWord;
    public string bestWord;
    public int bestResult=0;
    

    public LettresSolver(string[] cards) {
        this.cards = new CardSetString(cards);
        currentWord="";
        bestWord="";
    }

    public void updateBestResult() {
        if (currentWord.Length <= bestResult ) {return;}
        if (!LettresSolver.isValid(currentWord)) {return;}
        this.bestResult = currentWord.Length;
        this.bestWord = currentWord; //askip il n'y a pas d'effets de bord
    }

    public static bool isValid(string word) {
        return LettresSolver.validWords.contains(word,true);
    }

    public bool isSolved() {
        return (this.bestResult==10);
    }

    public void run() {
        //System.Console.WriteLine(currentWord);
        this.updateBestResult();

        if (this.isSolved()){return;}

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
        LettresSolver.validWords.eraseSearchHistory(); //ca sera appelé à la toute fin, autant de fois qu'il y a eu d'appels recursifs
    }
}