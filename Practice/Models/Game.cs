using System.ComponentModel.DataAnnotations.Schema;

[Table("Game")]  // Указываем, что эта модель связана с таблицей Game
public class Game
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageURL { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
}
