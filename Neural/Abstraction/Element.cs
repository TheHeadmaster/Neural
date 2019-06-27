using System;
using System.Collections.Generic;
using System.Text;

namespace Neural.Abstraction
{
    /// <summary>
    /// Represents an html element, such as div, p, or text.
    /// </summary>
    public abstract class Element
    {
        public string TagName { get; set; }
    }
}