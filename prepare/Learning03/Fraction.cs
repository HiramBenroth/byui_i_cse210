using System.Dynamic;
using System.Globalization;

public class Fraction{
    private int Numerator;
    private int Denominator;

    public Fraction(int top = 1, int bot = 1){
        Numerator = top;
        Denominator = bot;
    }

    public int GetNumerator(){
        return Numerator;
    }

    public int GetDenominator(){
        return Denominator;
    }

    public void SetNumerator( int num){
        Numerator = num;
    }
    public void SetDenominator( int num){
        Denominator = num;
    }

    public string GetFractionString(){
        return $"{Numerator}/{Denominator}";
    }

    public double GetDecimalValue(){
        double dec =  (double)Numerator/Denominator ;
        return dec;
    }
}