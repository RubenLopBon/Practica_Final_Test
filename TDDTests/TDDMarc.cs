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
            string resultado = sut.TextEncrypter(texto);

            //Assert 
            Assert.Equal(resultadoEsperado, resultado);
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
            Assert.Equal(resultadoEsperado, resultado);
        }

        [Theory]

        [InlineData("hola que tal", "hola que tal even")]
        [InlineData("tal que hola", "even tal que hola")]
        public void makeItEven_EmpiezaYAcabaEnPar_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.makeItEven(texto);

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
        [InlineData("hola que tal", "hola que tal even")]
        [InlineData("tal que hola", "even tal que hola")]
        public void makeItEven_NúmeroParPalabras_Success(string texto, string resultadoEsperado)
        {
            //Arrange 
            var sut = new TextProcessor();

            //Act 
            string resultado = sut.makeItEven(texto);

            //Assert 
            Assert.Equal(resultadoEsperado, resultado);
        }
    }

}
