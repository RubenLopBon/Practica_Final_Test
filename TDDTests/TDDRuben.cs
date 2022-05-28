namespace TDDTests
{
    public class TDDRuben
    {
        /*
        [Theory]
        [InlineData("","")]
        [InlineData(" ", " ")]
        [InlineData("hola", "hilaaloh")]
        [InlineData("hola buenos dias", "holaaloh buenossoneub diassaid")]
        [InlineData("hola", "hilaaloh")]
        public void TextEncrypter_ParesEnMayuscula_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.ProcessText(texto, Operation.Palindromizador);

            //Assert 
            Assert.Equal(resultado, resultadoEsperado);
        }
        */

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData("hola", "hola:4")]
        [InlineData("hola BueNos dias", "hola:4 BueNos:6 dias:4")]
        [InlineData("hola  56 tr0pa 💔", "hola:4 56:0 tr0pa:5 💔:0")]
        public void ContadorPorPalabra_EntradaValida_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.ProcessText(texto, Operation.ContadorPorPalabra);

            //Assert 
            Assert.Equal(resultado, resultadoEsperado);
        }
    }

}
