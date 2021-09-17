using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{

   private MenuObject originMenu;
   public void Activate(MenuObject menu)
   {
      gameObject.SetActive(true);
      originMenu = menu;
   }
   
   public void Deactivate()
   {
      gameObject.SetActive(false);
      originMenu.Activate();
   }
}
