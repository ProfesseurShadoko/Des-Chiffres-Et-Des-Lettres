using System.IO;
using System.Threading;

public class CoupDeChiffres {

    public static int[] cardsSet = new int[]{1,1,2,2,3,3,4,4,5,5,6,6,7,7,8,8,9,9,10,10,25,50,75,100};
    public static CardSet remainingCards = new CardSet(cardsSet);
    public static System.Random randomizer = new System.Random();
    
    private int[] cards;
    private int target;
    private bool solved;
    private bool running;
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

    public string display(){
        string output = $"Trouver {this.target} : ";
        for (int i=0; i<6; i++) {
            output+=$"{this.cards[i]} ";
        }
        System.Console.WriteLine(output);
        return output;
    }
    public string displaySolution() {
        
        this.solve();

        while (!this.solutionAvailable()) {}

        string output=this.solver.parseBestMath();
        if (this.solver.isSolved()) {System.Console.WriteLine("Le compte est bon !");}else{System.Console.WriteLine($"Il est impossible de trouver le bon resultat. J'ai trouvé : {solver.getBestResult()}");}
        System.Console.WriteLine(output);
        return output;
    }

    public int[] getCards() {
        return cards;
    }

    public int getTarget() {
        return target;
    }

    public void solve() {
        if (!this.solved && !this.running){
            this.running=true;
            Thread myStread = new Thread(solveInParallel);
            myStread.Start();
        }  
    }

    private void solveInParallel() {
        this.solver.run();
        this.running=false;
        this.solved=true;
    }

    public bool solutionAvailable() {
        return this.solved;
    }

}
