using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NameGenerator : MonoBehaviour
{

    public static NameGenerator self;

    public int amountToGenerate;

    public Sprite[] flags;

    public string[] stems;
    public string[] suffixes;
    public string[] prefixes;


    List<string> availableStems = new List<string>();
    List<string> availableSuffixes = new List<string>();
    List<string> availablePrefixes = new List<string>();

    public List<string> names = new List<string>();
    public List<string> generatedNames;
    public List<Sprite> countryFlags;

    int flagIndex;

    private void Awake()
    {
        self = this;

        availableStems = stems.ToList();
        availableSuffixes = suffixes.ToList();
        availablePrefixes = prefixes.ToList();

        GenerateNames();
        names = generatedNames;
    }

    public void OnGameStart()
    {
        
    }

    public void GenerateNames()
    {
        names.Clear();
        countryFlags.Clear();
        generatedNames.Clear();

        for (int i = 0; i < amountToGenerate; i++)
        {
            string nameToAdd = "";

            while (nameToAdd == "")
            {
                nameToAdd = CreateName();
            }




            countryFlags.Add(flags[Random.Range(0, flags.Length)]);
            generatedNames.Add(nameToAdd);

        }
    }

    string CreateName()
    {
        string prefix = "";
        string stem = availableStems[Random.Range(0, availableStems.Count)];
        string suffix = "";

        int chanceForPrefix = Random.Range(0, 100);
        int chanceForSuffix = Random.Range(0, 100);

        if (chanceForPrefix <= 50)
        {
            prefix = availablePrefixes[Random.Range(0, availablePrefixes.Count)];
        }

        if (chanceForSuffix <= 50)
        {
            suffix = availableSuffixes[Random.Range(0, availableSuffixes.Count)];
        }

        string createdName = prefix + stem + suffix;
        createdName = char.ToUpper(createdName[0]) + createdName.Substring(1, createdName.Length - 1);

        if (!generatedNames.Contains(createdName) && createdName.Length <= 14)
        {
            if (availablePrefixes.Contains(prefix))
            {
                availablePrefixes.Remove(prefix);
            }

            if (availableStems.Contains(stem))
            {
                availableStems.Remove(stem);
            }

            if (availableSuffixes.Contains(suffix))
            {
                availableSuffixes.Remove(suffix);
            }

            return createdName;
        }
        else
        {
            return "";
        }

    }



    public string GetRandomName()
    {
        int index = Random.Range(0, names.Count);
        flagIndex = index;
        string retVal = names[index];
        names.Remove(names[index]);
        return retVal;
    }


    public Sprite GetRandomFlag()
    {
        Sprite retVal = countryFlags[flagIndex];
        countryFlags.Remove(countryFlags[flagIndex]);
        return retVal;
    }


}
