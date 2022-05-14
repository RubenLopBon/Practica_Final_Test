


namespace TDDtests
{
    public class TDDMarc
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("  ", "")]
        [InlineData(" a  ", "i")]
        [InlineData("i  ", "i")]
        [InlineData("  u", "i")]
        [InlineData("a", "i")]
        [InlineData("e", "i")]
        [InlineData("i", "i")]
        [InlineData("o", "i")]
        [InlineData("u", "i")]
        [InlineData("ahola", "ihili")]
        [InlineData("hola", "hili")]
        public void TextEncrypter_CambiarVocalesPorIs_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.TextEncrypter(texto);

            //Assert 
            Assert.Equal(resultado, resultadoEsperado);
        }
      

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
