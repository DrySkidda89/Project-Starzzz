using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using GorillaNetworking;
using Photon.Pun;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static OVRPlugin;
using static Menu.HarmonyPatches.GTAGMenu;

namespace ProjectStarzz
{
    [BepInPlugin("ProjectStarzz.CheatCliet", "Starzz", "1.0.0")]
    public class ProjectStarzz : BaseUnityPlugin
    {
        public string GUIName = @"Starzzzz Client";
        private Color guiColor = Color.blue;
        private float colorTimer = 0f;
        private Rect windowRect = new Rect(70, 30, 600, 600);
        public string GUIText = "OPEN";
        void Update()
        {
        }
        public void Start()
        {
            ColorUtility.TryParseHtmlString("#000000", out color1); 
            ColorUtility.TryParseHtmlString("#0000FF", out color2); 
        }
        public bool youturnnedmeon = false;

        void OnGUI()
        {
            GUI.backgroundColor = guiColor;
            GUI.color = guiColor;
            if (GUI.Button(new Rect(20, 20, 100, 20), GUIText))
            {
                if (youturnnedmeon == false)
                {
                    GUIText = "Close Client";
                    youturnnedmeon = true;
                }
                else
                {
                    GUIText = "Open Client";
                    youturnnedmeon = false;
                }
            }
            if (youturnnedmeon)
            {
                windowRect = GUI.Window(10000, windowRect, MainGUI, GUIName);//opens GUI
            }
        }
        public int PageNum;
        public Color color1;
        public Color color2;
        public string Codetojoin = "";
        void MainGUI(int windowID)
        {
            GUI.contentColor = color1;
            GUI.backgroundColor = color2;
            int PageNumlol = PageNum + 1;
            GUI.Label(new Rect(230, 20, 200, 20), "Page: " + PageNumlol);//page label
            switch (PageNum)
            {
                case 0://Page 1//



                    //Collum 1//
                    Codetojoin = GUI.TextArea(new Rect(20, 50, 100, 20), Codetojoin);
                    if (GUI.Button(new Rect(20, 80, 100, 20), "Join"))
                    {
                        PhotonNetworkController.Instance.AttemptToJoinSpecificRoom(Codetojoin);
                    }

                    if (GUI.Button(new Rect(20, 110, 100, 20), "Join Random"))
                    {
                        PhotonNetwork.JoinRandomRoom();
                    }





                    bool isWASDSelected = false;

                    isWASDSelected = GUI.Toggle(new Rect(200, 50, 100, 20), isWASDSelected, "WASD");
                    {
                        {
                            GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
                            bool flag = false;
                            int num = 0;
                            bool key = UnityInput.Current.GetKey(KeyCode.LeftShift);
                            float d;
                            float d2;
                            if (key)
                            {
                                d = 40f;
                                d2 = -40f;
                            }
                            else
                            {
                                d = 5f;
                                d2 = -5f;
                            }
                            bool key2 = UnityInput.Current.GetKey(KeyCode.LeftControl);
                            if (key2)
                            {
                                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(0f, -65f, 0f, ForceMode.Impulse);
                            }
                            bool key3 = UnityInput.Current.GetKey(KeyCode.Space);
                            if (key3)
                            {
                                flag = true;
                            }
                            bool key4 = UnityInput.Current.GetKey(KeyCode.W);
                            if (key4)
                            {
                                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.bodyCollider.transform.forward * Time.deltaTime * d;
                            }
                            bool key5 = UnityInput.Current.GetKey(KeyCode.S);
                            if (key5)
                            {
                                GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.bodyCollider.transform.forward * Time.deltaTime * d2;
                            }
                            bool key6 = UnityInput.Current.GetKey(KeyCode.A);
                            if (key6)
                            {
                                GorillaLocomotion.Player.Instance.transform.Rotate(0f, -1f, 0f);
                            }
                            bool key7 = UnityInput.Current.GetKey(KeyCode.D);
                            if (key7)
                            {
                                GorillaLocomotion.Player.Instance.transform.Rotate(0f, 1f, 0f);
                            }
                            while (flag)
                            {
                                num++;
                                GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().AddForce(0f, 65f, 0f, ForceMode.Impulse);
                                flag = false;
                            }
                        }
                    }

                    if (GUI.Button(new Rect(200, 80, 100, 20), "Admin Badge"))
                    {
                        GorillaTagger.Instance.offlineVRRig.concatStringOfCosmeticsAllowed.Contains("AdministratorBadge");
                    }

                    if (GUI.Button(new Rect(200, 110, 100, 20), "Ghost Monkey"))
                    {

                    }




                    //Collum 3//
                    if (GUI.Button(new Rect(390, 50, 100, 20), "Subscribe To Starzzzz"))
                    {
                        Application.OpenURL("https://www.youtube.com/@StarszYT");
                    }

                    if (GUI.Button(new Rect(390, 80, 100, 20), "Infinite Shiny Rocks"))
                    {
                        CosmeticsController.instance.secondsToWaitToCheckDaily = 60f;
                        CosmeticsController.instance.secondsUntilTomorrow = 60;
                        CosmeticsController.instance.gotMyDaily.Equals(true);
                        CosmeticsController.instance.numShinyRocksToBuy = 9999999;
                        CosmeticsController.instance.currencyBalance = 9999999;
                        CosmeticsController.instance.numShinyRocksToBuy = 9999999;
                        CosmeticsController.instance.hasPrice.Equals(1);
                        CosmeticsController.instance.secondsToWaitToCheckDaily = 60f;
                        CosmeticsController.instance.secondsUntilTomorrow = 60;
                        CosmeticsController.instance.gotMyDaily.Equals(true);
                        CosmeticsController.instance.numShinyRocksToBuy = 9999999;
                        CosmeticsController.instance.checkedDaily.Equals(false);
                        CosmeticsController.instance.currencyBalance = 9999999;
                        CosmeticsController.instance.currencyBalance.Equals("99999999");
                        CosmeticsController.instance.currencyBoardText.Equals("99999999");
                        CosmeticsController.instance.currencyBoxText.Equals("99999999");
                        CosmeticsController.instance.currencyName.Equals("99999999");
                        CosmeticsController.instance.gotMyDaily.Equals(false);
                        CosmeticsController.instance.secondsToWaitToCheckDaily.Equals(1f);
                        CosmeticsController.instance.lastDailyLogin.Equals(false);
                        CosmeticsController.instance.dailyText.Equals("99999999");
                        CosmeticsController.instance.hasPrice.Equals(false);
                        CosmeticsController.instance.numShinyRocksToBuy = 9999999;
                        CosmeticsController.instance.numShinyRocksToBuy.Equals("999999999");
                        CosmeticsController.instance.secondsUntilTomorrow.Equals(1);
                        CosmeticsController.instance.secondsUntilTomorrow.Equals("1");
                        CosmeticsController.instance.shinyRocksCost = 1f;
                        CosmeticsController.instance.shinyRocksCost.Equals("1");
                        CosmeticsController.instance.successfulCurrencyPurchaseTextString.Equals(true);
                        CosmeticsController.instance.shinyRocksCost = 1f;
                        CosmeticsController.instance.shinyRocksCost.Equals("1");
                        CosmeticsController.instance.numShinyRocksToBuy = 9999999;
                        CosmeticsController.instance.numShinyRocksToBuy = 9999999;
                        CosmeticsController.instance.currencyBalance = 9999999;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;
                        CosmeticsController.instance.gotMyDaily = true;

                    }

                    if (GUI.Button(new Rect(390, 110, 100, 20), "Break GameMode"))
                    {

                        GorillaGameManager.instance.currentMasterClient = PhotonNetwork.LocalPlayer;
                        PhotonNetwork.SetMasterClient(PhotonNetwork.LocalPlayer);
                        if (PhotonNetwork.LocalPlayer.IsMasterClient)
                        {
                            PhotonNetwork.Destroy(UnityEngine.Object.FindObjectOfType<GorillaTagManager>().gameObject);
                        }

                    }



                    //Collum 3//



                    if (GUI.Button(new Rect(0, 450, 500, 20), "Next Page"))//forward
                    {
                        PageNum++;
                    }
                    break;
                case 1://Page 2//






                    //Collum 1//
                    if (GUI.Button(new Rect(20, 50, 100, 20), "PlaceHolder"))
                    {
                        ProcessInvisTriggerPlatforms();
                    }
                    if (GUI.Button(new Rect(20, 80, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(20, 110, 100, 20), "PlaceHolder"))
                    {

                    }






                    //Collum 2//
                    if (GUI.Button(new Rect(200, 50, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(200, 80, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(200, 110, 100, 20), "PlaceHolder"))
                    {

                    }




                    //Collum 3//
                    if (GUI.Button(new Rect(390, 50, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(390, 80, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(390, 110, 100, 20), "PlaceHolder"))
                    {

                    }




                    if (GUI.Button(new Rect(0, 450, 500, 20), "Next Page"))//forward
                    {
                        PageNum++;
                    }
                    if (GUI.Button(new Rect(0, 470, 500, 20), "Prev Page"))//Backward
                    {
                        PageNum--;
                    }
                    break;
                case 2://Page 3//





                    //Collum 1//
                    if (GUI.Button(new Rect(20, 50, 100, 20), "PlaceHolder"))
                    {

                    }
                    if (GUI.Button(new Rect(20, 80, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(20, 110, 100, 20), "PlaceHolder"))
                    {

                    }






                    //Collum 2//
                    if (GUI.Button(new Rect(200, 50, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(200, 80, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(200, 110, 100, 20), "PlaceHolder"))
                    {

                    }




                    //Collum 3//
                    if (GUI.Button(new Rect(390, 50, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(390, 80, 100, 20), "PlaceHolder"))
                    {

                    }

                    if (GUI.Button(new Rect(390, 110, 100, 20), "PlaceHolder"))
                    {

                    }




                    if (GUI.Button(new Rect(0, 470, 500, 20), "<<<<<<<"))//Backward
                    {
                        PageNum--;
                    }

                    break;

            }
            GUI.DragWindow();
        }
    }
}
