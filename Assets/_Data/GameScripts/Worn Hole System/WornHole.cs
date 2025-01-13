using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WornHole : BaseMonobehaviour
{
    protected const string GALAXY_ONE = "Galaxy One";

    protected virtual void OnMouseDown()
    {
        LoadGalaxy();
    }

    private void LoadGalaxy()
    {
        SceneManager.LoadScene(GALAXY_ONE);
    }
}
