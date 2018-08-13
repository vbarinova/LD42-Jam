using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillShelves : MonoBehaviour {

    [SerializeField]
    private GameObject[] allItems;

    private float firstShelf = 3.5f;
    private float secondShelf = 10.4f;
    private float thirdShelf = 18f;

    private float startShelves = 9.5f;
    private float endShelves = 132f;

    private float sizePerItem = 4f;

    private float leftSide = -13.3f;
    private float rightSide = 14.7f;

    private int rightRotate = 180;

	// Use this for initialization
	void Start () {
        // 3 shelves on two sides
        // left bottom
        randomizeSelf(firstShelf, leftSide, false);

        // left middle
        randomizeSelf(secondShelf, leftSide, false);

        // left top
        randomizeSelf(thirdShelf, leftSide, false);

        // right bottom
        randomizeSelf(firstShelf, rightSide, true);

        // right middle
        randomizeSelf(secondShelf, rightSide, true);

        // right top
        randomizeSelf(thirdShelf, rightSide, true);
    }

    // Update is called once per frame
    void Update () {
        

    }

    private void randomizeSelf(float shelfHeight, float side, bool rightRotated)
    {
        int randIndex;
        float xPos = side, 
              yPos = shelfHeight, 
              zPos, zStart, zEnd;

        Debug.Log("number of items: " + (endShelves - startShelves) / sizePerItem);
        // length of the shelves divided by the size for each item = number of items per shelf
        for (int i = 0; i < (endShelves - startShelves)/sizePerItem; ++i)
        {
            // for each item slot, randomly choose an item to place
            randIndex = (int)Mathf.Floor(Random.Range(0f, allItems.Length));

            // instantiate the item in the center of the slot
            zStart = i * sizePerItem + startShelves;
            zEnd = (i+1) * sizePerItem + startShelves;
            zPos = (zStart + zEnd) / 2;

            Vector3 position = new Vector3(xPos, yPos, zPos);

            // if on the right shelf, rotate everything 180
            if (rightRotated)
            {
                Instantiate(allItems[randIndex], position, Quaternion.AngleAxis(180, transform.up));
            }

            else
            {
                Instantiate(allItems[randIndex], position, Quaternion.identity);
            }
            
        }
    }
}
