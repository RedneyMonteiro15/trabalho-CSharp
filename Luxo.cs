namespace trabalho
{
    public class Luxo : Viatura
    {
        decimal taxa;
        public Luxo(string matricula) : base(matricula)
        {
            taxa = 10;
        }
    }
}