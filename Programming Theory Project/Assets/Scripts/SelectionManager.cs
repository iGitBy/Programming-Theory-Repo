using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;

    [SerializeField] private List<GameObject> animals;

    private static int animalSelected;


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void GoToMainScene()
    {
        SceneManager.LoadScene("Main");
    }

    public void GoToTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void SelectAnimal(int selection)
    {
        animalSelected = selection;
    }

    public void SpawnAnimal()
    {
        Instantiate(animals[animalSelected]);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();

#endif
    }




}
