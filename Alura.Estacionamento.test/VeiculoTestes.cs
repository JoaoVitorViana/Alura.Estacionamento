using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.test;

public class VeiculoTestes : IDisposable
{
    private Veiculo veiculo;
    public ITestOutputHelper saidaConsoleTeste { get; }
    public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
    {
        saidaConsoleTeste = _saidaConsoleTeste;
        saidaConsoleTeste.WriteLine("Construtor invocado.");
        veiculo = new Veiculo();
    }

    [Fact]
    // [Fact(DisplayName = "Teste nº 1")]
    // [Trait("Funcionalidade", "Acelerar")]
    public void TestaVeiculoAcelerarComParametro10()
    {
        //Arrange
        //var veiculo = new Veiculo();
        //Act
        veiculo.Acelerar(10);
        //Assert
        Assert.Equal(100, veiculo.VelocidadeAtual);
    }

    [Fact]
    // [Fact(DisplayName = "Teste nº 2")]
    // [Trait("Funcionalidade", "Freiar")]
    public void TestaVeiculoFreiarComParametro10()
    {
        //Arrange        
        //var veiculo = new Veiculo();
        //Act        
        veiculo.Frear(10);
        //Assert        
        Assert.Equal(-150, veiculo.VelocidadeAtual);
    }

    [Fact]
    public void TestaTipoVeiculo()
    {
        //Arrange
        // var veiculo = new Veiculo
        // {
        //     Tipo = TipoVeiculo.Automovel
        // };
        //Act            
        //Assert        
        Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
    }

    [Fact(Skip = "Teste ainda não implementado. Ignorar")]
    public void ValidaNomeProprietarioDoVeiculo()
    {

    }

    [Fact]
    public void FichaDeInformacaoDoVeiculo()
    {
        //Arrange
        // var carro = new Veiculo
        // {
        //     Tipo = TipoVeiculo.Automovel,
        //     Proprietario = "Carlos Silva",
        //     Placa = "ZAP-7419",
        //     Cor = "Verde",
        //     Modelo = "Variante"
        // };
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Proprietario = "Carlos Silva";
        veiculo.Placa = "ZAP-7419";
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Variante";
        //Act
        string dados = veiculo.ToString();

        //Assert
        Assert.Contains("Ficha do Veículo:", dados);
    }

    [Fact]
    public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
    {
        //Arrange
        string nomeProprietario = "Ab";

        //Assert
        Assert.Throws<FormatException>(
            //Act
            () => new Veiculo(nomeProprietario)
        );
    }

    [Fact]
    public void TestaMensagemDeExcecaoDoQuartoCaractereDaPlaca()
    {
        //Arrange
        string placa = "ASDF8888";

        //Act
        var mensagem = Assert.Throws<FormatException>(
            () => new Veiculo().Placa = placa
        );

        //Assert
        Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
    }

    public void Dispose()
    {
        saidaConsoleTeste.WriteLine("Dispose invocado.");
    }
}