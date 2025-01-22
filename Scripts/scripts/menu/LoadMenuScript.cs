using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(OnLoadMenu());
    }
    private IEnumerator OnLoadMenu()
    {
        yield return new WaitForSeconds(5);

        SceneManager.LoadSceneAsync("Menu");

        yield return null;
    }
}
