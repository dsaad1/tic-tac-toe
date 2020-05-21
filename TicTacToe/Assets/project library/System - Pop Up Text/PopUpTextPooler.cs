using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTextPooler : MonoBehaviour
{
    public static PopUpTextPooler self;

    public GameObject speedBoostObj;
    public GameObject airTimeObj;
    public GameObject killObj;
    public GameObject railObj;

    private List<PopUpText> speedBoostObjs = new List<PopUpText>();
    private List<PopUpText> airTimeObjs = new List<PopUpText>();
    private List<PopUpText> killObjs = new List<PopUpText>();
    private List<PopUpText> railObjs = new List<PopUpText>();

    void Awake()
    {
        self = this;
    }

    //speed boost 
    #region
    public PopUpText GetSpeedBoostObj(Vector3 pos, Transform parent, string animationToPlay)
    {
        for (int i = 0; i < speedBoostObjs.Count; i++)
        {
            if (!speedBoostObjs[i].gameObject.activeInHierarchy)
            {
                speedBoostObjs[i].transform.position = pos;
                speedBoostObjs[i].transform.SetParent(parent);
                speedBoostObjs[i].gameObject.SetActive(true);
                speedBoostObjs[i].OnActivation(animationToPlay);
                return speedBoostObjs[i];
            }
        }
        return CreateSpeedBoostObj(pos, parent, animationToPlay);
    }

    public PopUpText CreateSpeedBoostObj(Vector3 pos, Transform parent, string animationToPlay)
    {
        PopUpText obj = Instantiate(speedBoostObj).GetComponent<PopUpText>();
        obj.transform.position = pos;
        obj.transform.SetParent(parent);
        speedBoostObjs.Add(obj);
        obj.OnActivation(animationToPlay);
        obj.gameObject.SetActive(true);
        return obj;
    }
    #endregion


    //air time
    #region
    public PopUpText GetAirTimeObj(Vector3 pos, Transform parent, string animationToPlay)
    {
        for (int i = 0; i < airTimeObjs.Count; i++)
        {
            if (!airTimeObjs[i].gameObject.activeInHierarchy)
            {
                airTimeObjs[i].transform.position = pos;
                airTimeObjs[i].transform.SetParent(parent);
                airTimeObjs[i].gameObject.SetActive(true);
                airTimeObjs[i].OnActivation(animationToPlay);
                return airTimeObjs[i];
            }
        }
        return CreateAirTimeObj(pos, parent, animationToPlay);
    }

    public PopUpText CreateAirTimeObj(Vector3 pos, Transform parent, string animationToPlay)
    {
        PopUpText obj = Instantiate(airTimeObj).GetComponent<PopUpText>();
        obj.transform.position = pos;
        obj.transform.SetParent(parent);
        airTimeObjs.Add(obj);
        obj.OnActivation(animationToPlay);
        obj.gameObject.SetActive(true);
        return obj;
    }
    #endregion

    //kill
    #region
    public PopUpText GetKillObj(Vector3 pos, Transform parent, string animationToPlay)
    {
        for (int i = 0; i < killObjs.Count; i++)
        {
            if (!killObjs[i].gameObject.activeInHierarchy)
            {
                killObjs[i].transform.position = pos;
                killObjs[i].transform.SetParent(parent);
                killObjs[i].gameObject.SetActive(true);
                killObjs[i].OnActivation(animationToPlay);
                return killObjs[i];
            }
        }
        return CreateKillObj(pos, parent, animationToPlay);
    }

    public PopUpText CreateKillObj(Vector3 pos, Transform parent, string animationToPlay)
    {
        PopUpText obj = Instantiate(killObj).GetComponent<PopUpText>();
        obj.transform.position = pos;
        obj.transform.SetParent(parent);
        killObjs.Add(obj);
        obj.OnActivation(animationToPlay);
        obj.gameObject.SetActive(true);
        return obj;
    }
    #endregion

    //rail
    #region
    public PopUpText GetRailObj(Vector3 pos, Transform parent, string animationToPlay)
    {
        for (int i = 0; i < railObjs.Count; i++)
        {
            if (!railObjs[i].gameObject.activeInHierarchy)
            {
                railObjs[i].transform.position = pos;
                railObjs[i].transform.SetParent(parent);
                railObjs[i].gameObject.SetActive(true);
                railObjs[i].OnActivation(animationToPlay);
                return railObjs[i];
            }
        }
        return CreateRailObj(pos, parent, animationToPlay);
    }

    public PopUpText CreateRailObj(Vector3 pos, Transform parent, string animationToPlay)
    {
        PopUpText obj = Instantiate(railObj).GetComponent<PopUpText>();
        obj.transform.position = pos;
        obj.transform.SetParent(parent);
        railObjs.Add(obj);
        obj.OnActivation(animationToPlay);
        obj.gameObject.SetActive(true);
        return obj;
    }
    #endregion
}
