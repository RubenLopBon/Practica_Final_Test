namespace TDDTests
{
    public class TDDRuben
    {
        
        [Theory]
        [InlineData("", "0")]
        [InlineData(" ", "0")]
        [InlineData("hola", "hola:4")]
        [InlineData("hola BueNos dias", "hola:4 BueNos:6 dias:4")]
        [InlineData("hola  56 tr0pa", "hola:4 56:0 tr0pa:4")]
        [InlineData("💔", "💔:0")]
        public void ContadorPorPalabra_EntradaValida_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.ProcessText(texto, Operation.ContadorPorPalabra);

            //Assert 
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData("", "a:0 e:0 i:0 o:0 u:0")]
        [InlineData(" ", "a:0 e:0 i:0 o:0 u:0")]
        [InlineData("hola", "a:1 e:0 i:0 o:1 u:0")]
        [InlineData("hOla buenös días", "a:2 e:1 i:1 o:2 u:1")]
        [InlineData("HOLA  56 tropÁ 💔", "a:2 e:0 i:0 o:2 u:0")]
        public void ContadorVocales_EntradaValida_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.ProcessText(texto, Operation.ContadorVocales);

            //Assert 
            Assert.Equal(resultado, resultadoEsperado);
        }
    }
}
