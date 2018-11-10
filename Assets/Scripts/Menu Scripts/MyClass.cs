using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MyClass : MonoBehaviour
{

    public void Quit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        //THIS LINE CAUSES AND ERROR WHILE BUILDING
        //the editor wont close if you run application.quit() so its unneeded anyway -alex

        Application.Quit();
    }
}
