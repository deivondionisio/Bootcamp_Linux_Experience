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
        private List<string> veiculos;
        private List<string> veiculosRemovidos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
            this.veiculosRemovidos = new List<string>();
        }

        public void AdicionarVeiculo()
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
                        veiculos.Add(placa);
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
            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa);
                veiculosRemovidos.Add(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
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
                    Console.WriteLine($"{index}. {veiculo}");
                    index++;
                }

                Console.WriteLine("Digite o número do veículo que deseja remover ou 0 para retornar ao menu:");
                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao >= 1 && opcao <= veiculos.Count)
                {
                    string placa = veiculos[opcao - 1];
                    RemoverVeiculo(placa);
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
                    Console.WriteLine(veiculo);
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
                Console.WriteLine("Digite a quantidade de horas que o veículo " + veiculo + " permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                valorTotal += precoInicial + precoPorHora * horas;
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
