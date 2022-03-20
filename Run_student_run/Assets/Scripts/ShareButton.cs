using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour
{
    public void ShareClicked()
    {
        StartCoroutine(ShareFunction());
    }

    private IEnumerator ShareFunction()
    {
        yield return new WaitForEndOfFrame();

        Texture2D t = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        t.ReadPixels( new Rect(0, 0, Screen.width, Screen.height ), 0, 0);
        t.Apply();

        string filePath = Path.Combine(Application.temporaryCachePath, "shared img.png");
        File.WriteAllBytes(filePath, t.EncodeToPNG());

        new NativeShare().AddFile(filePath).SetSubject("MyGames").SetText("Hey, download this fantastic game!").Share();
    }
}
