using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private int highscore;

    private void Awake()
    {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        //AddHighscoreEntry(DisplayScore.score, "P8");

        //if (DisplayScore.score > highscore)
        //{
        //    highscore = DisplayScore.score;
        //}
        highscoreEntryList = new List<HighscoreEntry>()
            {
                new HighscoreEntry{ score = 1, name = "P1"},
                new HighscoreEntry{ score = 2, name = "P2"},
                new HighscoreEntry{ score = 3, name = "P3"},
                new HighscoreEntry{ score = 4, name = "P4"},
                new HighscoreEntry{ score = 5, name = "P5"},
                new HighscoreEntry{ score = 6, name = "P6"},
                new HighscoreEntry{ score = 7, name = "P7"}
            };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


        for (int i = 0; i < highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscoreEntryList.Count; j++)
            {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }

        //Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetString("highscoreTable"));
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformlist)
    {
        float templateHeight = 15f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformlist.Count);
        entryTransform.gameObject.SetActive(true);


        int rank = transformlist.Count + 1;
        string rankString;
        switch (rank)
        {
            default: rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        entryTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;

        DisplayScore.score = highscoreEntry.score;
        //int score = Random.Range(0, 10000);
        entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = DisplayScore.score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TMP_Text>().text = name;

        transformlist.Add(entryTransform);
    }
    //private void AddHighscoreEntry(int score, string name)
    //{
    //    //Create highscoreentry
    //    HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
    //    //Load saved highscore
    //    string jsonString = PlayerPrefs.GetString("highscoreTable");
    //    Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

    //    //Add new entry to highscores
    //    highscores.highscoreEntryList.Add(highscoreEntry);

    //    //Save updated highscores
    //    string json = JsonUtility.ToJson(highscores);
    //    PlayerPrefs.SetString("highscoreTable", json);
    //    PlayerPrefs.Save();
    //}


    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class HighscoreTable : MonoBehaviour
//{
//    private Transform entryContainer;
//    private Transform entryTemplate;
//    private List<HighscoreEntry> highscoreEntryList;
//    private List<Transform> highscoreEntryTransformList;
//    private int highscore;
//    public bool isPressed;
//    public Button resetButton;

//    private void Awake()
//    {
//        entryContainer = transform.Find("highscoreEntryContainer");
//        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

//        entryTemplate.gameObject.SetActive(false);

//        AddHighscoreEntry(10, "Player");

//        string jsonString = PlayerPrefs.GetString("highscoreTable");
//        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


//        for (int i = 0; i <highscores.highscoreEntryList.Count; i++)
//        {
//            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
//            {
//                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
//                {
//                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
//                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
//                    highscores.highscoreEntryList[j] = tmp;
//                }
//            }
//        }

//        highscoreEntryTransformList = new List<Transform>();
//        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
//        {
//            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
//        }

//    }
//    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformlist)
//    {
//        float templateHeight = 15f;
//        Transform entryTransform = Instantiate(entryTemplate, container);
//        RectTransform entryRectTransform = entryRectTransform = entryTransform.GetComponent<RectTransform>();
//        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformlist.Count);
//        entryTransform.gameObject.SetActive(true);


//        int rank = transformlist.Count + 1;
//        string rankString;
//        switch (rank)
//        {
//            default: rankString = rank + "TH"; break;
//            case 1: rankString = "1ST"; break;
//            case 2: rankString = "2ND"; break;
//            case 3: rankString = "3RD"; break;
//        }
//        entryTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;

//        DisplayScore.score = highscoreEntry.score;
//        entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = DisplayScore.score.ToString();

//        string name = highscoreEntry.name;
//        entryTransform.Find("nameText").GetComponent<TMP_Text>().text = name;

//        transformlist.Add(entryTransform);
//    }
//    public void AddHighscoreEntry(int score, string name)
//    {
//        //Create highscoreentry
//        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
//        //Load saved highscore
//        string jsonString = PlayerPrefs.GetString("highscoreTable");
//        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

//        //Add new entry to highscores
//        highscores.highscoreEntryList.Add(highscoreEntry);

//        //Save updated highscores
//        string json = JsonUtility.ToJson(highscores);
//        PlayerPrefs.SetString("highscoreTable", json);
//        PlayerPrefs.Save();
//    }

//    private class Highscores
//    {
//        public List<HighscoreEntry> highscoreEntryList;
//    }

//    [System.Serializable]
//    private class HighscoreEntry
//    {
//        public int score;
//        public string name;
//    }
//}
