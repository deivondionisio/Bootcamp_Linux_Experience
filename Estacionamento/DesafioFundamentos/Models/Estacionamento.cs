using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private int vagasCarro;
        private int vagasMoto;
        private int vagasCaminhao;
        private List<Veiculo> veiculos;
        private List<Veiculo> veiculosRemovidos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.vagasCarro = 70;
            this.vagasMoto = 20;
            this.vagasCaminhao = 10;
            this.veiculos = new List<Veiculo>();
            this.veiculosRemovidos = new List<Veiculo>();
        }

        public void AdicionarVeiculo(string tipoVeiculo)
        {
            bool adicionarOutroVeiculo = true;

            while (adicionarOutroVeiculo)
            {
                string placa;
                bool placaValida = false;

                do
                {
                    Console.WriteLine("Digite a placa do veículo para estacionar:");
                    placa = Console.ReadLine();

                    if (ValidarPlaca(placa))
                    {
                        placaValida = true;
                        Veiculo veiculo = new Veiculo(placa, tipoVeiculo, DateTime.Now);
                        veiculos.Add(veiculo);

                        switch (tipoVeiculo.ToLower())
                        {
                            case "carro":
                                vagasCarro--;
                                break;

                            case "moto":
                                vagasMoto--;
                                break;

                            case "caminhão 3/4":
                                vagasCaminhao--;
                                break;
                        }

                        Console.WriteLine($"Veículo com placa {placa} adicionado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Placa inválida. A placa deve estar no formato AAA-9999.");
                        Console.WriteLine("Deseja tentar novamente? (S/N)");
                        string resposta = Console.ReadLine();

                        if (resposta.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            adicionarOutroVeiculo = false;
                            break;
                        }
                    }
                } while (!placaValida);

                if (adicionarOutroVeiculo)
                {
                    Console.WriteLine("Deseja adicionar outro veículo? (S/N)");
                    string respostaAdicionarOutroVeiculo = Console.ReadLine();

                    if (respostaAdicionarOutroVeiculo.Equals("N", StringComparison.OrdinalIgnoreCase))
                        adicionarOutroVeiculo = false;
                }
            }
        }

        public void RemoverVeiculo(string placa)
        {
            Veiculo veiculo = veiculos.FirstOrDefault(v => v.Placa == placa);

            if (veiculo != null)
            {
                veiculo.DataSaida = DateTime.Now;
                veiculos.Remove(veiculo);
                veiculosRemovidos.Add(veiculo);

                TimeSpan duracaoEstacionamento = veiculo.DataSaida - veiculo.DataEntrada;
                decimal valorTotal = precoInicial + precoPorHora * (decimal)duracaoEstacionamento.TotalHours;

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");

                switch (veiculo.TipoVeiculo.ToLower())
                {
                    case "carro":
                        vagasCarro++;
                        break;

                    case "moto":
                        vagasMoto++;
                        break;

                    case "caminhão 3/4":
                        vagasCaminhao++;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Não foi encontrado nenhum veículo com a placa {placa}");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                int index = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{index}. {veiculo.Placa} - {veiculo.TipoVeiculo}");
                    index++;
                }

                Console.WriteLine("Digite o número do veículo que deseja remover ou 0 para retornar ao menu:");
                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao >= 1 && opcao <= veiculos.Count)
                {
                    Veiculo veiculo = veiculos[opcao - 1];
                    RemoverVeiculo(veiculo.Placa);
                }
                else if (opcao == 0)
                {
                    // O usuário escolheu retornar ao menu
                    return;
                }
                else
                {
                    Console.WriteLine("Opção inválida.");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        public void ImprimirVeiculosRemovidos()
        {
            if (veiculosRemovidos.Any())
            {
                Console.WriteLine("Veículos removidos:");

                foreach (var veiculo in veiculosRemovidos)
                {
                    Console.WriteLine($"{veiculo.Placa} - {veiculo.TipoVeiculo} - Entrada: {veiculo.DataEntrada}, Saída: {veiculo.DataSaida}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum veículo foi removido.");
            }
        }

        public decimal CalcularValorTotal()
        {
            decimal valorTotal = 0;

            foreach (var veiculo in veiculosRemovidos)
            {
                TimeSpan duracaoEstacionamento = veiculo.DataSaida - veiculo.DataEntrada;
                valorTotal += precoInicial + precoPorHora * (decimal)duracaoEstacionamento.TotalHours;
            }

            return valorTotal;
        }

        private bool ValidarPlaca(string placa)
        {
            Regex regex = new Regex(@"^[A-Z]{3}-\d{4}$");
            return regex.IsMatch(placa);
        }
    }
}
