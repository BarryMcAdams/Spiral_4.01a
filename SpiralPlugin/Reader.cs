using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace SpiralPlugin
{
    public class Reader
    {
        public static void ReadData()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;
            try
            {
                using (var tr = db.TransactionManager.StartTransaction())
                {
                    var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                    var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForRead);
                    foreach (ObjectId id in btr)
                    {
                        var txt = tr.GetObject(id, OpenMode.ForRead) as DBText;
                        if (txt != null && txt.Layer == "SpiralStairData")
                        {
                            ed.WriteMessage($"\nRead: {txt.TextString}");
                            return;
                        }
                    }
                    ed.WriteMessage("\nNo data found on SpiralStairData layer.");
                    tr.Commit();
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nReader failed: {ex.Message}");
            }
        }
    }
}