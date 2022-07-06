

public class CoupDeLettres {

    public static string[] voyelles = new string[] {"a","e","i","o","u","y"};
    public static int[] voyellesPourMille = new int[] {165,386,160,146,135,8};
    public static string[] consonnes = new string[] {"b","c","d","f","g","h","j","k","l","m","n","p","q","r","s","t","v","w","x","z"};
    public static int[] consonnesPourMille = new int[] {28,50,71,34,26,23,7,2,95,50,138,55,22,111,130,98,31};
    public static System.Random randomizer = new System.Random();
    private string[] cards;
    private bool solved;
    private LettresSolver solver;

    public CoupDeLettres(int VoyellesNumber) {
        this.cards=CoupDeLettres.Shuffle(CoupDeLettres.randomCards(VoyellesNumber));
        this.solved=false;
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

    public void solve() {
        if (!this.solved){
            this.solver.run();
            this.solved=true;
        }  
    }

    public void display() {
        System.Console.WriteLine(this.ToString());
    }
    public void displaySolution() {
        if (!this.solved) {this.solve();}
        System.Console.WriteLine($"J'ai {this.solver.bestResult} lettres avec : {this.solver.bestWord}");
    }


    /*public static void Main() {
        /*System.Console.WriteLine(new CoupDeLettres(5));
        System.Console.WriteLine();
        System.Console.WriteLine(new CoupDeLettres(3));
        /*System.Console.WriteLine(LettresSolver.validWords.contains("zorglub",true));
        System.Console.WriteLine(LettresSolver.validWords.contains("bonjour",true));
        System.Console.WriteLine(LettresSolver.validWords.contains("bonjour",false));
        System.Console.WriteLine(LettresSolver.validWords.contains("restent",false));
        CoupDeLettres c;
        
        for (int i=0; i<5; i++) {
            c = new CoupDeLettres(5);
            c.display();
            c.displaySolution();
            System.Console.WriteLine();
        }
    }*/
}
