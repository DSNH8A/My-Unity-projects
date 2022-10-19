using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
        
        public void ShowRewardedAdd()
        {
            Debug.Log("ShowRewardedAdd");

            if (Advertisement.IsReady("rewardedVideo"))
            {
                var options = new ShowOptions
                {
                    resultCallback = HandleShowResult
                };

                Advertisement.Show("4880891", options);
            }
        }

        void HandleShowResult(ShowResult result)
        {
            switch (result)
            { 
             case ShowResult.Finished:
                 //Add 100 Gs;
                    break;
             case ShowResult.Skipped:
                    Debug.Log("No Gems For You");
                    break;
             case ShowResult.Failed:
                    Debug.Log("The video was not ready");
                    break;
            }
        }
        
}
