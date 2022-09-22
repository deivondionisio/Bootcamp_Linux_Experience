namespace CalculandoRaizQuadrada.Models
{
    public class calculadora
    {
        public void RaizQuadrada(double x)
        {
            double raiz = Math.Sqrt(x);
            Console.WriteLine($"Raiz quadrada de {x} = {raiz}");
        }
    }
}