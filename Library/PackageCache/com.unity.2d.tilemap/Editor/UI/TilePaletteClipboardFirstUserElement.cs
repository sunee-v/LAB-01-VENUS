﻿using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.Tilemaps
{
    [UxmlElement]
    public partial class TilePaletteClipboardFirstUserElement : VisualElement
    {
        private static readonly string ussClassName = "unity-tilepalette-clipboard-firstuser-element";
        private static readonly string k_Name = L10n.Tr("Tile Palette Clipboard First User Element");

        static class Styles
        {
            public static readonly string emptyProjectTopInfo = L10n.Tr("Drag Tile, Sprite, Texture (Sprite type) asset/s here to");
            public static readonly string emptyProjectLeftInfo = L10n.Tr("create a new ");
            public static readonly string emptyProjectRightInfo = L10n.Tr(" Tile Palette");

            public static readonly string whiteboxDropdownInfo = L10n.Tr("Create a new Whitebox Tile Palette");
            public static readonly string whiteboxAlternateInfo = L10n.Tr("Alternatively, get started quickly with a Whitebox Tile Palette");
            public static readonly string whiteboxButtonInfo = L10n.Tr("Create");
        }

        [SerializeField]
        private GridPaletteUtility.GridPaletteType m_FirstUserPaletteType = GridPaletteUtility.GridPaletteType.Rectangle;

        public TilePaletteClipboardFirstUserElement()
        {
            AddToClassList(ussClassName);

            name = k_Name;
            TilePaletteOverlayUtility.SetStyleSheet(this);

            var ve = new VisualElement();
            ve.style.flexDirection = FlexDirection.Column;
            ve.style.alignItems = Align.Center;

            var he1 = new Label();
            he1.style.flexDirection = FlexDirection.Row;
            he1.text = Styles.emptyProjectTopInfo;

            var he2 = new VisualElement();
            he2.style.flexDirection = FlexDirection.Row;

            var left = new Label();
            left.text = Styles.emptyProjectLeftInfo;

            var enumField = new EnumField(m_FirstUserPaletteType);
            enumField.RegisterCallback<ChangeEvent<GridPaletteUtility.GridPaletteType>>(OnFirstUserPaletteTypeChanged);

            var right = new Label();
            right.text = Styles.emptyProjectRightInfo;

            he2.Add(left);
            he2.Add(enumField);
            he2.Add(right);

            ve.Add(he1);
            ve.Add(he2);
            Add(ve);
        }

        private void OnFirstUserPaletteTypeChanged(ChangeEvent<GridPaletteUtility.GridPaletteType> evt)
        {
            m_FirstUserPaletteType = evt.newValue;
        }
    }
}
