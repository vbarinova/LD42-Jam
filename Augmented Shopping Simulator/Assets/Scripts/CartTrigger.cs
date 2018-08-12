using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartTrigger : MonoBehaviour {

    [SerializeField]
    private GameObject gameController;

    private int numItems;

    private bool[] collected;

    private bool updateOnce = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!updateOnce)
        {
            numItems = gameController.GetComponent<RandomizeShoppingList>().numItemsToCollect();

            Debug.Log("NUM: " + numItems);

            collected = new bool[numItems];

            for (int i = 0; i < numItems; ++i)
            {
                collected[i] = false;
            }

            updateOnce = true;
        }
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(numItems);
        // when an object enters the shopping cart, go through the list of items
        // that need to be collected
        for (int i = 0; i < numItems; ++i)
        {
            // if the objects tag matches a tag for a object to be collecetd
            // an if that object has not been collecetd already
            // horray, mark it as now collecetd
            if (other.tag == gameController.GetComponent<RandomizeShoppingList>().returnItem(i) &&
                collected[i] == false && !other.GetComponent<Pickupable>().isCollected())
            {
                // collecte that sucker
                collected[i] = true;

                // mark that sucker as collecetd
                other.GetComponent<Pickupable>().hasBeenCollected();

                Debug.Log(other.tag + " has been collecetd!");

            }
        }

        // check if can cross of that item from the list
        // they have all been collected
        if (gameController.GetComponent<RandomizeShoppingList>().allCollected(other.tag))
        {
            // then cross item off list
            gameController.GetComponent<RandomizeShoppingList>().crossOffItem(other.tag);
        }
    }

    public bool winner()
    {
        Debug.Log("WHat the hell " + numItems);

        for (int i = 0; i < numItems; ++i)
        {
            if (collected[i] == false) return false;
            Debug.Log("COLLECTED: " + collected[i]);
        }

        Debug.Log("Yay, you have won");
        return true;
    }

   public bool collectedItem(int index)
    {
        return collected[index];
    }
}
