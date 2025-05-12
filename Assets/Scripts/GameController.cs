using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public string mainWord = "default";
    public int livesCount = 10;
    public TextMeshProUGUI mainWordText;
    public TextMeshProUGUI livesCountText;
    public TextMeshProUGUI messageText;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        mainWordText.text = mainWord;
        livesCountText.text = $"You have {livesCount} chances left";
    }

    public void OnClick()
    {
        Debug.Log($"Guzik został kliknięty");
        // to znacz to samo, roznie napisane livesCount = livesCount - 1;
        // livesCount -= 1;
        livesCount--;
        livesCountText.text = $"You have {livesCount} chances left";

        if (mainWord == inputField.text)
        {
            messageText.text = $"Poprawne słowo zostało wpisane";
            return; //koniec metody
        }

        if (mainWord.Length != inputField.text.Length)
        {
            messageText.text = $"Liczba liter się nie zgadza";
            return; //koniec metody
        }

        int bullsCount = CountBulls();
        int cowsCount = CountCows();
        messageText.text = $"Bulls: {bullsCount} and Cows: {cowsCount}";
    }

    public int CountBulls()
    {
        int result = 0;

        for (int i = 0; i < mainWord.Length; i++)
        {
            if (mainWord[i] == inputField.text[i])
            {
                result++;
            }
        }

        return result;
    }

    public int CountCows()

    {
        int result = 0;

        for (int i = 0; i < mainWord.Length; i++)
        {
            if (mainWord[i] != inputField.text[i] && mainWord.Contains(inputField.text[i]))
            {
                result++;
            }
        }
        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
