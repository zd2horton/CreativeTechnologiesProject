using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPTree : MonoBehaviour
{
    private List<Leaf> partitioningTree;
    private List<Leaf> finishedTree;
    bool finished, drawn, successfulSplit;
    LeafSplit splitting;

    // Start is called before the first frame update
    void Start()
    {
        partitioningTree = new List<Leaf>();
        finishedTree = new List<Leaf>();
        splitting = gameObject.GetComponent<LeafSplit>();
        drawn = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessChild();
    }

    void ProcessChild()
    {
        //initial leaf
        if (partitioningTree.Count == 0)
        {
            Leaf initialArea = new Leaf();
            initialArea.leafPosition = new Vector2 (0, 0);
            initialArea.leafWidth = 1000;
            initialArea.leafHeight = 1000;
            partitioningTree.Add(initialArea);
        }

        successfulSplit = false;

        //while splitting still needs to happen
        while (finished == false)
        {
            //for each leaf
            for (int i = 0; i < partitioningTree.Count; i++)
            {
                Leaf childL = new Leaf();
                Leaf childR = new Leaf();
                //if not split already
                //bool for use here on if true is returned on splitting
                successfulSplit = splitting.DirectionChoice(partitioningTree[i], ref childL, ref childR);

                if (successfulSplit == true)
                {
                    partitioningTree.Add(childL);
                    partitioningTree.Add(childR);
                    partitioningTree.Remove(partitioningTree[i]);
                    finishedTree.Add(partitioningTree[i]);
                }

                else if (successfulSplit == false)
                {
                    finished = true;
                }

                childL = null;
                childR = null;
            }
        }

        if (finished == true && drawn == false)
        {
            Debug.DebugBreak();
            TreeOutput();
        }
    }

    void TreeOutput()
    {
        //add child boxes then hide original?
        //don't need to split original, visualise dimensions of children
        //just draw final boxes
        //use data for process and visual representation only at end
        //separate model from presentation
        //process current array into finished tree for visuals
        //process finished tree into visual form

        //keep only required children
        //bitmap tree

        //output

        foreach (Leaf leaftoAdd in partitioningTree)
        {
            finishedTree.Add(leaftoAdd);
        }

        foreach (Leaf leafToOutput in finishedTree)
        {
            GameObject newArea = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newArea.transform.position = new Vector3(leafToOutput.leafPosition.x -500, 0, leafToOutput.leafPosition.y -500);
            newArea.transform.localScale = new Vector3(leafToOutput.leafWidth, 1, leafToOutput.leafHeight);
        }

        drawn = true;
    }
}