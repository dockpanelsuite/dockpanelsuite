using System.Windows.Forms;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking
{
    partial class DockPanel
    {
        /// <summary>
        /// DragHandlerBase is the base class for drag handlers. The derived class should:
        ///   1. Define its public method BeginDrag. From within this public BeginDrag method,
        ///      DragHandlerBase.BeginDrag should be called to initialize the mouse capture
        ///      and message filtering.
        ///   2. Override the OnDragging and OnEndDrag methods.
        /// </summary>
        public abstract class DragHandlerBase : NativeWindow, IMessageFilter
        {
            protected DragHandlerBase()
            {
            }

            protected abstract Control DragControl
            {
                get;
            }

            private Point m_startMousePosition = Point.Empty;
            protected Point StartMousePosition
            {
                get { return m_startMousePosition; }
                private set { m_startMousePosition = value; }
            }

            protected bool BeginDrag()
            {
                if (DragControl == null)
                    return false;

                StartMousePosition = Control.MousePosition;

                if (!Win32Helper.IsRunningOnMono)
                {
                    if (!NativeMethods.DragDetect(DragControl.Handle, StartMousePosition))
                    {
                        return false;
                    }
                }

                DragControl.FindForm().Capture = true;
                AssignHandle(DragControl.FindForm().Handle);
                if (PatchController.EnableActiveXFix == false)
                {
                    Application.AddMessageFilter(this);
                }

                return true;
            }

            protected abstract void OnDragging();

            protected abstract void OnEndDrag(bool abort);

            private void EndDrag(bool abort)
            {
                ReleaseHandle();

                if (PatchController.EnableActiveXFix == false)
                {
                    Application.RemoveMessageFilter(this);
                }

                DragControl.FindForm().Capture = false;

                OnEndDrag(abort);
            }

            bool IMessageFilter.PreFilterMessage(ref Message m)
            {
                if (PatchController.EnableActiveXFix == false)
                {
                    if (m.Msg == (int)Win32.Msgs.WM_MOUSEMOVE)
                        OnDragging();
                    else if (m.Msg == (int)Win32.Msgs.WM_LBUTTONUP)
                        EndDrag(false);
                    else if (m.Msg == (int)Win32.Msgs.WM_CAPTURECHANGED)
                        EndDrag(!Win32Helper.IsRunningOnMono);
                    else if (m.Msg == (int)Win32.Msgs.WM_KEYDOWN && (int)m.WParam == (int)Keys.Escape)
                        EndDrag(true);
                }

                return OnPreFilterMessage(ref m);
            }

            protected virtual bool OnPreFilterMessage(ref Message m)
            {
                if (PatchController.EnableActiveXFix == true)
                {
                    if (m.Msg == (int)Win32.Msgs.WM_MOUSEMOVE)
                        OnDragging();
                    else if (m.Msg == (int)Win32.Msgs.WM_LBUTTONUP)
                        EndDrag(false);
                    else if (m.Msg == (int)Win32.Msgs.WM_CAPTURECHANGED)
                        EndDrag(!Win32Helper.IsRunningOnMono);
                    else if (m.Msg == (int)Win32.Msgs.WM_KEYDOWN && (int)m.WParam == (int)Keys.Escape)
                        EndDrag(true);
                }

                return false;
            }

            protected sealed override void WndProc(ref Message m)
            {
                if (PatchController.EnableActiveXFix == true)
                {
                    //Manually pre-filter message, rather than using
                    //Application.AddMessageFilter(this).  This fixes
                    //the docker control for ActiveX objects
                    this.OnPreFilterMessage(ref m);
                }

                if (m.Msg == (int)Win32.Msgs.WM_CANCELMODE || m.Msg == (int)Win32.Msgs.WM_CAPTURECHANGED)
                    EndDrag(true);

                base.WndProc(ref m);
            }
        }

        public abstract class DragHandler : DragHandlerBase
        {
            private DockPanel m_dockPanel;

            protected DragHandler(DockPanel dockPanel)
            {
                m_dockPanel = dockPanel;
            }

            public DockPanel DockPanel
            {
                get { return m_dockPanel; }
            }

            private IDragSource m_dragSource;
            protected IDragSource DragSource
            {
                get { return m_dragSource; }
                set { m_dragSource = value; }
            }

            protected sealed override Control DragControl
            {
                get { return DragSource == null ? null : DragSource.DragControl; }
            }

            protected sealed override bool OnPreFilterMessage(ref Message m)
            {
                if ((m.Msg == (int)Win32.Msgs.WM_KEYDOWN || m.Msg == (int)Win32.Msgs.WM_KEYUP) &&
                    ((int)m.WParam == (int)Keys.ControlKey || (int)m.WParam == (int)Keys.ShiftKey))
                    OnDragging();

                return base.OnPreFilterMessage(ref m);
            }
        }
    }
}
