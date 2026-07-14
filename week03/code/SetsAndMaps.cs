using System.Text.Json;
using System.Collections.Generic;
using System.IO;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seenWords = new HashSet<string>();
        var result = new List<string>();

        foreach (var word in words)
        {
            // Cria a versão invertida da palavra atual
            string reversed = $"{word[1]}{word[0]}";

            // Verifica se a palavra invertida já foi vista e não é um palíndromo (ex: 'aa')
            if (word != reversed && seenWords.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }

            // Adiciona a palavra atual ao set de palavras já vistas
            seenWords.Add(word);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            
            // Garante que a linha tem colunas suficientes antes de acessar a 4ª coluna (índice 3)
            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();
                
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Remove os espaços e converte para minúsculas
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
        {
            return false;
        }

        var letterCounts = new Dictionary<char, int>();

        // Conta a frequência de cada letra da palavra 1
        foreach (char c in word1)
        {
            if (letterCounts.ContainsKey(c))
                letterCounts[c]++;
            else
                letterCounts[c] = 1;
        }

        // Subtrai a frequência usando a palavra 2
        foreach (char c in word2)
        {
            if (!letterCounts.ContainsKey(c) || letterCounts[c] == 0)
            {
                return false;
            }
            letterCounts[c]--;
        }

        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the USGS.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summary = new List<string>();

        // Preenche a lista com os dados no formato: "Lugar - Mag Magnitude"
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                summary.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }

        return summary.ToArray();
    }
}