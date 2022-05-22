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
            string resultado = sut.EliminarBlancos(texto);

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
            var exception = Assert.Throws<Exception>(() => sut.EliminarBlancos(texto));

            // ASSERT
            Assert.Equal("Conjunto de palabras incorrecto", exception.Message);
        }

        //[Theory]
        //[InlineData("MN", "M N")]                                       // Caso: Dos mayúsculas seguidas
        //[InlineData("Mn", "nM")]                                        // Caso: Primera mayúscula
        //[InlineData("mN", "m N")]                                       // Caso: Segunda mayúscula
        //[InlineData("mn", "nm")]                                        // Caso: Ninguna mayúscula
        //[InlineData("mn bv", "vbnm")]                                   // Caso: Ninguna mayúscula --> Contiene espacios

        //[InlineData("MiNombreEsLaura", "iM erbmoN sE aruaL")]           // Caso: Palabras --> Sin espacios
        //[InlineData("Mi Nombre Es Laura", "iM erbmoN sE aruaL")]        // Caso: Palabras --> Con espacios
        //[InlineData("Mi  Nombre    Es Laura", "iM erbmoN sE aruaL")]    // Caso: Palabras --> Con espacios de más
        //[InlineData("Mi nombre Es laura", "erbmoniM arualsE")]          // Caso: Palabras --> Con espacios, no todas empiezan mayúsculas

        //[InlineData(" Mi nombre es Laura", "MiNombreEsLaura")]          // Caso: No está vacío --> Empieza por espacio
        //[InlineData("   Mi nombre es Laura", "MiNombreEsLaura")]        // Caso: No está vacío --> Empieza por más de un espacio
        //public void InvertirPalabras_PalabrasInversasPorMayusculas_Success(string texto, string resultadoEsperado)
        //{
        //    // ARRANGE 
        //    var sut = new TextProcessor();

        //    // ACT
        //    string resultado = sut.InvertirPalabras(texto);

        //    // ASSERT
        //    Assert.Equal(resultado, resultadoEsperado);
        //}

        //[Theory]
        //[InlineData("")]                                        // Caso: Está vacío
        //[InlineData(" ")]                                       // Caso: Está vacío --> Empieza por espacio
        //[InlineData("   ")]                                     // Caso: Está vacío --> Empieza por espacios de más

        //[InlineData("??")]                                      // Caso: Carácter diferente al alfabeto
        //[InlineData("Mi n0mbr3 es Laura")]                      // Caso: Carácter diferente al alfabeto --> Entre el texto
        //[InlineData("Mi nombre es Laura.")]                     // Caso: Carácter diferente al alfabeto --> Al final del texto
        //public void InvertirPalabras_ExceptionSinPalabrasCarácteresInválidos_Success(string texto)
        //{
        //    // ARRANGE
        //    var sut = new TextProcessor();

        //    // ACT
        //    var exception = Assert.Throws<Exception>(() => sut.InvertirPalabras(texto));

        //    // ASSERT
        //    Assert.Equal("Conjunto de palabras incorrecto", exception.Message);
        //}
    }
}
