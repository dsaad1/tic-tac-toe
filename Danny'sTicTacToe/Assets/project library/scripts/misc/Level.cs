using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : LevelBase {


    private void Awake()
    {
        if(LevelManager.self.UsingScenes)
            LevelManager.self.SetLevel(this);
    }

}
