namespace TDDTests
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
            string resultado = sut.ProcessText(texto, Operation.textEncrypter);

            //Assert 
            Assert.Equal(resultadoEsperado, resultado);
        }


        [Theory]
        [InlineData("hola que tal", "hili qii TIL")]
        [InlineData("test 123 // i %&", "tist 123 // i %&")]
        [InlineData("a a e i o", "i i I i I")]
        public void TextEncrypter_palabrasParesEnMayuscula_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.ProcessText(texto, Operation.textEncrypter);

            //Assert 
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]
        [InlineData("", "even MAKEITEVEN")]
        [InlineData("  ", "even MAKEITEVEN")]
        [InlineData("    ", "even MAKEITEVEN")]
        [InlineData(" a  ", "even a even MAKEITEVEN")]
        [InlineData("i  ", "even i even MAKEITEVEN")]
        [InlineData("  u", "even u even MAKEITEVEN")]
        [InlineData("a", "even a even MAKEITEVEN")]
        [InlineData("hola", "hola MAKEITEVEN")]

        [InlineData("tal que tall", "even tal que tall")]
        [InlineData("tall que tal", "tall que tal even")]
        [InlineData("tall que tall", "tall que tall MAKEITEVEN")]

        [InlineData("tal que que tall", "even tal que que tall MAKEITEVEN")]
        [InlineData("tall que que tal", "tall que que tal even MAKEITEVEN")]
        [InlineData("tall que hola tall", "tall que hola tall")]
        public void makeItEven_N?meroParPalabras_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.ProcessText(texto, Operation.makeItEven);

            //Assert 
            Assert.Equal(resultadoEsperado, resultado);
        }
    }

}
