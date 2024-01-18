using System.Text.Json.Serialization;

namespace API.Enums
{
    /// <summary>
    /// Enumeração representando as máquinas disponíveis.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MaquinaEnum
    {
        /// <summary>
        /// Máquina de gaxeta 1.
        /// </summary>
        Maquina_De_Gaxeta_1,

        /// <summary>
        /// Máquina de gaxeta 2.
        /// </summary>
        Maquina_De_Gaxeta_2,

        /// <summary>
        /// Máquina de gaxeta 3.
        /// </summary>
        Maquina_De_Gaxeta_3,

        /// <summary>
        /// Máquina de gaxeta 4.
        /// </summary>
        Maquina_De_Gaxeta_4,

        /// <summary>
        /// Máquina de gaxeta 5.
        /// </summary>
        Maquina_De_Gaxeta_5,

        /// <summary>
        /// Máquina de gaxeta 6.
        /// </summary>
        Maquina_De_Gaxeta_6
    }
}
