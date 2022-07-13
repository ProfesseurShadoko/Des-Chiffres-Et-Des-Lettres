using System;

public class ChiffresSolver {

    private static string[] operations = new string[] {"+","-","*","/"};

    private CardSet cards;
    private int target;
    private CardSet current_math = new CardSet(15); //cinq operation de 3 entiers (chiffre1,chiffre2,operation)
    public int[] bestMath;
    public int bestResult=2000;
    
    public ChiffresSolver(int[] cards,int target) {
        this.cards = new CardSet(cards);
        this.target=target;
        this.bestMath = new int[0];
    }

    public void updateBestResult() {
        int card;
        for (int i=0; i<cards.set.Length; i++) {
            if (this.cards.isActive(i)){
                card=this.cards.set[i];
                if (Math.Abs(card-this.target)<Math.Abs(this.bestResult-this.target)) {
                    this.bestResult=card;
                    this.bestMath=this.current_math.toArray();
                }
            }
        }
    }

    public bool isSolved() {
        return (this.bestResult==this.target);
    }

    public void run() {
        this.updateBestResult();

        if (this.isSolved()){return;}

        if (cards.getCardinal()==1) {return;}

        int c1;
        int c2;
        int newInt;

        for (int i=0; i<6; i++){
            if (this.cards.isActive(i)){
                c1=this.cards.set[i];
                this.cards.deactivate(i);

                for (int j=0; j<6; j++) {
                    if (this.cards.isActive(j)){
                        c2=this.cards.set[j];

                        for (int op=0; op<4; op++) {
                            try{
                                newInt = ChiffresSolver.applyOperation(c1,c2,op);
                                this.appendMathOperation(c1,c2,op);
                                this.cards.set[j]=newInt;

                                this.run();

                                this.cards.set[j]=c2;
                                this.removeMathOperation();
                            }
                            catch {}
                        }
                    }
                }
                this.cards.activate(i);
            }
        }

    }

    public void appendMathOperation(int c1, int c2, int op) {
        int pos = this.current_math.getCardinal();

        this.current_math.set[pos]=c1;
        this.current_math.activate(pos);

        this.current_math.set[pos+1]=c2;
        this.current_math.activate(pos+1);

        this.current_math.set[pos+2]=op;
        this.current_math.activate(pos+2);
        
    }

    public void removeMathOperation() {
        int pos = this.current_math.getCardinal()-1;
        this.current_math.deactivate(pos);
        this.current_math.deactivate(pos-1);
        this.current_math.deactivate(pos-2);
    }

    public string parseBestMath() {
        return ChiffresSolver.parse(this.bestMath);
    }

    public int getBestResult() {
        return this.bestResult;
    }

    public static int applyOperation(int c1, int c2, int op) {
        if (op==0) { //addition
            return c1+c2;
        }
        else if (op==1) { //soustraction
            return Math.Abs(c1-c2);
        }
        else if (op==2) { //multiplication
            return c1*c2;
        }
        else { //division
            if (c1>c2) {
                if (c1%c2==0) {
                    return c1/c2;
                }
                else {
                    throw new Exception("Invalid Integer Division");
                }
            }
            else {
                if (c2%c1==0) {
                    return c2/c1;
                }
                else {
                    throw new Exception("Invalid Integer Division");
                }
            }
        }
    }

    public static string parse(int[] math) {

        if (math==null) {return "";}

        string output="";
        int big;
        int small;
        int op;
        for (int i=0; i<math.Length/3; i++) {
            big=Math.Max(math[3*i],math[3*i+1]);
            small=Math.Min(math[3*i],math[3*i+1]);
            op=math[3*i+2];
            output+=$"{big} {ChiffresSolver.operations[op]} {small} = {ChiffresSolver.applyOperation(big,small,op)}\n";
        }
        return output;
    }

}