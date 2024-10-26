using UnityEngine.SceneManagement;

namespace App
{
    public sealed class MainMenuLauncher
    {
        public void GoToMainMenu() => SceneManager.LoadScene("Menu");
    }
}