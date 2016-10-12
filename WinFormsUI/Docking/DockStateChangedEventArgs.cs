using System;

namespace WeifenLuo.WinFormsUI.Docking
{
    public class DockStateChangedEventArgs : EventArgs
    {
        public DockState OldState { get; private set; }

        public DockState NewState { get; private set; }

        public DockStateChangedEventArgs(DockState oldState, DockState newState)
        {
            OldState = oldState;
            NewState = newState;
        }
    }
}
