int quantidadeEmEstoque = 3;
int quantidadeCompra = 0;
bool possivelVenda = quantidadeCompra > 0 && quantidadeEmEstoque >= quantidadeCompra;

Console.WriteLine($"Quantidade em estoque : {quantidadeEmEstoque}");
Console.WriteLine($"Quantidade compra: {quantidadeCompra}");
Console.WriteLine($"É possível realizar a venda? {possivelVenda}");

if (quantidadeCompra == 0)
{
  Console.WriteLine("Venda inválida");
}
else if (possivelVenda)
{
  Console.WriteLine("Venda realizada.");
}
else
{
  Console.WriteLine("Desculpe. Não temos a quantidade desejada em estoque.");
}
