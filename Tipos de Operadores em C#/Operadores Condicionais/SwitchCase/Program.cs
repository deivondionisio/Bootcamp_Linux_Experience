
Console.WriteLine("Digite uma letra");
string letra = Console.ReadLine();

switch (letra)
{
  case "a":
  case "e":
  case "i":
  case "o":
  case "u":
    Console.WriteLine("Vogal");
    break;

  default:
    Console.WriteLine("Não é uma vogal");
    break;
}



// if (letra == "a" ||
//   letra == "e" ||
//   letra == "i" ||
//   letra == "o" ||
//   letra == "u")
// {
//   Console.WriteLine("Vogal");
// }
// else
// {
//   Console.WriteLine("Não é uma Vogal");
// }