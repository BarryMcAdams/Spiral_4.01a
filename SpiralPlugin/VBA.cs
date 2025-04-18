using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Interop;

namespace SpiralPlugin
{
    public class VBA
    {
        public static void RunVBA()
        {
            var ed = Application.DocumentManager.MdiActiveDocument.Editor;
            try
            {
                var comObj = Application.AcadApplication;
                if (comObj == null)
                {
                    ed.WriteMessage("\nVBA failed: AutoCAD COM interface is null.");
                    return;
                }
                var acadApp = (AcadApplication)comObj;
                acadApp.LoadDVB(@"C:\AutoCADPlugins\Spiral_v4.01f.dvb");
                acadApp.RunMacro("Module1.CreateSpiralStaircase");
                ed.WriteMessage("\nVBA executed successfully.");
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nVBA failed: {ex.Message}");
            }
        }
    }
}