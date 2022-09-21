namespace UsandoPotência.Models
{
    public class Calculadora
    {
        public void Potencia(int x, int y)
        {
            double pot = Math.Pow(x, y);
            Console.WriteLine($"{x}^{y}= {pot}");
        }
    }
}