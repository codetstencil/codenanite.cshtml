using System.Collections.Generic;
using System.Linq;
using ZeraSystems.CodeNanite.Expansion;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public partial class RazorIncludeFkColumns : ExpansionBase
    {
        private string _table;
        private List<ISchemaItem> _foreignKeys;

        private void MainFunction()
        {
            _table = Input.Singularize();
            _foreignKeys = GetForeignKeysInTable(_table);
            AppendText();
            AppendText(GetColumnsWithCommas());
        }

        private string GetColumnsWithCommas()
        {
            var text = "";
            var columns = GetForeignKeysInTable(_table);
            if (columns.Any())
            {
                text = string.Join(string.Empty, columns
                    .Where(p => !p.IsPrimaryKey)
                    .Where(s => s.TableName != s.RelatedTable)
                    .Select(p => ".Include(s => s." + p.RelatedTable +")"));
            }
            return text.TrimEnd('\r', '\n');
        }
    }
}

//s => s.CourseID, s => s.DepartmentID, s => s.Title, s => s.Credits)

//.Include(c => c.Department)
//.Include(c => c.Department)