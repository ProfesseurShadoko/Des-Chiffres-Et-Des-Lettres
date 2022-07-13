using System;
using System.IO; //File
using System.Linq; //sum and String compare
using System.Threading; //threading

public class CoupDeLettres {

    public static string[] voyelles = new string[] {"a","e","i","o","u","y"};
    public static int[] voyellesPourMille = new int[] {165,386,160,146,135,8};
    public static string[] consonnes = new string[] {"b","c","d","f","g","h","j","k","l","m","n","p","q","r","s","t","v","w","x","z"};
    public static int[] consonnesPourMille = new int[] {28,50,71,34,26,23,7,2,95,50,138,55,22,111,130,98,31};
    public static System.Random randomizer = new System.Random();
    private string[] cards;
    private bool solved;
    private bool running;
    private LettresSolver solver;

    public CoupDeLettres(int VoyellesNumber) {
        this.cards=CoupDeLettres.Shuffle(CoupDeLettres.randomCards(VoyellesNumber));
        this.solved=false;
        this.running=false;
        this.solver = new LettresSolver(this.cards);
    }

    public static string[] randomCards(int VoyellesNumber) {
        string[] output = new string[10];

        for (int i=0; i<VoyellesNumber;i++) {
            output[i]=CoupDeLettres.randomVoyelle();
        }

        for (int i=VoyellesNumber; i<10; i++) {
            output[i]=CoupDeLettres.randomConsonne();
        }
        return output;
    }

    public static string randomConsonne() {
        int tot=CoupDeLettres.consonnesPourMille.Sum();
        int limit = CoupDeLettres.randomizer.Next(0,tot);
        int currentTot=0;
        for (int i=0; i<CoupDeLettres.consonnes.Length; i++) {
            currentTot+=CoupDeLettres.consonnesPourMille[i];
            if (currentTot>=limit) {return CoupDeLettres.consonnes[i];}
        }
        throw new Exception("randomConsonne() doesn't work properly");
    }

    public static string randomVoyelle() {
        int tot=CoupDeLettres.voyellesPourMille.Sum();
        int limit = CoupDeLettres.randomizer.Next(0,tot);
        int currentTot=0;
        for (int i=0; i<CoupDeLettres.voyelles.Length; i++) {
            currentTot+=CoupDeLettres.voyellesPourMille[i];
            if (currentTot>=limit) {return CoupDeLettres.voyelles[i];}
        }
        throw new Exception("randomVoyelle() doesn't work properly");
    }

    public static string[] Shuffle(string[] cards) {
    return cards.OrderBy(x => CoupDeChiffres.randomizer.Next()).ToArray(); 
    }

    public override string ToString() {
        string output="Trouver le mot le plus long à partir des lettres suivantes :\n";
        foreach (string lettre in this.cards) {output+=lettre+" ";}
        return output;
    }

    public string[] getCards() {
        return this.cards;
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

    public string display() {
        System.Console.WriteLine(this.ToString());
        return this.ToString();
    }
    public string displaySolution() {
        this.solve();
        
        while (!this.solutionAvailable()) {}
        
        string output=$"J'ai {this.solver.bestResult} lettres : {this.solver.bestWord}";
        System.Console.WriteLine(output);
        return output;
    }
    public bool solutionAvailable() {
        return this.solved;
    }
}
