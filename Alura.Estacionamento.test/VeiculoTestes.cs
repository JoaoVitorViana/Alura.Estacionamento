using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.test;

public class VeiculoTestes
{
    [Fact]
    public void TestaVeiculoAcelerar()
    {
        var veiculo = new Veiculo();
        veiculo.Acelerar(10);


        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFreiar()
    {
        var veiculo = new Veiculo();
        veiculo.Frear(10);

        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }
}