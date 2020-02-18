using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    //include halls for leaf
    public float minRoomWidth, minRoomHeight, minLeafSize;
    private Leaf childL, childR;
    private LeafInfo currentLeaf;

    public struct LeafInfo
    {
        public float leafWidth, leafHeight;
        public Vector2 leafPosition;
    }

    bool DirectionChoice()
    {
        string splitDirection = "";
        //if there are pre-existing children then return false
        if (childL != null && childR != null)
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
            int randomPick = Random.Range(1,3);
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

        SplitLeaf(splitDirection);
        return true;
    }

    bool SplitLeaf(string cutDirection)
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

            if (cutDirection == "Horizontal")
            {
                //create children based on result
                //childL = new Leaf...
                //childR = new Leaf...
            }

            if (cutDirection == "Vertical")
            {
                //create children based on result
                //childL = new Leaf...
                //childR = new Leaf...
            }

        }

        //add child boxes then hide original?
        //don't need to split original, visualise dimensions of children
        //just draw final boxes
        //use data for process and visual representation only at end
        //separate model from presentation

        return true;
    }
}
