/// <summary>
/// Типы погоды
/// </summary>

[System.Flags] 
enum  WeatherType
{
    none        = 0,
    Sunny       = 1, // солнечная
    Hot         = 2, // Жаркая
    Еemperate   = 3, // Умеренная
    Cold        = 4, // Холодная
    Cloudy      = 5, // Облачная
    Runny       = 6, // Дождливая
    Dry         = 7, // Сухая
    Windy       = 8  // Ветреная
}

