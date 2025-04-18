using Autodesk.AutoCAD.ApplicationServices;

namespace SpiralPlugin
{
    public class HRails
    {
        public static void AddHorizontalRailings()
        {
            var ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                ed.WriteMessage("\nAdding horizontal railings...");
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nHorizontal railings failed: {ex.Message}");
            }
        }
    }
}