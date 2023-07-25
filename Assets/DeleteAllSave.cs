using UnityEngine;

public class DeleteAllSave : MonoBehaviour
{
    public void Delete()
    {
        PlayerPrefs.DeleteAll();
    }
}
