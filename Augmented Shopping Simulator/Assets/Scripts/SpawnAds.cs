using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAds : MonoBehaviour {

    [SerializeField]
    private GameObject[] adArray;

    [SerializeField]
    private GameObject Canvas;

    private int numAds;
    private float screenWidth;
    private float screenHeight;

    private float timer = 0;
    private float maxTime = 5f;

	// Use this for initialization
	void Start () {
        numAds = adArray.Length;

        screenWidth = Screen.width;
        screenHeight = Screen.height;

        Debug.Log("Screen width and height" + screenWidth + " " + screenHeight);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timer >= maxTime)
        {
            timer = 0;
            //SpawnAdAnywhere();
            SpawnAdOuter();
        }

        timer += Time.deltaTime;
	}

    private void SpawnAdOuter()
    {
        // get a random ad
        int randIndex = Random.Range(0, numAds);
        GameObject ad = adArray[randIndex];

        // get random placement
        // made sure the placement is fully within the screen
        bool goodPlacement = false;
        float adWidth = Mathf.Abs(ad.GetComponent<RectTransform>().rect.x);
        float adHeight = Mathf.Abs(ad.GetComponent<RectTransform>().rect.y);

        float randWidth = 0, randHeight = 0;
        while (!goodPlacement)
        {
            randWidth = Random.Range(-screenWidth + adWidth, screenWidth - adWidth);
            randHeight = Random.Range(-screenHeight + adHeight, screenHeight - adHeight);

            // -/+ 2 so the image doesnt go off screen
            if (randWidth + adWidth > screenWidth / 2  && randWidth + adWidth < screenWidth - 2 ||
                randWidth - adWidth > -screenWidth + 2 && randWidth - adWidth < -screenWidth / 2)
            {
                goodPlacement = true;

                Debug.Log("randWidth: " + randWidth + " adwidth: " + adWidth + " together: " + (randWidth + adWidth) + " < " + screenWidth);
                Debug.Log("randHeight: " + randHeight + " adHeight: " + adHeight + " together: " + (randHeight + adHeight) + " < " + screenHeight);
            }
            else if (randHeight + adHeight > screenHeight / 2 && randHeight + adHeight < screenHeight - 2 ||
                    randHeight - adHeight > -screenHeight + 2 && randHeight - adHeight < -screenHeight / 2)
            {
                goodPlacement = true;

                Debug.Log("randWidth: " + randWidth + " adwidth: " + adWidth + " together: " + (randWidth + adWidth) + " < " + screenWidth);
                Debug.Log("randHeight: " + randHeight + " adHeight: " + adHeight + " together: " + (randHeight + adHeight) + " < " + screenHeight);
            }
        }


        Vector3 pos = new Vector3(randWidth, randHeight, 0);

        GameObject instantiatedAd = Instantiate(ad, pos, Quaternion.identity);

        instantiatedAd.transform.SetParent(Canvas.transform, false);

        Debug.Log("Ad randomly spawned at " + pos);
    }

    private void SpawnAdAnywhere()
    {
        // get a random ad
        int randIndex = Random.Range(0, numAds);
        GameObject ad = adArray[randIndex];

        // get random placement
        // made sure the placement is fully within the screen
        bool goodPlacement = false;
        float adWidth = Mathf.Abs(ad.GetComponent<RectTransform>().rect.x);
        float adHeight = Mathf.Abs(ad.GetComponent<RectTransform>().rect.y);

        float randWidth = 0, randHeight = 0;
        while (!goodPlacement)
        {
            randWidth = Random.Range(-screenWidth+adWidth, screenWidth-adWidth);
            randHeight = Random.Range(-screenHeight+adHeight, screenHeight-adHeight);

            // -/+ 2 so the image doesnt go off screen
            if ( randWidth + adWidth < screenWidth-2 && randWidth - adWidth > -screenWidth+2)
            {
                if (randHeight + adHeight < screenHeight-2 && randHeight - adHeight > -screenHeight+2)
                {
                    goodPlacement = true;

                    Debug.Log("randWidth: " + randWidth + " adwidth: " + adWidth + " together: " + (randWidth + adWidth) + " < " + screenWidth);
                    Debug.Log("randHeight: " + randHeight + " adHeight: " + adHeight + " together: " + (randHeight + adHeight) + " < " + screenHeight);
                }
            }   
        }
        

        Vector3 pos = new Vector3(randWidth, randHeight, 0);

        GameObject instantiatedAd = Instantiate(ad, pos, Quaternion.identity);

        instantiatedAd.transform.SetParent(Canvas.transform, false);

        Debug.Log("Ad randomly spawned at " + pos);
    }

}
