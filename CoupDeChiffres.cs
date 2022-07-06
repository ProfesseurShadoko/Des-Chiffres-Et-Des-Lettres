

public class CoupDeChiffres {

    public static int[] cardsSet = new int[]{1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10,10,25,50,75,100};
    public static CardSet remainingCards = new CardSet(cardsSet);
    public static System.Random randomizer = new System.Random();
    
    private int[] cards;
    private int target;
    private bool solved;
    private ChiffresSolver solver;

    public CoupDeChiffres() {
        this.cards = new int[6];
        this.target=randomizer.Next(101,999);
        int cardIndex;
        int pos;
        for (int i=0; i<6; i++) {
            cardIndex=randomizer.Next(0,remainingCards.getCardinal());
            pos=remainingCards.getElementPosition(cardIndex);
            this.cards[i]=remainingCards.set[pos];
            remainingCards.deactivate(pos);

        }
        if (remainingCards.isEmpty()) {this.reset();}
        this.solved=false;
        this.solver = new ChiffresSolver(this.cards,this.target);
    }


    public void reset() {
        CoupDeChiffres.remainingCards = new CardSet(CoupDeChiffres.cardsSet);
    }

    public void display(){
        string output = $"Trouver {this.target} : ";
        for (int i=0; i<6; i++) {
            output+=$"{this.cards[i]} ";
        }
        System.Console.WriteLine(output);
    }
    public void displaySolution() {
        if (!this.solved) {this.solver.run();}
        if (this.solver.isSolved()) {System.Console.WriteLine("Le compte est bon !");}else{System.Console.WriteLine($"Il est impossible de trouver le bon resultat. J'ai trouvé : {solver.getBestResult()}");}
        System.Console.WriteLine(this.solver.parseBestMath());
    }

    public void solve(){
        this.solver.run();
        this.solved=true;
    }

/*    public static void Main() {
        
        for (int i=0; i<5; i++) {
            System.Console.WriteLine($"Solving {i+1}");
            CoupDeChiffres c = new CoupDeChiffres();
            c.display();
            c.displaySolution();
        }

        
        CoupDeChiffres c = new CoupDeChiffres();
        c.solver.showStatus();
        c.solver.appendMathOperation(25,25,1);
        c.solver.showStatus();
        c.solver.removeMathOperation();
        c.solver.showStatus();

    }*/

}
