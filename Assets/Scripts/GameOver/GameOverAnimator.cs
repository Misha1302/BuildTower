namespace GameOver
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;

    public class GameOverAnimator : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private float speed;

        private void Start()
        {
            StartCoroutine(Animate());
        }

        private IEnumerator Animate()
        {
            while (image.color.a > 0)
            {
                var color = image.color;
                color.a -= 1 / speed * Time.deltaTime;
                image.color = color;
                
                yield return new WaitForEndOfFrame();
            }
            
            Destroy(image);
        }
    }
}