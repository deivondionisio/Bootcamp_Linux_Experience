using System;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; }
        public DateTime DataEntrada { get; }
        public DateTime DataSaida { get; set; }

        public Veiculo(string placa, DateTime dataEntrada)
        {
            Placa = placa;
            DataEntrada = dataEntrada;
        }
    }
}
