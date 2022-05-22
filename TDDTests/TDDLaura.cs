namespace TDDTests
{
    public class TDDLaura
    {
        [Theory]
        [InlineData("m", "M")]                                  // Caso: Minúscula por mayúscula
        [InlineData("M", "M")]                                  // Caso: Mayúscula se queda igual

        [InlineData("Mi nombre es Laura", "MiNombreEsLaura")]   // Caso: Frase sin espacios, primera letra mayúscula
        [InlineData("Mi  nombre   es Laura", "MiNombreEsLaura")]// Caso: Frase sin espacios, primera letra mayúscula --> Espacios de más
        [InlineData("mI nOmbrE Es lAUrA", "MiNombreEsLaura")]   // Caso: Frase sin espacios, primera letra mayúscula --> Mayúsculas de más

        [InlineData(" Mi nombre es Laura", "MiNombreEsLaura")]  // Caso: No está vacío --> Empieza por espacio
        [InlineData("   Mi nombre es Laura", "MiNombreEsLaura")]// Caso: No está vacío --> Empieza por más de un espacio
        public void EliminarBlancos_PrimeraLetraMayusculaSinBlancos_Success(string texto, string resultadoEsperado)
        {
            // Arrange 
            var sut = new TextProcessor();

            // Act 
            string resultado = sut.EliminarBlancos(texto);

            // Assert 
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData("")]                                        // Caso: Está vacío
        [InlineData(" ")]                                       // Caso: Está vacío --> Empieza por espacio
        [InlineData("   ")]                                     // Caso: Está vacío --> Empieza por espacios de más

        [InlineData("??")]                                      // Caso: Carácter diferente al alfabeto
        [InlineData("Mi n0mbr3 es Laura")]                      // Caso: Carácter diferente al alfabeto --> Entre el texto
        [InlineData("Mi nombre es Laura.")]                     // Caso: Carácter diferente al alfabeto --> Al final del texto
        public void EliminarBlancos_ExceptionSinPalabrasCarácteresInválidos_Success(string texto)
        {
            // Arrange 
            var sut = new TextProcessor();

            // Act
            var exception = Assert.Throws<Exception>(() => sut.EliminarBlancos(texto));

            // Assert
            Assert.Equal("Conjunto de palabras incorrecto", exception.Message);
        }

        [Theory]
        [InlineData("MN", "M N")]                                       // Caso: Dos mayúsculas seguidas
        [InlineData("Mn", "nM")]                                        // Caso: Primera mayúscula
        [InlineData("mN", "m N")]                                       // Caso: Segunda mayúscula
        [InlineData("mn", "nm")]                                        // Caso: Ninguna mayúscula
        [InlineData("mn mn", "nmnm")]                                   // Caso: Ninguna mayúscula --> Contiene espacios

        [InlineData("MiNombreEsLaura", "iM erbmoN sE aruaL")]           // Caso: Palabras --> Sin espacios
        [InlineData("Mi Nombre Es Laura", "iM erbmoN sE aruaL")]        // Caso: Palabras --> Con espacios
        [InlineData("Mi  Nombre    Es Laura", "iM erbmoN sE aruaL")]    // Caso: Palabras --> Con espacios de más
        [InlineData("Mi nombre Es laura", "erbmoniM arualsE")]          // Caso: Palabras --> Con espacios, no todas empiezan mayúsculas

        [InlineData(" Mi nombre es Laura", "MiNombreEsLaura")]          // Caso: No está vacío --> Empieza por espacio
        [InlineData("   Mi nombre es Laura", "MiNombreEsLaura")]        // Caso: No está vacío --> Empieza por más de un espacio
        public void InvertirPalabras_PalabrasInversasPorMayusculas_Success(string texto, string resultadoEsperado)
        {
            // Arrange 
            var sut = new TextProcessor();

            // Act 
            string resultado = sut.InvertirPalabras(texto);

            // Assert 
            Assert.Equal(resultado, resultadoEsperado);
        }

        [Theory]
        [InlineData("")]                                        // Caso: Está vacío
        [InlineData(" ")]                                       // Caso: Está vacío --> Empieza por espacio
        [InlineData("   ")]                                     // Caso: Está vacío --> Empieza por espacios de más

        [InlineData("??")]                                      // Caso: Carácter diferente al alfabeto
        [InlineData("Mi n0mbr3 es Laura")]                      // Caso: Carácter diferente al alfabeto --> Entre el texto
        [InlineData("Mi nombre es Laura.")]                     // Caso: Carácter diferente al alfabeto --> Al final del texto
        public void InvertirPalabras_ExceptionSinPalabrasCarácteresInválidos_Success(string texto)
        {
            // Arrange 
            var sut = new TextProcessor();

            // Act
            var exception = Assert.Throws<Exception>(() => sut.InvertirPalabras(texto));

            // Assert
            Assert.Equal("Conjunto de palabras incorrecto", exception.Message);
        }
    }
}
