using UnityEngine;
using TMPro;
using System.Collections;
public class FloatingText : MonoBehaviour
{
    public TextMeshProUGUI damageText;

    public void SetText(string text)
    {
        damageText.text = text;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        float duration = 1f;
        float speed = 1f;
        Vector3 offset = new Vector3(0, 30f, 0);
        RectTransform rect = GetComponent<RectTransform>();
        Color startColor = damageText.color;

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            rect.anchoredPosition += (Vector2)(offset * Time.deltaTime);
            damageText.color = Color.Lerp(startColor, Color.clear, t / duration);
            yield return null;
        }

        Destroy(gameObject);
    }
}