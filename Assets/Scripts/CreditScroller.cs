using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Required for UI elements like Image

public class CreditScroller : MonoBehaviour
{
    public float scrollSpeed = 20f;        // Speed of scrolling
    public RectTransform creditPanel;     // Reference to the panel with credits
    public float endPositionY = -300f;     // Final Y position where it should stop
    public Image image;                    // Assign your Image in the Inspector
    public float fadeDuration = 1.5f;      // Time to fully fade out

    private bool isFading = false;

    void Start()
    {
        if (image == null)
            image = GetComponent<Image>(); // Get Image component if not assigned

        StartCoroutine(ScrollAndFade());
    }

    IEnumerator ScrollAndFade()
    {
        float elapsedTime = 0f;
        Color startColor = image.color;
        float startAlpha = startColor.a;

        while (creditPanel.anchoredPosition.y < endPositionY || elapsedTime < fadeDuration)
        {
            // Scroll credits upwards
            if (creditPanel.anchoredPosition.y < endPositionY)
            {
                creditPanel.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
            }

            // Start fading out simultaneously
            if (!isFading)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, 0, elapsedTime / fadeDuration);
                image.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            }

            yield return null;
        }

        // Ensure full transparency & disable GameObject
        image.color = new Color(startColor.r, startColor.g, startColor.b, 0);
        gameObject.SetActive(false);
    }

    public void GoToHome()
    {
        SceneManager.LoadScene("HomeScene"); // Replace with your actual home scene name
    }
}
