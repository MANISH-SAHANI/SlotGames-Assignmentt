using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

///-----------------------------------------------------------------------------------------
///   Namespace:      USM
///   Class:          SceneIntro
///   Description:    process user input & display result
///-----------------------------------------------------------------------------------------
namespace USM
{
	public class SceneIntro : MonoBehaviour
	{
		public CanvasGroup Logo;
		private float fAge = 0.0f;

		void Awake()
		{
			Logo.alpha = 0.0f;
		}

		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
			if (fAge < 3.0f)
			{
				fAge += Time.deltaTime;

				if (fAge > 3.0f)
				{
					SceneManager.LoadScene(0);
				}
				else if (fAge > 1.0f)
				{
					Logo.alpha = fAge - 1.0f;
				}
				else { }
			}
		}
	}
}