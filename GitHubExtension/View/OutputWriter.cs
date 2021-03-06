﻿// **********************************************************************************
// The MIT License (MIT)
// 
// Copyright (c) 2014 Rob Prouse
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 
// **********************************************************************************

using System.ComponentModel.Composition;
using Alteridem.GitHub.Logging;
using Microsoft.VisualStudio.Utilities;
using Tvl.VisualStudio.OutputWindow.Interfaces;

namespace Alteridem.GitHub.Extension.View
{
    public class OutputWriter : BaseOutputWriter
    {
        public const string GitHubOutputWindowPaneName = "GitHub";

#pragma warning disable 169 // The field 'fieldName' is never used
        [Export]
        [Name(GitHubOutputWindowPaneName)]
        private static OutputWindowDefinition GitHubOutputWindowDefinition;
#pragma warning restore 169

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        protected override void WriteMessage(string message)
        {
            var pane = Factory.Get<IOutputWindowPane>();
            if (pane != null)
                pane.WriteLine(message);
        }

        /// <summary>
        /// Shows the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        protected override void ShowMessage(string message)
        {
            VisualStudioMessageBox.Show(message);
        }
    }
}