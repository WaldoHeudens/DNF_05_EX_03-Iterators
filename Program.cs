// Elke collectie die je met foreach kan doorlopen, implementeert
// IEnumerable<T>. Je kan zulke reeksen ook zelf maken met "yield return",
// zonder eerst een volledige lijst in het geheugen op te bouwen.

// ---- foreach over een gewone collectie ----
List<int> getallen = [10, 20, 30];
foreach (int g in getallen)
{
    Console.Write($"{g} ");
}
Console.WriteLine();

// ---- Een eigen iterator met yield return ----
// Bereik levert de getallen van..tot een voor een. De method "onthoudt"
// waar ze gebleven was: bij elke stap in de foreach draait ze door tot de
// volgende yield return.
foreach (int i in Bereik(1, 5))
{
    Console.Write($"{i} ");                 // 1 2 3 4 5
}
Console.WriteLine();

// ---- Iterators zijn lui (lazy) ----
// Kwadraten rekent pas een waarde uit op het moment dat foreach ze
// opvraagt. Een oneindige reeks is daardoor geen probleem, zolang je maar
// stopt met opvragen. Hier stoppen we zelf na vijf waarden.
int geteld = 0;
foreach (long kwadraat in Kwadraten())
{
    Console.Write($"{kwadraat} ");          // 1 4 9 16 25
    geteld++;
    if (geteld == 5)
    {
        break;
    }
}
Console.WriteLine();

// Levert de gehele getallen van 'van' tot en met 'tot'.
static IEnumerable<int> Bereik(int van, int tot)
{
    for (int i = van; i <= tot; i++)
    {
        yield return i;
    }
}

// Een oneindige reeks: 1, 4, 9, 16, ... De reeks stopt nooit vanzelf,
// maar levert alleen een waarde wanneer erom gevraagd wordt.
static IEnumerable<long> Kwadraten()
{
    long n = 1;
    while (true)
    {
        yield return n * n;
        n++;
    }
}
