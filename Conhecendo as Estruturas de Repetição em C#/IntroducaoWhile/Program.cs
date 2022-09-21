int numero = 5;
int contador = 0;

while (contador <= 10)
{
    Console.WriteLine($"{contador}° Execução: {numero} x {contador} = {numero * contador}");
    contador++;
}