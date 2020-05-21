using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Build.Reporting;


public class ProjectBuilder : MonoBehaviour
{
    [SerializeField] bool doubleCheck = true;
    [SerializeField] LevelManager levelManager;
    [SerializeField] Tutorial tutorial;


    public void BuildProject()
    {
        if(doubleCheck)
        {
            Debug.LogError("WARNING: MAKE SURE YOU'VE UPDATED YOUR BUILD SETTINGS IN THIS SCRIPT");
        }
        else
        {
            levelManager.testing = false;
            tutorial.enableTutorial = true;
            foreach (MiniTutorial m in tutorial.MiniTutorials)
                m.enableTutorial = true;
            MyBuild();

            doubleCheck = true; 
        }

     
    }




    public static void MyBuild()
    { 


        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] 
        //PUT SCENES HERE 
        { "Assets/scenes/main.unity", 
        };
        buildPlayerOptions.locationPathName = "iOS";
        buildPlayerOptions.target = BuildTarget.iOS;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
        }

        



    }


  
}
#endif