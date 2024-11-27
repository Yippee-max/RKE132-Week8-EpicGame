string folderPath = @"C:\PGRclass_data";
string heroFile = "Heroes.txt";
string villianFile = "Villians.txt";
string weaponfile = "Weapons.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
// Path.Combine combines without the need for \ at the end of folderPath
string[] villians = File.ReadAllLines(Path.Combine(folderPath, villianFile));
string[] weapons = File.ReadAllLines(Path.Combine(folderPath, weaponfile));

//string[] heroes = {"Gregory Caracal", "Frieren", "Dinostan", "John Malcolm Thorpe Fleming Churchill", "Sam Reich" };
//string[] villians = { "Yukari Yakumo", "My time managament", "Handsome Jack", "Machiavelli", "Darth Plagueis" };
//string[] weapons = { "Dardanelles Gun", "Taser", "Greek fire", "Grease gun", "Bulgarian umbrella" };
// data

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapons);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrength = heroHP;
Console.WriteLine($"Your today'th hero be'th {hero} ({heroHP} HP) with the weapon {heroWeapon}");

string villian = GetRandomValueFromArray(villians);
string villianWeapon = GetRandomValueFromArray(weapons);
int villianHP = GetCharacterHP(villian);
int villianStrikeStrength = villianHP;
Console.WriteLine($"Today, {villian} ({villianHP} HP) tries to take over the world with {villianWeapon}");

while (heroHP > 0 && villianHP > 0)
{
    heroHP = heroHP - Hit(villian, villianStrikeStrength);
    villianHP = villianHP - Hit(hero, heroStrikeStrength);
}
Console.WriteLine($"Hero {hero} HP is {heroHP}");
Console.WriteLine($"Villian {villian} HP is {villianHP}");
if (heroHP > 0)
{
    Console.WriteLine("The heroes save the day!");
}
else if (villianHP > 0)
{
    Console.WriteLine("Treacherous villiany has bested our heroes today.");
}
else
{
    Console.WriteLine("Draw!");
}


static string GetRandomValueFromArray(string[] anArray)
{
    {
        Random rnd = new Random();
        int randomIndex = rnd.Next(0, anArray.Length);
        string randomStringFromArray = anArray[randomIndex];
        return randomStringFromArray;
    }
}

static int GetCharacterHP(string charactername)
{
    if (charactername.Length < 10)
    {
        return 10;
    }
    else
    {
        return charactername.Length;
    }

}
static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed their target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.Write($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}");
    }
    return strike;
}
