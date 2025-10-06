// Провокирани от сватбата си, Михаела и Иван решават да предоставят нова услуга на клиенти на ресторанта си, а именно вечеря за запознанства - "Предизвикай Сватбата".
// Напишете програма, която отпечатва всички възможни срещи на клиентите на ресторанта. При настаняване всеки мъж и всяка жена получават талончета с поредни номера стартирайки от 1.
// Ако бъдат заети всички маси, програмата трябва да приключи. Всяка маса има две места.
int men = int.Parse(Console.ReadLine());
int women = int.Parse(Console.ReadLine());
int maxTables = int.Parse(Console.ReadLine());

int tables = 0;
for (int man = 1; man <= men; man++)
{
    for (int woman = 1; woman <= women; woman++)
    {
        tables++;
        Console.Write($"({man} <-> {woman}) ");

        if (tables == maxTables)
            return;
    }
}