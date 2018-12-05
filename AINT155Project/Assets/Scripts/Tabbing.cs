using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tabbing : MonoBehaviour {
	float timeOfTravel = 5;
            float currentTime = 0;
            float normalizedValue;
        
    // Update is called once per frame

        void Start ()
    {
        RectTranform rectTransform = GetComponent<RectTransform>();
        // rectTransform = GetComponent<RectTransform>();
    }
    void Update () {
		if (Input.GetKeyDown(KeyCode.Tab)){
          //  StartCoroutine(LerpObjectOut());
        }
        if (Input.GetKeyUp(KeyCode.Tab)) {
       //     float t = Time.deltaTime / 0.2f;
       //     KBg.anchoredPosition = gameObject.GetComponent<RectTransform>().position;
      //      Vector3 target = new Vector3(KBg.position.x - 150, KBg.position.x, KBg.position.z);
       //     KBg.transform.position = Vector3.Lerp(KBg.position, target, t);
        }
	}
    /*
IEnumerator LerpObjectOut()
            {

                while (currentTime <= timeOfTravel)
                {
                    currentTime += Time.deltaTime;
                    normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            Vector2 endPosition = new Vector2(rectTransform.anchoredPosition.x + 150, rectTransform.anchoredPosition.y);
                    rectTransform.anchoredPosition = Vector3.Lerp(gameObject.anchoredPosition, endPosition, normalizedValue);
                    yield return null;
                }
            }

    */
    public void ShowScores()
    {
     //   float t = Time.deltaTime / 0.2f;
   //     Vector3 target = new Vector3(KBg.transform.position.x + 150, KBg.transform.position.x, KBg.transform.position.z);
   //     KBg.transform.position = Vector3.Lerp(KBg.transform.position, target, t);
        
    }

    public void HideScores()
    {
   //     float t = Time.deltaTime / 0.2f;
   //     Vector3 target = new Vector3(KBg.position.x - 150, KBg.position.x, KBg.position.z);
    //    KBg.transform.position = Vector3.Lerp(KBg.position, target, t);
    }
}
