using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AwalLoading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadALevel());
    }

    private IEnumerator LoadALevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("LoadingMenu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
