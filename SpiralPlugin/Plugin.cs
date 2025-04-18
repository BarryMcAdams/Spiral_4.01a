using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;

namespace SpiralPlugin
{
    public class Plugin
    {
        [CommandMethod("CreateSpiral")]
        public void CreateSpiral()
        {
            var ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                ed.WriteMessage("\nStarting spiral creation...");
                VBA.RunVBA();
                Reader.ReadData();
                HRails.AddHorizontalRailings();
                VRails.AddVerticalRailings();
                PostCreation.DuplicateCenterPole();
                ed.WriteMessage("\nSpiral creation completed.");
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nError in CreateSpiral: {ex.Message}");
            }
        }
    }
}