#region License

// Copyright 2005-2019 Paul Kohler (https://github.com/paulkohler/minisqlquery). All rights reserved.
// This source code is made available under the terms of the GNU Lesser General Public License v3.0
// https://github.com/paulkohler/minisqlquery/blob/master/LICENSE
#endregion

using System.Globalization;
using System.Windows.Forms;

namespace MiniSqlQuery.Core.Commands
{
    /// <summary>
    /// 	The convert text to title case command.
    /// </summary>
    public class ConvertTextToTitleCaseCommand
        : CommandBase
    {
        /// <summary>
        /// 	Initializes a new instance of the <see cref = "ConvertTextToTitleCaseCommand" /> class.
        /// </summary>
        public ConvertTextToTitleCaseCommand()
            : base("Convert to 'Title Case' text")
        {
            ShortcutKeys = Keys.Control | Keys.Alt | Keys.U;
        }

        /// <summary>
        /// 	Gets a value indicating whether Enabled.
        /// </summary>
        /// <value>The enabled state.</value>
        public override bool Enabled
        {
            get { return HostWindow.ActiveChildForm as IEditor != null; }
        }

        /// <summary>
        /// 	Execute the command.
        /// </summary>
        public override void Execute()
        {
            var editor = ActiveFormAsEditor;
            if (Enabled && editor.SelectedText.Length > 0)
            {
                editor.InsertText(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(editor.SelectedText));
            }
        }
    }
}