public class Problem
{
    public static void Main()
    {
        Console.WriteLine("Escreve uma palavra e verifique se ela pode ser separada em pares de letras iguais:\n");
        Console.WriteLine(CanPairAllChar(Console.ReadLine()));
    }

    internal static bool CanPairAllChar(string s)
    {
        List<char> orderedWord = s.OrderBy(s => s).ToList();
        List<BufferItem> buffer = new();
        buffer.Add(new BufferItem(1, orderedWord.First()));
        int j = 0;
        for (int i = 1; i < s.Length; i++)
        {
            if (buffer[j].Caractere == orderedWord[i])
            {
                buffer[j].Quantidade++;
            }
            else
            {
                buffer.Add(new BufferItem(1, orderedWord[i]));
                j++;
            }
        }
        for (int i = 0; i < buffer.Count; i++)
        {
            if (buffer[i].Quantidade % 2 == 1)
            {
                return false;
            }
        }
        return true;
    }
}

public class BufferItem
{
    public BufferItem(int i, char s)
    {
        Quantidade = i;
        Caractere = s;
    }
    public int Quantidade { get; set; }
    public char Caractere { get; set; }
}