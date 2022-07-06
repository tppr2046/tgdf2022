using System.IO;
using HutongGames.PlayMaker;

namespace BansheeGz.BGDatabase
{
    [ActionCategory("BansheeGz")]
    [HutongGames.PlayMaker.Tooltip("Save database state to a file in persistent folder")]
    public partial class SaveGame : SaveLoadWithNameA
    {
        public override void OnEnter()
        {
            var fullFileName = FullFileName;
            File.WriteAllBytes(fullFileName, BGRepo.I.Addons.Get<BGAddonSaveLoad>().Save());
            Log("Saved OK. File at: $", fullFileName);
            Finish();
        }
    }
}