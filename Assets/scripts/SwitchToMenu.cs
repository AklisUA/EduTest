using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToMenu : MonoBehaviour
{
        public GameObject Category;
        public GameObject Menu;
        public void SwitchToCategoryCan()
        {
            Category.SetActive(false);
            Menu.SetActive(true);

        }
    }
    