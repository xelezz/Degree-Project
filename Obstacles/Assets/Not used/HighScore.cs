using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;

    private void Awake()
    {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 20f;
        for (int i = 0; i < 10; i++)
        {
            Transform entryTranfsform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTranfsform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            entryTranfsform.gameObject.SetActive(true);
        
            int rank = i + 1;
            string rankString;
            switch(rank)
            {
                default:
                    rankString = rank + "TH"; break;

                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;
            }
            entryTranfsform.Find("posText").GetComponent<Text>().text = rankString;

            DisplayScore.score = Random.Range(0, 000000);

            entryTranfsform.Find("scoreText").GetComponent<Text>().text = DisplayScore.score.ToString();

            string name = "AAA";
            entryTranfsform.Find("nameText").GetComponent<Text>().text = name;
        }

    }
}
