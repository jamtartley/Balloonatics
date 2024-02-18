using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
