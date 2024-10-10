using UnityEngine.SceneManagement;

namespace App
{
    public class MainMenuLauncher
    {
        public void GoToMainMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}