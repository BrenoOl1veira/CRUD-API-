using System.Text.Json.Serialization;

namespace API.Enums;

/// <summary>
/// Enumeração representando os turnos de trabalho.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TurnoEnum
{
    /// <summary>
    /// Turno da manhã.
    /// </summary>
    Manha,

    /// <summary>
    /// Turno da tarde.
    /// </summary>
    Tarde,

    /// <summary>
    /// Turno da noite.
    /// </summary>
    Noite
}
