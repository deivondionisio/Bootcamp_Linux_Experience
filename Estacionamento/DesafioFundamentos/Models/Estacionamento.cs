namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.veiculos = new List<string>();
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();

            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Veículo com placa {placa} adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida. A placa deve estar no formato AAA-9999.");
            }
        }

        private bool ValidarPlaca(string placa)
        {
            // Expressão regular para verificar o formato da placa: AAA-9999
            string pattern = @"^[A-Z]{3}-\d{4}$";
            return Regex.IsMatch(placa, pattern);
        }

        public void RemoverVeiculo(string placa)
        {
            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = Convert.ToInt32(Console.ReadLine());

                decimal valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(placa);

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

                Console.WriteLine("Digite o número do veículo que deseja remover:");
                int opcao = Convert.ToInt32(Console.ReadLine());

                if (opcao >= 1 && opcao <= veiculos.Count)
                {
                    string placa = veiculos[opcao - 1];
                    RemoverVeiculo(placa);
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

    }
}
