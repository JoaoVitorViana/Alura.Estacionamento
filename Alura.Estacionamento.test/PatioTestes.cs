using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.test;

public class PatioTestes : IDisposable
{
    private Veiculo veiculo;
    private Patio estacionamento;
    public ITestOutputHelper saidaConsoleTeste { get; }
    public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
    {
        saidaConsoleTeste = _saidaConsoleTeste;
        saidaConsoleTeste.WriteLine("Construtor invocado.");
        veiculo = new Veiculo();
        estacionamento = new Patio
        {
            OperadorPatio = new Operador
            {
                Nome = "Pedro Fagundes"
            }
        };
    }

    [Fact]
    public void ValidarFaturamentoDoEstacionamentoComUmVeiculo()
    {
        //Arrange
        //var estacionamento = new Patio();
        // var veiculo = new Veiculo
        // {
        //     Proprietario = "André",
        //     Tipo = TipoVeiculo.Automovel,
        //     Cor = "Verde",
        //     Modelo = "Fusca",
        //     Placa = "asd-9999"
        // };

        veiculo.Proprietario = "André";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "asd-9999";

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
        //Act
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);
    }

    [Theory]
    [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
    [InlineData("Jose Silva", "POL-9242", "cinza", "Fusca")]
    [InlineData("Maria Silva", "GDR-6524", "azul", "Opala")]
    [InlineData("Pedro Silva", "GDR-0101", "azul", "Corsa")]
    public void ValidaFaturamentoDoEstacionamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
    {
        //Arrange
        //var estacionamento = new Patio();
        // var veiculo = new Veiculo
        // {
        //     Proprietario = proprietario,
        //     Tipo = TipoVeiculo.Automovel,
        //     Cor = cor,
        //     Modelo = modelo,
        //     Placa = placa
        // };

        veiculo.Proprietario = proprietario;
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;
        veiculo.Placa = placa;

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
        //Act
        double faturamento = estacionamento.TotalFaturado();

        //Assert
        Assert.Equal(2, faturamento);
    }

    [Theory]
    [InlineData("André Silva", "ASD-1498", "preto", "Gol")]
    public void LocalizaVeiculoNoPatioComBaseNoIdTicket(string proprietario, string placa, string cor, string modelo)
    {
        //Arrange
        //var estacionamento = new Patio();
        // var veiculo = new Veiculo
        // {
        //     Proprietario = proprietario,
        //     Tipo = TipoVeiculo.Automovel,
        //     Cor = cor,
        //     Modelo = modelo,
        //     Placa = placa
        // };
        veiculo.Proprietario = proprietario;
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = cor;
        veiculo.Modelo = modelo;
        veiculo.Placa = placa;

        estacionamento.RegistrarEntradaVeiculo(veiculo);
        //Act
        var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

        //Assert
        Assert.Contains("### Ticket Estacionamento Alura ###", consultado.Ticket);
    }

    [Fact]
    public void AlterarDadosDoProprioVeiculo()
    {
        //Arrange
        //var estacionamento = new Patio();
        // var veiculo = new Veiculo
        // {
        //     Proprietario = "André",
        //     Tipo = TipoVeiculo.Automovel,
        //     Cor = "Verde",
        //     Modelo = "Fusca",
        //     Placa = "asd-9999"
        // };
        veiculo.Proprietario = "André";
        veiculo.Tipo = TipoVeiculo.Automovel;
        veiculo.Cor = "Verde";
        veiculo.Modelo = "Fusca";
        veiculo.Placa = "asd-9999";
        estacionamento.RegistrarEntradaVeiculo(veiculo);

        var veiculoAlterado = new Veiculo
        {
            Proprietario = "André",
            Tipo = TipoVeiculo.Automovel,
            Cor = "Preto", // Alterado
            Modelo = "Fusca",
            Placa = "asd-9999"
        };

        //Act   
        var alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

        //Assert
        Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
    }

    public void Dispose()
    {
        saidaConsoleTeste.WriteLine("Dispose invocado.");
    }
}