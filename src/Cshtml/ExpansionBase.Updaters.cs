using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZeraSystems.CodeStencil.Contracts;

namespace ZeraSystems.CodeNanite.Cshtml
{
    public abstract partial class ExpansionBase
    {
        #region Expander
        public void UpdateExpander(IExpander expander)
        {
            var row = _expander
                .Where((x => x.ExpansionLabel == expander.ExpansionLabel))
                .FirstOrDefault();

            if (row != null && row.UpdatedByNanite)    //We already have a matching item  
            {
                _expander.Remove(row);
            }
            expander.UpdatedByNanite = true;
            _expander.Add(expander);
        }

        public void ExpanderUpdater(string expansionString, string expansionlabel) => ExpanderUpdater(expansionString, expansionlabel, 0, false, string.Empty);

        public void ExpanderUpdater(bool expansionString, string expansionlabel)
        {
            ExpanderUpdater(Convert.ToInt32(expansionString).ToString(), expansionlabel, 0, false, string.Empty);
        }

        public void ExpanderUpdater(string expansionString, string expansionlabel, int expansionValue, bool isMultiple = false, string delim = "")
        {
            var expander = new ExpanderObject
            {
                ExpansionLabel = expansionlabel,
                ExpansionString = expansionString,
                ExpansionValue = expansionValue,
                IsMultiple = isMultiple,
                Delimiter = delim
            };
            UpdateExpander(expander);
        }
        #endregion

        #region SchemaItem

        public ISchemaItem SchemaItemUpdater(ISchemaItem schemaitem)
        {
            return UpdateSchemaItem(schemaitem);

            //MessageBox.Show(schemaitem.ParentId + ", " + schemaitem.TableName);
            //throw new NotImplementedException(schemaitem.ParentId+", "+schemaitem.TableName);
        }

        public ISchemaItem UpdateSchemaItem(ISchemaItem schemaItem)
        {
            try
            {
                var row = _schemaItem
                    .FirstOrDefault(x => x.TableName == schemaItem.TableName && x.ColumnName == schemaItem.ColumnName);

                //if (row != null && row.UpdatedByNanite)    //We already have a matching item  
                if (row != null)                //We already have a matching item  
                    _schemaItem.Remove(row);
                schemaItem.IsUpdatedByNanite = true;
                schemaItem.MaxLength = schemaItem.SchemaItemId;    //testing

                _schemaItem.Add(schemaItem);
                return row;
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }


        #endregion


    }
}
