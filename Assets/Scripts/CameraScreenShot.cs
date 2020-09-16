using UnityEngine;

public class CameraScreenShot : MonoBehaviour
{

    private static CameraScreenShot instance;

    private Camera myCamera;
    private bool takeSreenShotOnNextframe;
    int number = 1;
    AudioSource sound;

    public GameObject Logotype;


    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();

    }

    private void Start()
    {
        Logotype.SetActive(false);
        sound = GetComponent<AudioSource>();

    }
    private string GetAndroidExternalStoragePath()
    {
        if (Application.platform != RuntimePlatform.Android)
            return Application.persistentDataPath;

        var jc = new AndroidJavaClass("android.os.Environment");
        var path = jc.CallStatic<AndroidJavaObject>("getExternalStoragePublicDirectory", jc.GetStatic<string>("DIRECTORY_DCIM")).Call<string>("getAbsolutePath");
        return path;
    }
    private void OnPostRender()
    {
        if (takeSreenShotOnNextframe)
        {
            takeSreenShotOnNextframe = false;
            var texture = ScreenCapture.CaptureScreenshotAsTexture();
            texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0, false);
            texture.Apply();
            string name = string.Format("{0}_Capture{1}_{2}.png", Application.productName, "{0}", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(texture, Application.productName + " Captures", name));

            //byte[] byteArray = texture.EncodeToPNG();

            //System.IO.File.WriteAllBytes(GetAndroidExternalStoragePath() + "/CameraScreenshot" + number + ".png", byteArray);
            number++;

            Destroy(texture);//очистка
            Logotype.SetActive(false);

            //RenderTexture renderTexture = myCamera.targetTexture;   это работает но пока закоментим
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////   
        //Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
        //Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
        //renderResult.ReadPixels(rect, 0, 0);

        //byte[] byteArray = renderResult.EncodeToPNG();
        //System.IO.File.WriteAllBytes(Application.persistentDataPath + "/CameraScreenshot"+number+".png", byteArray);
        //number++;
        //Debug.Log("Saved screenshot");

        //RenderTexture.ReleaseTemporary(renderTexture);
        //myCamera.targetTexture = null;


    }
    public void TakePhoto()
    {

        //myCamera.targetTexture = RenderTexture.GetTemporary(Screen.width, Screen.height, 16);
        if (Screen.orientation == ScreenOrientation.LandscapeLeft) { Logotype.transform.localPosition = new Vector3(0f, -0.0163f, 0.06f); }
        else if (Screen.orientation == ScreenOrientation.Portrait) { Logotype.transform.localPosition = new Vector3(0f, -0.03f, 0.06f); }
        Logotype.SetActive(true);
        takeSreenShotOnNextframe = true;
        if (!sound.isPlaying)
        {
            sound.Play();
        }

    }
    private void TakeScreenShot(int width, int height)
    {

        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeSreenShotOnNextframe = true;
    }

    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenShot(width, height);
    }
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CameraScreenShot.TakeScreenshot_Static(500, 500);
        }
        sound.volume = MainMenuManager.volumeLevel / 2f;
    }



}