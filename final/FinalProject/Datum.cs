public interface Datum {
    Datum getData();
    string getName();

    string getType();
    bool Compare(Datum d1, Datum d2);

    void Display();

}