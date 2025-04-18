using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;

namespace SpiralPlugin
{
    public class PostCreation
    {
        public static void DuplicateCenterPole()
        {
            var doc = Application.DocumentManager.MdiActiveDocument;
            var db = doc.Database;
            var ed = doc.Editor;
            try
            {
                using (var tr = db.TransactionManager.StartTransaction())
                {
                    var bt = (BlockTable)tr.GetObject(db.BlockTableId, OpenMode.ForRead);
                    var btr = (BlockTableRecord)tr.GetObject(bt[BlockTableRecord.ModelSpace], OpenMode.ForWrite);
                    // Find the center pole on SpiralPole layer
                    foreach (ObjectId id in btr)
                    {
                        var solid = tr.GetObject(id, OpenMode.ForRead) as Solid3d;
                        if (solid != null && solid.Layer == "SpiralPole")
                        {
                            // Create an in-place copy
                            var idCollection = new ObjectIdCollection { id };
                            var mapping = new IdMapping();
                            db.DeepCloneObjects(idCollection, btr.ObjectId, mapping, false);
                            ed.WriteMessage("\nCenter pole duplicated successfully.");
                            tr.Commit();
                            return;
                        }
                    }
                    ed.WriteMessage("\nNo center pole found on SpiralPole layer.");
                    tr.Commit();
                }
            }
            catch (System.Exception ex)
            {
                ed.WriteMessage($"\nCenter pole duplication failed: {ex.Message}");
            }
        }
    }
}