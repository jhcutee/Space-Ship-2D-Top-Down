using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormHole : MonoBehaviour
{
    protected string galaxyName_1 = "Galaxy_1";
    protected virtual void OnMouseDown()
    {
        this.LoadGalaxyScene();
    }
    protected virtual void LoadGalaxyScene()
    {
        SceneManager.LoadScene(galaxyName_1);
    }
}
