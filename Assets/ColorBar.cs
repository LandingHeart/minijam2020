using UnityEngine;
using UnityEngine.UI;
public class ColorBar : MonoBehaviour
{
    public Slider slider;

    public void setColorBullets(float color_bullets)
    {
        slider.value = color_bullets;
    }
    // Start is called before the first frame updat
}
