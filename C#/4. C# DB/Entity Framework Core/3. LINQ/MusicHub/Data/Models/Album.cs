namespace MusicHub.Data.Models;

public class Album
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }

    /* Калкулирано пропърти, което е в клиентската част - не е част от таблицата Album в базата. Минус е, че всички песни трябва да бъдат извлечени по време на извличането на албумите. Ако
       навигационната колекция съдържа много обекти, тогава бизнес логика в клиента по време на добавяне може да си грижи за този use-case */
    public decimal Price => Songs.Sum(s => s.Price);

    public int? ProducerId { get; set; }

    public virtual Producer? Producer { get; set; }

    public virtual ICollection<Song> Songs { get; set; } = new HashSet<Song>();
}
