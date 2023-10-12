namespace GameOver
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(RestartButton))]
    public sealed class RestartButton : MonoBehaviour
    {
        private ImageAnimator _imageAnimator;

        private void Start()
        {
            _imageAnimator = GetComponent<ImageAnimator>();
            GetComponent<Button>().onClick.AddListener(() => StartCoroutine(
                _imageAnimator.Animate(SceneManagerR.LoadGameScene)
            ));
        }
    }
}