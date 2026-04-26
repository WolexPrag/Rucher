using UnityEngine;
using System.Text;

public class NameGenerator
{
    private readonly char[] _consonants =
        { 'б','в','г','д','ж','з','к','л','м','н','п','р','с','т','ф','х','ч','ш' };

    private readonly char[] _vowels =
        { 'а','е','и','о','у','ы','э','ю','я' };

    public string Generate()
    {
        int syllableCount = Random.Range(2, 4);

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < syllableCount; i++)
        {
            bool startWithConsonant = Random.value > 0.3f;

            if (startWithConsonant)
                sb.Append(_consonants[Random.Range(0, _consonants.Length)]);

            sb.Append(_vowels[Random.Range(0, _vowels.Length)]);

            if (Random.value > 0.7f)
                sb.Append(_consonants[Random.Range(0, _consonants.Length)]);
        }

        string result = sb.ToString();
        return char.ToUpper(result[0]) + result.Substring(1);
    }
}
