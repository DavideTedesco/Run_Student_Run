using System.Collections;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{
	private string messageToShare;

	public void ClickShareButton()
    {
		messageToShare = "Hi I'm playing with GAME_NAME!! What are you waiting for? Download it! <a href=\"https://davidetedesco.github.io/a-wonderful-platform-game-site\" > here</a>";
		StartCoroutine(TakeScreenshotAndShare());
    }

	private IEnumerator TakeScreenshotAndShare()
	{
		yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		ss.Apply();

		string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
		File.WriteAllBytes(filePath, ss.EncodeToPNG());

        // To avoid memory leaks
        Destroy(ss);

		new NativeShare().AddFile(filePath).SetSubject("Subject goes here").SetText(messageToShare).Share();

		
	}
}
