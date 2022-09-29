/// <summary>
/// тип погоды
/// </summary>
[System.Flags]
enum EnumTypeWeather : byte
{
    none            = 0b0,
    Sunny           = 0b00000001, // солнечно
    Cloudy          = 0b00000010, // облачно
    Rainy           = 0b00000100, // дождливо
    Snowy           = 0b00001000, // снежно
    Thunderstorms   = 0b00010000, // грозы
    Tornadoes       = 0b00100000, // торнадо
    Hurricanes      = 0b01000000, // Ураганы
    WinterStorms    = 0b10000000, // Зимние бури
    Blizzards       = 0b00000011, // Метели
    Droughts        = 0b00000110, // Засухи
    windy           = 0b00001100  // ветренно
}


