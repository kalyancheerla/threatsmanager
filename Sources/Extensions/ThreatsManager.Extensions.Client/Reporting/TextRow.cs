﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace ThreatsManager.Extensions.Reporting
{
    /// <summary>
    /// A row for an List Item containing simple text.
    /// </summary>
    public class TextRow : ItemRow
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="label">Label of the Row.</param>
        /// <param name="text">Text to be shown.</param>
        /// <param name="textColor">[Optional] Color of the text. If missing, the default value will be used.</param>
        /// <param name="backColor">[Optional] Color of the background. If missing, the default value will be used.</param>
        public TextRow(string label, string text, KnownColor? textColor = null, KnownColor? backColor = null) :
            base(label)
        {
            Text = text;
            TextColor = textColor;
            BackColor = backColor;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="label">Label of the Row.</param>
        /// <param name="text">Text to be used if no LinkIds correspond to an actual object.</param>
        /// <param name="prefix">Prefix to compose the final text.</param>
        /// <param name="suffix">Suffix to compose the final text.</param>
        /// <param name="linkIds">Identifiers of items in a List to which the text should be linked to.</param>
        /// <param name="textColor">[Optional] Color of the text. If missing, the default value will be used.</param>
        /// <param name="backColor">[Optional] Color of the background. If missing, the default value will be used.</param>
        public TextRow(string label, string text, string prefix, string suffix, IEnumerable<Guid> linkIds, KnownColor? textColor = null, KnownColor? backColor = null) :
            this(label, text, textColor, backColor)
        {
            LinkIds = linkIds;
            Prefix = prefix;
            Suffix = suffix;
        }

        /// <summary>
        /// Flag specifying if the row should be visible or not.
        /// </summary>
        public override bool Visible => !string.IsNullOrWhiteSpace(Text);

        /// <summary>
        /// Text of the Row.
        /// </summary>
        /// <remarks>It is applied if no LinkID works.</remarks>
        public string Text { get; private set; }

        /// <summary>
        /// Prefix to compose the final text.
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        /// Suffix to compose the final text.
        /// </summary>
        public string Suffix { get; private set; }

        /// <summary>
        /// Color of the Text.
        /// </summary>
        public KnownColor? TextColor { get; private set; }

        /// <summary>
        /// Color of the Background.
        /// </summary>
        public KnownColor? BackColor { get; private set; }

        /// <summary>
        /// Identifier of items in a List to which the content of the cell should be linked to.
        /// </summary>
        /// <remarks>The Ids are listed in priority order: the first which is a match is applied.</remarks>
        public IEnumerable<Guid> LinkIds { get; private set; }
    }
}