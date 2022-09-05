using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : Singleton<ImageManager>
{
    Dictionary<string, Dictionary<float, Dictionary<ImageType, string>>> idAndLevelToTankImage;

    public enum ImageType
    {
        TankIcon,
        TankIconCircle,
        TankBackground,
        TankDetail,
        TankEndMatch,
        Skill1,
        Skill2,
        Skill3
    }

    // Start is called before the first frame update
    void Start()
    {
        idAndLevelToTankImage = new Dictionary<string, Dictionary<float, Dictionary<ImageType, string>>>();

        string[] listType = { "001", "002", "003" };
        float[] listLevel = { 1, 2, 3 };

        foreach (string tankType in listType)
        {
            Dictionary<float, Dictionary<ImageType, string>> wrapDictionary = new Dictionary<float, Dictionary<ImageType, string>>();
            foreach (float level in listLevel)
            {
                Dictionary<ImageType, string> childDictionary = new Dictionary<ImageType, string>();
                childDictionary.Add(ImageType.TankBackground, $"Images/{tankType}/level{level}-background");
                childDictionary.Add(ImageType.TankEndMatch, $"Images/{tankType}/level{level}-endmatch");
                childDictionary.Add(ImageType.TankIcon, $"Images/{tankType}/level{level}-icon");
                childDictionary.Add(ImageType.TankIconCircle, $"Images/{tankType}/level{level}-icon-circle");
                childDictionary.Add(ImageType.TankDetail, $"Images/{tankType}/level{level}-detail");
                childDictionary.Add(ImageType.Skill1, $"Images/{tankType}/skill1-icon");
                childDictionary.Add(ImageType.Skill2, $"Images/{tankType}/skill2-icon");
                childDictionary.Add(ImageType.Skill3, $"Images/{tankType}/skill3-icon");

                wrapDictionary.Add(level, childDictionary);
            }
            idAndLevelToTankImage.Add(tankType, wrapDictionary);
        }

    }

    public Sprite GetImage(string tankType, float level, ImageType imgType)
    {
        return Resources.Load<Sprite>(idAndLevelToTankImage[tankType][level][imgType]);

    }

    public Sprite GetRankImage(int star)
    {
        string rankName = GetRankName(star);
        return Resources.Load<Sprite>($"Images/RankImage/{rankName}");
    }

    public Sprite GetStarImage(int star)
    {
        int starNum = star % 5 == 0 ? 5 : star % 5;
        //return star % 100;
        return Resources.Load<Sprite>($"Images/RankImage/{starNum}-star");
    }

    public string GetRankName(int star)
    {
        if (star > 100) return "MASTER";
        string[] ranks = { "BRONZE", "SILVER", "GOLD", "PLATINUM", "DIAMOND", "MASTER" };
        string rankName = ranks[(star - 1) / 20];
        string[] rankIndexes = { "", "I", "II", "III", "IV" };
        string rankIndex = rankIndexes[4 - ((star - 1) % 20) / 5];
        return rankName + " " + rankIndex;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
