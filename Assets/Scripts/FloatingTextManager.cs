using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager instance;
    public GameObject textPrefas;

    private void Awake()
    {
        instance = this;
    }
    public void Show(string text, Vector3 woridPos)
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(woridPos);

        GameObject textObj = Instantiate(textPrefas, transform);
        textObj.transform.position = screenPos;

        TextMeshProUGUI temp = textObj.GetComponent<TextMeshProUGUI>();

        if (temp != null )
        {
            temp.text = text;

            StartCoroutine(AnimteText(textObj));
        }
    }

    private IEnumerator AnimteText(GameObject textObj)
    {
        float duration = 1f;
        float timer = 0;

        Vector3 startPos = textObj.transform.position;
        TextMeshProUGUI temp = textObj.GetComponent<TextMeshProUGUI>();

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float progress = timer / duration;

            textObj.transform.position = startPos + Vector3.up * (progress * 50f);

            if (temp != null )
            {
                temp.alpha = 1 - progress;
            }
            yield return null;
        }

        Destroy(textObj);
    }
}
