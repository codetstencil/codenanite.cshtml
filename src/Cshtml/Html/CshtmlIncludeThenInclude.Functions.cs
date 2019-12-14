using System.Windows.Forms;
using ZeraSystems.CodeNanite.Expansion;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class CshtmlIncludeThenInclude
    {
        private void MainFunction()
        {
            var frm = new frmSelectEntities(SchemaItem, Expander, null)
            {
                Text = "Configure Related table to include", Url = null
            };
            if (frm.ShowDialog() == DialogResult.OK)
            {

            }
                //return frm.SchemaString;
            //else
                //return null;
        }
    }
}