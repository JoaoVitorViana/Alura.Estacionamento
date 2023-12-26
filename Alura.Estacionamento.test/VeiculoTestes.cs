using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.test;

public class VeiculoTestes
{
    [Fact]
    public void TestaVeiculoAcelerar()
    {
        //Arrange
        var veiculo = new Veiculo();
        //Act
        veiculo.Acelerar(10);
        //Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaVeiculoFreiar()
    {
        //Arrange        
        var veiculo = new Veiculo();
        //Act        
        veiculo.Frear(10);
        //Assert        
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaTipoVeiculo()
    {   
        //Arrange
        var veiculo = new Veiculo
        {
            Tipo = TipoVeiculo.Automovel
        };
        //Act            
        //Assert        
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }
}