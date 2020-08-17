using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChangeChildTags : MonoBehaviour
{
    public void Start()
    {
        ChangeChildrenTags();
    }
    //[MenuItem("GameObject/Change Children to Parent Tag")]
    public void ChangeChildrenTags()
    {
        GameObject currentObject = this.gameObject;
        string parentTag = currentObject.tag;
        if (currentObject != null && currentObject.transform.childCount > 0)
        {
            /*if (EditorUtility.DisplayDialog("Change child tags to parent tag", "Do you really want to change every child tag to " + parentTag + "?", "Change tags", "Cancel"))
            {*/
                Transform[] transforms = currentObject.GetComponentsInChildren<Transform>();
                float numberOfTransforms = transforms.Length;
                float counter = 0.0f;
                foreach (Transform childTransform in transforms)
                {
                    counter++;
                /*EditorUtility.DisplayProgressBar("Changing tags", "Changing all child object tags to " + parentTag +
                    "\n  (" + (int)counter + "/" + (int)numberOfTransforms + ")",
                    counter / numberOfTransforms);*/
                    if (childTransform.gameObject.tag != "Language")
                    {
                        childTransform.gameObject.tag = parentTag;
                    }
                }
                //EditorUtility.ClearProgressBar();
            //}

        }
    }
}
