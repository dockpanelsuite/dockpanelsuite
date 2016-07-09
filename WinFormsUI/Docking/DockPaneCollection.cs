using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking
{
    public class DockPaneCollection : ReadOnlyCollection<DockPane>
    {
        internal DockPaneCollection()
            : base(new List<DockPane>())
        {
        }

        internal int Add(DockPane pane)
        {
            if (Items.Contains(pane))
                return Items.IndexOf(pane);

            Items.Add(pane);
            return Count - 1;
        }

        internal void AddAt(DockPane pane, int index)
        {
            if (index < 0 || index > Items.Count - 1)
                return;
            
            if (Contains(pane))
                return;

            Items.Insert(index, pane);
        }

        internal void Dispose()
        {
            if (PatchController.EnableNestedDisposalFix == true)
            {
                List<DockPane> collection = new List<DockPane>(Items);
                foreach (var dockPane in collection)
                {
                    dockPane.Close();
                }

                collection.Clear();
                return;
            }

            for (int i=Count - 1; i>=0; i--)
                this[i].Close();
        }

        internal void Remove(DockPane pane)
        {
            Items.Remove(pane);
        }
    }
}
