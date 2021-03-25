using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlUniqueWords.Core
{
    /// <summary>
    /// Interface of html resources
    /// </summary>
    public interface IHtml
    {
        /// <summary>
        /// File source
        /// </summary>
        string Source { get; }
        /// <summary>
        /// Getting text from html
        /// </summary>
        string GetText();

    }
}
