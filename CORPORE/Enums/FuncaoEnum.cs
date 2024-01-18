using System.Text.Json.Serialization;

namespace API.Enums
{
    /// <summary>
    /// Enumeração representando as funções dos operadores.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FuncaoEnum
    {
        /// <summary>
        /// Operador de linha 1.
        /// </summary>
        Operador_De_Linha1,

        /// <summary>
        /// Operador de linha 2.
        /// </summary>
        Operador_De_Linha2,

        /// <summary>
        /// Operador de linha 3.
        /// </summary>
        Operador_De_Linha3
    }
}
