// Напишете програма, която извежда на конзолата номерата на стаите в една сграда (в низходящ ред), като са изпълнени следните условия:
// •   На всеки четен етаж има само офиси
// •   На всеки нечетен етаж има само апартаменти
// •   Всеки апартамент се означава по следния начин : А{номер на етажа}{ номер на апартамента}, номерата на апартаментите започват от 0.
// •   Всеки офис се означава по следния начин : О{номер на етажа}{ номер на офиса}, номерата на офисите също започват от 0.
// •   На последният етаж винаги има апартаменти и те са по-големи от останалите, за това пред номера им пише 'L', вместо 'А'. Ако има само един етаж, то има само големи апартаменти!
int floors = int.Parse(Console.ReadLine());
int rooms = int.Parse(Console.ReadLine());

for (int floorNumber = floors; floorNumber > 0; floorNumber--)
{
    string roomType;
    if (floorNumber == floors)
        roomType = "L";
    else if (floorNumber % 2 == 0)
        roomType = "O";
    else
        roomType = "A";

    for (int roomNumber = 0; roomNumber < rooms; roomNumber++)
    {
        if (roomNumber > 0)
            Console.Write(" ");
        Console.Write($"{roomType}{floorNumber}{roomNumber}");
    }
    Console.WriteLine();
}