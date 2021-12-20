using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : MonoBehaviour
{
   public void ChooseAnimal(int choice)
    {
        SelectionManager.Instance.SelectAnimal(choice);
        SelectionManager.Instance.GoToMainScene();
    }

    public void QuitGame()
    {
        SelectionManager.Instance.Quit();
    }
}
