using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    public void BackToMenu()
    {
        SelectionManager.Instance.GoToTitleScene();
    }
}
