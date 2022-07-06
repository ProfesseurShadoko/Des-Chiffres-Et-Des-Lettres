
public class Game{

    public enum GameMode{chiffres, lettres};
    public GameMode currentMode;
    
    public Game() {
        this.currentMode = GameMode.chiffres;
    }

    public void changeMode() {
        if (this.currentMode==GameMode.chiffres) {this.currentMode = GameMode.lettres;}
        else {this.currentMode = GameMode.chiffres;}
    }

    public void run() {
        CoupDeChiffres c;
        CoupDeLettres l;
        for (int i=0; i<10; i++) {
            if (this.currentMode == GameMode.chiffres) {
                c = new CoupDeChiffres();
                c.display();
                c.displaySolution();
            }
            else {
                l = new CoupDeLettres(5);
                l.display();
                l.displaySolution();
            }
            System.Console.WriteLine("_____________________________");
            System.Console.WriteLine();
            this.changeMode();
        }
        
    }

    public static void Main() {
        Game g = new Game();
        g.run();
    }
}