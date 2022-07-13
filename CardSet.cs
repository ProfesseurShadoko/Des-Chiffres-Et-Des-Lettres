using System;

public class CardSet {

    public int[] set;
    public bool[] active;


    public CardSet(int[] cards) {
        this.set = new int[cards.Length];
        this.active = new bool[cards.Length];

        for (int i=0; i<cards.Length; i++) {
            this.set[i]=cards[i];
            this.active[i]=true;
        }
    }

    public CardSet(int size) {
        this.set = new int[size];
        this.active = new bool[size];

        for (int i=0; i<size; i++) {
            this.active[i]=false;
        }
    }

    public void activate(int pos) {
        this.active[pos]=true;
    }

    public void deactivate(int pos) {
        this.active[pos]=false;
    }

    public bool isActive(int pos) {
        return this.active[pos];
    }

    public int getCardinal() {
        int output=0;
        for (int i=0; i<set.Length;i++) {
            if (this.isActive(i)) {
                output++;
            }
        }
        return output;
    }

    public bool isEmpty() {
        return this.getCardinal()==0;
    }

    public int getElementPosition(int i) {
        int currentPos=-1;
        while (i>=0) {
            currentPos++;
            if (this.isActive(currentPos)) {
                i=i-1;
            }
        }
        return currentPos;
    }

    public int[] toArray() {
        int[] output = new int[this.getCardinal()];
        int currentPos=0;
        for (int i=0; i<this.set.Length; i++) {
            if (this.isActive(i)){
                output[currentPos]=this.set[i];
                currentPos++;
            }
        }
        return output;
    }

    public override string ToString() {
        string output = "{ ";
        for (int i=0; i<this.set.Length; i++) {
            if (this.isActive(i)) {
                output += $"{this.set[i]} ";
            }
            else {
                output += $"###{this.set[i]}### ";
            }
        }

        return output+"}";
    }
}

public class CardSetString {

    public string[] set;
    public bool[] active;


    public CardSetString(string[] cards) {
        this.set = new string[cards.Length];
        this.active = new bool[cards.Length];

        for (int i=0; i<cards.Length; i++) {
            this.set[i]=cards[i];
            this.active[i]=true;
        }
        Array.Sort(this.set);
    }

    public CardSetString(int size) {
        this.set = new string[size];
        this.active = new bool[size];

        for (int i=0; i<size; i++) {
            this.active[i]=false;
        }
    }

    public void activate(int pos) {
        this.active[pos]=true;
    }

    public void deactivate(int pos) {
        this.active[pos]=false;
    }

    public bool isActive(int pos) {
        return this.active[pos];
    }

    public int getCardinal() {
        int output=0;
        for (int i=0; i<set.Length;i++) {
            if (this.isActive(i)) {
                output++;
            }
        }
        return output;
    }

    public bool isEmpty() {
        return this.getCardinal()==0;
    }

    public int getElementPosition(int i) {
        int currentPos=-1;
        while (i>=0) {
            currentPos++;
            if (this.isActive(currentPos)) {
                i=i-1;
            }
        }
        return currentPos;
    }

    public string[] toArray() {
        string[] output = new string[this.getCardinal()];
        int currentPos=0;
        for (int i=0; i<this.set.Length; i++) {
            if (this.isActive(i)){
                output[currentPos]=this.set[i];
                currentPos++;
            }
        }
        return output;
    }

    public override string ToString() {
        string output = "{ ";
        for (int i=0; i<this.set.Length; i++) {
            if (this.isActive(i)) {
                output += $"{this.set[i]} ";
            }
            else {
                output += $"###{this.set[i]}### ";
            }
        }

        return output+"}";
    }
}