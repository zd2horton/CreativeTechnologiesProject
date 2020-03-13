using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSplit : MonoBehaviour
{
    //include halls for leaf
    public float minRoomWidth, minRoomHeight, minLeafSize;
    bool completedSplit;

    private void Start()
    {
        minLeafSize = 5;
    }

    public bool DirectionChoice(Leaf currentLeaf, ref Leaf leftChild, ref Leaf rightChild)
    {
        string splitDirection = "";
        //if there are pre-existing children then return false
        if (leftChild != null && rightChild != null)
        {
            return false;
        }

        if (currentLeaf.leafHeight > (currentLeaf.leafWidth * 1.40))
        {
            //split horizontally
            splitDirection = "Horizontal";
        }

        else if (currentLeaf.leafWidth > (currentLeaf.leafHeight * 1.40))
        {
            //split vertically
            splitDirection = "Vertical";
        }

        else
        {
            //otherwise do it randomly
            int randomPick = Random.Range(1, 3);
            switch (randomPick)
            {
                case 1:
                    {
                        splitDirection = "Horizontal";
                        break;
                    }

                case 2:
                    {
                        splitDirection = "Horizontal";
                        break;
                    }
            }
        }

        //Take area(leaf)
        //Random Direction for Cut
        //Find Random Position for Cut Direction
        //Split
        //Document 2 child rooms
        //place them in tree

        completedSplit = SplitLeaf(splitDirection, currentLeaf, leftChild, rightChild);

        switch (completedSplit)
        {
            case true:
                return true;
                
            case false:
                return false;

            default:
                return false;
        }
    }

    bool SplitLeaf(string cutDirection, Leaf currentLeaf, Leaf lChild, Leaf rChild)
    {
        float maxLeafSize = 0.0f;
        //calculate maximum dimension for leaf
        if (cutDirection == "Horizontal")
        {
            maxLeafSize = currentLeaf.leafHeight - minLeafSize;
        }

        else if (cutDirection == "Vertical")
        {
            maxLeafSize = currentLeaf.leafWidth - minLeafSize;
        }

        //all canvas used up if maximum dimension for splitting <= minimum size for it
        if (maxLeafSize <= minLeafSize)
        {
            return false;
        }

        else
        {
                //find value to split by through using minimum and maximum split sizes available
                float splitBy = Random.Range(minLeafSize, maxLeafSize);
                Debug.Log(splitBy);

                if (cutDirection == "Horizontal")
                {
                    //create children based on result, same width but reduced height
                    lChild.leafPosition = currentLeaf.leafPosition;
                    lChild.leafWidth = currentLeaf.leafWidth;
                    lChild.leafHeight = splitBy;

                    rChild.leafPosition = new Vector2(currentLeaf.leafPosition.x, currentLeaf.leafPosition.y + splitBy);
                    rChild.leafWidth = currentLeaf.leafWidth;
                    rChild.leafHeight = currentLeaf.leafHeight - splitBy;

                }

                else if (cutDirection == "Vertical")
                {
                    //create children based on result, same height but reduced width
                    lChild.leafPosition = currentLeaf.leafPosition;
                    lChild.leafHeight = currentLeaf.leafHeight;
                    lChild.leafWidth = splitBy;

                    rChild.leafPosition = new Vector3(currentLeaf.leafPosition.x + splitBy, currentLeaf.leafPosition.y);
                    rChild.leafHeight = currentLeaf.leafHeight;
                    rChild.leafWidth = currentLeaf.leafWidth - splitBy;
                }
        }
            
        return true;
    }
}
