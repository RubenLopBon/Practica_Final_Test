namespace TDDTests
{
    public class TDDRuben
    {
        [Theory]
        [InlineData("hola que tal", "hili qii TIL")]
        [InlineData("test 123 // i %&", "tist 123 // i %&")]
        [InlineData("a a e i o", "i i I i I")]
        public void TextEncrypter_ParesEnMayuscula_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.TextEncrypter(texto);

            //Assert 
            Assert.Equal(resultado, resultadoEsperado);
        }
    }

}
