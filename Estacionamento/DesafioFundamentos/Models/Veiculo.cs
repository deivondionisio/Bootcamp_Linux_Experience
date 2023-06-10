using System;

namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; }
        public string TipoVeiculo { get; }
        public DateTime DataEntrada { get; }
        public DateTime DataSaida { get; set; }

        public Veiculo(string placa, string tipoVeiculo, DateTime dataEntrada)
        {
            Placa = placa;
            TipoVeiculo = tipoVeiculo;
            DataEntrada = dataEntrada;
        }
    }
}
