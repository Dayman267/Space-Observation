using UnityEngine.SceneManagement;

namespace App
{
    public sealed class GameLauncher
    {
        public void StartGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}