using Autodesk.AutoCAD.ApplicationServices;

namespace SpiralPlugin
{
    public class VRails
    {
        public static void AddVerticalRailings()
        {
            var ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                ed.WriteMessage("\nAdding vertical railings...");
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nVertical railings failed: {ex.Message}");
            }
        }
    }
}