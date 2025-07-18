using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    private int breakableBlocks;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // called when each level starts by every breakable block
    public void AddBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;

        // level ended , all blocks are destroyed so move to the next level/scene
        if (breakableBlocks <= 0)
        {
            int currentScene = SceneLoader.Instance.GetCurrentSceneIndex();
            SceneLoader.Instance.LoadSceneByIndex(currentScene + 1);
        }
    }
}
