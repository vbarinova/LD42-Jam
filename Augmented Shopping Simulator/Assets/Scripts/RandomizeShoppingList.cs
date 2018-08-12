using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomizeShoppingList : MonoBehaviour {

    [SerializeField]
    private GameObject goal;

    [SerializeField]
    private GameObject[] allItems; // all possible items to collect

    [SerializeField]
    private GameObject textContainer;

    [SerializeField]
    private GameObject[] textArray;
    //private GameObject textPrefab;
    private int[] itemCounts;

    // number of items to collect
    private int numItems = 10;

    private string[] itemsToCollect;

	// Use this for initialization
	void Start () {
        itemsToCollect = new string[numItems];

        randomizeShoppingList();

        displayShoppingList();

        //////
        for (int i = 0; i < numItems; ++i)
        {
            Debug.Log("Collect: " + itemsToCollect[i]);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void randomizeShoppingList()
    {
        int randIndex, itemCount = 0;

        while( itemCount < numItems)
        {
            // assign up to half the required items randomly
            if (itemCount < numItems/2)
            {
                randIndex = (int)Mathf.Floor(Random.Range(0f, allItems.Length));
                itemsToCollect[itemCount] = allItems[randIndex].tag;

                ++itemCount;
            }
            // afterwards start assigning duplicates
            else
            {
                randIndex = (int)Mathf.Floor(Random.Range(0f, numItems / 2));

                itemsToCollect[itemCount] = itemsToCollect[randIndex];

                ++itemCount;
            }
            

            
        }


    }

    public string returnItem(int index)
    {
        return itemsToCollect[index];
    }

    public int numItemsToCollect()
    {
        return numItems;
    }

    public void displayShoppingList()
    {
        GameObject tempText;
        itemCounts = new int[numItems / 2];

        // count how many of each item
        for (int i = 0; i < numItems; ++i)
        {
            // less then half, there are no duplicates
            if (i < numItems / 2) itemCounts[i] = 1;
            else
            {
                for (int j = 0; j < numItems/2; ++j)
                {
                    // if duplicate, add one
                    if (itemsToCollect[i] == itemsToCollect[j])
                        itemCounts[j] += 1;
                }
            }
        }

        // actually output the item
        for (int i = 0; i < numItems / 2; ++i)
        {
            //tempText = Instantiate(textPrefab);
            tempText = textArray[i];

            tempText.transform.SetParent(textContainer.transform);

            tempText.GetComponent<TextMeshProUGUI>().text = itemCounts[i].ToString() + " " + itemsToCollect[i];
        }


    }

    public bool allCollected(string tag)
    {
        bool itemInList = false;
        for (int i = 0; i < numItems; ++i)
        {
            // if an item on the list matches the tag and 
            // is not collected, return false, not all collected
            if (tag == itemsToCollect[i] && !goal.GetComponent<CartTrigger>().collectedItem(i))
            {
                Debug.Log(tag + " not all collected");
                return false;
            }
            // to make sure items that are not in the list do not set off
            // the winning condition
            if (tag == itemsToCollect[i]) itemInList = true;
        }

        // item is in list and has all been connected
        if (itemInList)
        {
            Debug.Log(tag + " hass been fully collected yo!");

            return true;
        }

        return false;
        
    }

    public void crossOffItem(string tag)
    {
        for (int i = 0; i < numItems/2; ++i)
        {
            if (tag == itemsToCollect[i])
            {
                textArray[i].GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Strikethrough;
            }
        }
    }

    public bool everythingCollected()
    {
        for (int i = 0; i < numItems; ++i)
        {
            // if collected item is false, not everything collected, return false
            if (!goal.GetComponent<CartTrigger>().collectedItem(i)) return false;
        }

        // if never exiyed loop, everything collecetd
        return true;
    }

}
