using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinatorialFiller : MonoBehaviour
{
    //1. Set a first block
          //Probably just select a random voxel with Z index 0
             //Position a block on this voxel

    //2. Find all the possible next voxels
         //loop over all the voxel in the Voxelgrid
            //Get list of voxels Where possibleDirection contains elements

    //3. Select a random voxel out of the PossibleNextVoxels list
            //Try add a block in one of the possible direction (how do I get a quaternion from my axis)
                //Pick a random direction out of the list
                //Try add block in this direction
                    //if fails, remove tried direction from the voxels possible direction list
                     //if succeeds, add block to the grid
                        //crossreference the original possible directions with the ones from the new block (Check which directions exist in both lists)

                            //Xmin, Ymin, Zplus
                            //Xplus, Ymin, Zplus, Zmin



    //4. Loop over 2 --> 3 till you place a certain amount of blocks, or no more blocks can be added


    // Start is called before the first frame update

    VoxelGrid _grid;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
