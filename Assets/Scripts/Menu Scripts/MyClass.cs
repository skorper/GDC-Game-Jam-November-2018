using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MyClass : MonoBehaviour
{

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        Application.Quit();
    }
}
