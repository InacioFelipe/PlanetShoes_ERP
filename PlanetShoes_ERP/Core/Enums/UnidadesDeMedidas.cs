using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlanetShoes.Core.Enums
{
    
    /// <summary>
    /// Classe que encapsula o enumerador UnidadeDeMedida e seus recursos relacionados.
    /// </summary>
    public static class UnidadesDeMedida
    {
        // Atributo personalizado para armazenar valores descritivos
        private class ValorDescritivoAttribute : Attribute
        {
            public string Valor { get; }

            public ValorDescritivoAttribute(string valor)
            {
                Valor = valor;
            }
        }

        /// <summary>
        /// Enumerador que representa as unidades de medida utilizadas no sistema.
        /// </summary>
        public enum UnidadeDeMedida
        {
            [ValorDescritivo("mm")]
            Milimetro,

            [ValorDescritivo("cm")]
            Centimetro,

            [ValorDescritivo("m")]
            Metro,

            [ValorDescritivo("kg")]
            Quilograma,

            [ValorDescritivo("L")]
            Litro,

            [ValorDescritivo("un")]
            Unidade
        }

        /// <summary>
        /// Método de extensão para recuperar o valor descritivo associado a uma unidade de medida.
        /// </summary>
        public static string GetValorDescritivo(this UnidadeDeMedida unidade)
        {
            var campo = unidade.GetType().GetField(unidade.ToString());
            var atributo = campo.GetCustomAttribute<ValorDescritivoAttribute>();
            return atributo?.Valor ?? unidade.ToString(); // Retorna o valor descritivo ou o nome do enumerador se não houver atributo
        }
    }
}
