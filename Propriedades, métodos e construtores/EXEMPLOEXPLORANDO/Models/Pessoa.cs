namespace ExemploExplorando.Models
{
    public class Pessoa
    {
        private string _nome;
        public string Nome
        {
            get => _nome.ToUpper();

            set /* => _nome = value; */
            {
                if (value == "")
                {
                    throw new ArgumentException("O nome não pode ser vazio");
                }

                _nome = value;
            }

        }


        public int Idade { get; set; }

        public void apresentar()
        {
            Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
        }
    }
}