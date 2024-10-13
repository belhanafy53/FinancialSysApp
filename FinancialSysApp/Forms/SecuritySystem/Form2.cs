﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Nodes.Operations;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.Utils.Drawing;

namespace FinancialSysApp.Forms.SecuritySystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        RepositoryItemCheckEdit checkEdit;
        private void Form2_Load(object sender, EventArgs e)
        {
            checkEdit = (RepositoryItemCheckEdit)treeList1.RepositoryItems.Add("CheckEdit");
            new DevExpress.XtraTreeList.Design.XViews(treeList1);
            treeList1.OptionsSelection.MultiSelect = true;
        }
        protected void DrawCheckBox(GraphicsCache cache, RepositoryItemCheckEdit edit, Rectangle r, bool Checked)
        {
            DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo info;
            DevExpress.XtraEditors.Drawing.CheckEditPainter painter;
            DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs args;
            info = edit.CreateViewInfo() as DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo;
            painter = edit.CreatePainter() as DevExpress.XtraEditors.Drawing.CheckEditPainter;
            info.EditValue = Checked;
            info.Bounds = r;
            info.CalcViewInfo();
            args = new DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, cache, r);
            painter.Draw(args);
        }

        private void treeList1_CustomDrawColumnHeader(object sender, CustomDrawColumnHeaderEventArgs e)
        {
            if (e.Column != null && e.Column.VisibleIndex == 0)
            {
                Rectangle checkRect = new Rectangle(e.Bounds.Left + 3, e.Bounds.Top + 3, 12, 12);
                ColumnInfo info = (ColumnInfo)e.ObjectArgs;
                if (info.CaptionRect.Left < 30)
                    info.CaptionRect = new Rectangle(new Point(info.CaptionRect.Left + 15, info.CaptionRect.Top), info.CaptionRect.Size);
                e.Painter.DrawObject(info);

                DrawCheckBox(e.Cache, checkEdit, checkRect, IsAllSelected(sender as TreeList));
                e.Handled = true;
            }
        }
        private bool IsAllSelected(TreeList tree)
        {
            return tree.Selection.Count > 0 && tree.Selection.Count == tree.AllNodesCount;
        }

        private void treeList1_MouseUp(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            Point pt = new Point(e.X, e.Y);
            TreeListHitInfo hit = tree.CalcHitInfo(pt);
            if (hit.Column != null)
            {
                ColumnInfo info = tree.ViewInfo.ColumnsInfo[hit.Column];
                Rectangle checkRect = new Rectangle(info.Bounds.Left + 3, info.Bounds.Top + 3, 12, 12);
                if (checkRect.Contains(pt))
                {
                    EmbeddedCheckBoxChecked(tree);
                    throw new DevExpress.Utils.HideException();
                }
            }
        }
        private void EmbeddedCheckBoxChecked(TreeList tree)
        {
            if (IsAllSelected(tree))
                tree.Selection.Clear();
            else
                SelectAll(tree);
        }

        class SelectNodeOperation : TreeListOperation
        {
            public override void Execute(TreeListNode node)
            {
                node.Selected = true;
            }
        }
        private void SelectAll(TreeList tree)
        {
            tree.BeginUpdate();
            tree.NodesIterator.DoOperation(new SelectNodeOperation());
            tree.EndUpdate();
        }
        private void treeList1_SelectionChanged(object sender, EventArgs e)
        {
            treeList1.InvalidateColumnPanel();
        }
    }
}
