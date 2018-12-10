using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButton : MonoBehaviour {

    float timeOfTravel = 0.1f;
    float currentTime = 0;
    float normalizedValue;

    // Update is called once per frame

    void Start()
    {
        
        // rectTransform = GetComponent<RectTransform>();
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
              StartCoroutine(LerpObjectOut());
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            StartCoroutine(LerpObjectIn());
        }
    }
    
IEnumerator LerpObjectOut()
            {

                while (currentTime <= timeOfTravel)
                {
                    currentTime += Time.deltaTime;
                    normalizedValue = currentTime / timeOfTravel; // we normalize our time 

                    Vector3 endPosition = new Vector3(GetComponent<RectTransform>().anchoredPosition.x - 1, GetComponent<RectTransform>().anchoredPosition.y, 0);
            GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(GetComponent<RectTransform>().anchoredPosition, endPosition, normalizedValue);
                    yield return null;
                }
            }
    IEnumerator LerpObjectIn()
    {

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            Vector2 endPosition = new Vector2(GetComponent<RectTransform>().anchoredPosition.x + 1, GetComponent<RectTransform>().anchoredPosition.y);
            GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(GetComponent<RectTransform>().anchoredPosition, endPosition, normalizedValue);
            yield return null;
        }
    }

}
