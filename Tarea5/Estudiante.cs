class Estudiante
{
    public string matricula { get; set; } = "";
    public string nombre { get; set; } = "";
    public string apellido { get; set; } = "";
    public string edad { get; set; } = "";
    public double N1 { get; set; }
    public double N2 { get; set; }
    public double promedio()
    {
        return (N1 + N2) / 2;

    }
    public string literal()
    {
        var literal = "F";
        var prom = this.promedio();
        if (prom >= 90)
        {
            literal = "A";
        }
        else if (prom >= 80)
        {
            literal = "B";
        }
        else if (prom >= 70)
        {
            literal = "C";
        }
        return literal;
    }
}
