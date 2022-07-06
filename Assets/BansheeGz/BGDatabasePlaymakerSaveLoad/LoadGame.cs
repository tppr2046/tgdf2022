using System.IO;
using HutongGames.PlayMaker;

namespace BansheeGz.BGDatabase
{
    [ActionCategory("BansheeGz")]
    [HutongGames.PlayMaker.Tooltip("Load database state from a file in persistent folder")]
    public partial class LoadGame : SaveLoadWithNameA
    {
        public override void OnEnter()
        {
            var fullFileName = FullFileName;
            if (File.Exists(fullFileName))
            {
                var data = File.ReadAllBytes(fullFileName);
                if (data.Length > 0)
                {
                    BGRepo.I.Addons.Get<BGAddonSaveLoad>().Load(data);
                    Log("Loaded OK. File at: $", fullFileName);
                }
                else Log("Can not load: file at: $ has no data", fullFileName);
            }
            else Log("Can not load: file is not found: $", fullFileName);

            Finish();
        }
    }
}