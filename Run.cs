

public class Run {
    public enum GameMode{chiffres,lettres};
    public static GameMode mode=GameMode.lettres;
    public static CoupDeChiffres c=new CoupDeChiffres();
    public static CoupDeLettres l=new CoupDeLettres(5);

    public static void Main() {
        c.solve();
        l.solve();
        while(!c.solutionAvailable() && !l.solutionAvailable()) {}

        for (int i=0; i<16; i++) {
            if (mode==GameMode.chiffres) {
            c.display();
            while (!c.solutionAvailable()) {}
            c.displaySolution();
            }
            else {
                l.display();
                while (!l.solutionAvailable()) {}
                l.displaySolution();
            }
            changeMode();
        }
    }

    public static void changeMode() {
        if (mode==GameMode.chiffres) {
            mode=GameMode.lettres;
            c=new CoupDeChiffres();
            c.solve();
        }
        else {
            mode=GameMode.chiffres;
            l=new CoupDeLettres(5);
            l.solve();
        }
        createSeparation();
    }

    public static void createSeparation() {
        System.Console.WriteLine();
        System.Console.WriteLine("#################################################################################################################################################################################################");
        System.Console.WriteLine();
    }

}