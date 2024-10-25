using System.Collections;
using UnityEngine;

namespace _Scripts
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager Instance;

        public bool specialAtkReady;
        public GameObject specialAtkObj;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            StartCoroutine(SpecialAtk());
        }

        private IEnumerator SpecialAtk()
        {
            while (true)
            {
                if (!specialAtkReady)
                {
                    specialAtkObj.SetActive(false);
                    yield return null;
                }
                else
                {
                    specialAtkObj.SetActive(true);
                    yield return new WaitForSeconds(1f);
                    specialAtkObj.SetActive(false);
                    yield return new WaitForSeconds(1f);
                }
            }
        }
    }
}
