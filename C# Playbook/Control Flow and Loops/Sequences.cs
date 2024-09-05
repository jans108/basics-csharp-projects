namespace FolderTreeDemo;

public static class Sequences
{
    public static void DisplaySequence_ForEach(IEnumerable<string> strings)
    {
        foreach (var s in strings)
        {
            Console.WriteLine(s);
        }
    }

    public static void DisplaySequence_ForEach(IReadOnlyList<string> strings)
    {
        foreach (var s in strings)
        {
            Console.WriteLine(s);
        }
    }

    public static void DisplaySequence_For(IReadOnlyList<string> strings)
    {
        for (int i = 0; i < strings.Count; i++)
        {
            Console.WriteLine(strings[i]);
        }
    }

    public static void DisplayFirstN_ForEach(IReadOnlyList<string> strings, int maxToDisplay)
    {
        foreach (var s in strings.Take(maxToDisplay))
        {
            Console.WriteLine(s);
        }
    }

    public static void DisplayFirstN_For(IReadOnlyList<string> strings, int maxToDisplay)
    {
        for (int i = 0; i < strings.Count && i < maxToDisplay; i++)
            Console.WriteLine(strings[i]);
    }

    public static void DisplayListWithIndex_For(IReadOnlyList<string> strings)
    {
        for (int i = 0; i < strings.Count; i++)
            Console.WriteLine($"{i + 1}: {strings[i]}");
    }

    public static void DisplayListWithIndex_ForEach(IReadOnlyList<string> strings)
    {
        int i = 1;
        foreach (var s in strings)
            Console.WriteLine($"{i++}: {s}");
    }

}
