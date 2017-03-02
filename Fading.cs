using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

    public Texture2D FadeOutTexture; //The picture that will overlay the scene during fadeins and fadeouts.
    public float fadeSpeed = 0.8f; //Fading Speed

    private int DrawDepth = -1000; //The texture's order in the hierarchy. Lower is rendered first.
    private float alpha = 1.0f; //The texture's alpha (~~transparency) value
    private int fadeDir = -1; //The direction to fade in. FadeIn = -1 // FadeOut = 1

    void OnGUI()
    {
        //Fade in/out alpha value using a direction, a speed and Time.Deltatime to convert the operation to seconds.
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //force (clamp) the number between 0 and 1 because 0<alpha<1 in RGBA
        alpha = Mathf.Clamp01(alpha);

        //Set color of our GUI (in this case, FadeOutTexture). All colors remain the same and the alpha is set to this.alpha
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = DrawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), FadeOutTexture); //Creates a new rectangle filled with the texture to fill the screen
    }

    //sets fadeDir to the direction parameter making the scene fadein if -1 and fadeout if 1
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed); //return the fadeSpeed var so it's easy to time the Application.LoadLevel();
    }

    //OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes
    void OnLevelWasLoaded()
    {
        // alpha = 1; //if alpha is not set to 1 already
        BeginFade(-1);
    }
}
