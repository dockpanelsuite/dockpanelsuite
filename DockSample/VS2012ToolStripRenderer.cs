using System.Windows.Forms;

namespace Lextm.SharpSnmpLib
{
    internal class VS2012ToolStripRenderer : ToolStripProfessionalRenderer
    {
        public VS2012ToolStripRenderer()
            : base(new VS2012ColorTable())
        {
        }
    }
}