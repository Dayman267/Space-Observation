using UnityEngine.SceneManagement;

namespace App
{
    public sealed class CorrectSceneLauncher
    {
        public void OpenCorrectScene()
        {
            SceneManager.LoadScene("CorrectScene");
        }
    }
}