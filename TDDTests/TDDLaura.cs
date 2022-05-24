namespace TDDTests
{
    public class TDDLaura
    {
        [Theory]
        [InlineData("m", "M")]
        [InlineData("M", "M")]

        [InlineData("Mi nombre es Laura", "MiNombreEsLaura")]
        [InlineData("Mi  nombre   es Laura", "MiNombreEsLaura")]
        [InlineData("mI nOmbrE Es lAUrA", "MiNombreEsLaura")]
        [InlineData(" Mi nombre es Laura", "MiNombreEsLaura")]
        [InlineData("   Mi nombre es Laura", "MiNombreEsLaura")]
        public void EliminarBlancos_PrimeraLetraMayusculaSinBlancos_Success(string texto, string resultadoEsperado)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            string resultado = sut.ProcessText(texto, Operation.EliminarBlancos);

            // ASSERT
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]

        [InlineData("??")]
        [InlineData("Mi n0mbr3 es Laura")]
        [InlineData("Mi nombre es Laura.")]
        public void EliminarBlancos_ExceptionSinPalabrasCarácteresInválidos_Success(string texto)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            var exception = Assert.Throws<Exception>(() => sut.ProcessText(texto, Operation.EliminarBlancos));

            // ASSERT
            Assert.Equal("Conjunto de palabras incorrecto", exception.Message);
        }

        [Theory]
        [InlineData("MN", "M N")]
        [InlineData("Mn", "nM")]
        [InlineData("mN", "m N")]
        [InlineData("mn", "nm")]
        [InlineData("mn bv", "vbnm")]

        [InlineData("MiNombreEsLaura", "iM erbmoN sE aruaL")]
        [InlineData("Mi Nombre Es Laura", "iM erbmoN sE aruaL")]
        [InlineData("Mi  Nombre    Es Laura", "iM erbmoN sE aruaL")]
        [InlineData("Mi nombre Es laura", "erbmoniM arualsE")]
        [InlineData(" Mi nombre es Laura", "seerbmoniM aruaL")]
        [InlineData("   Mi nombre es Laura", "seerbmoniM aruaL")]
        public void InvertirPalabras_PalabrasInversasPorMayusculas_Success(string texto, string resultadoEsperado)
        {
            // ARRANGE 
            var sut = new TextProcessor();

            // ACT
            string resultado = sut.ProcessText(texto, Operation.InvertirPalabras);

            // ASSERT
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]

        [InlineData("??")]
        [InlineData("Mi n0mbr3 es Laura")]
        [InlineData("Mi nombre es Laura.")]
        public void InvertirPalabras_ExceptionSinPalabrasCarácteresInválidos_Success(string texto)
        {
            // ARRANGE
            var sut = new TextProcessor();

            // ACT
            var exception = Assert.Throws<Exception>(() => sut.ProcessText(texto, Operation.InvertirPalabras));

            // ASSERT
            Assert.Equal("Conjunto de palabras incorrecto", exception.Message);
        }
    }
}
