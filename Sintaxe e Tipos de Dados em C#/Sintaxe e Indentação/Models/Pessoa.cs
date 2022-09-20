using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp_Linux_Experience.Models
{
  public class Pessoa
  {
    public string Nome { get; set; }
    public int Idade { get; set; }

    public void Apresentar()

    {
      //Console.WriteLine($"Olá, seu nome é, {Nome} e tenho {Idade} anos");
      Console.WriteLine($"Olá, seu nome é {Nome} \n e tenho {Idade} anos");
    }
  }
}