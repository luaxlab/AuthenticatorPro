﻿using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using AuthenticatorPro.Droid.List;

namespace AuthenticatorPro.Droid.Fragment
{
    internal class EditCategoryMenuBottomSheet: BottomSheet
    {
        public event EventHandler<int> ClickRename;
        public event EventHandler<int> ClickSetDefault;
        public event EventHandler<int> ClickDelete;

        private readonly int _itemPosition;
        private readonly bool _isDefault;


        public EditCategoryMenuBottomSheet(int itemPosition, bool isDefault)
        {
            RetainInstance = true;
            _itemPosition = itemPosition;
            _isDefault = isDefault;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.sheetMenu, container, false);

            var menu = view.FindViewById<RecyclerView>(Resource.Id.listMenu);
            SetupMenu(menu, new List<SheetMenuItem>
            {
                new(Resource.Drawable.ic_action_edit, Resource.String.rename, delegate
                {
                    ClickRename(this, _itemPosition);
                }),
                new(Resource.Drawable.ic_action_star, _isDefault ? Resource.String.clearDefault : Resource.String.setAsDefault, delegate
                {
                    ClickSetDefault(this, _itemPosition);
                }),
                new(Resource.Drawable.ic_action_delete, Resource.String.delete, delegate
                {
                    ClickDelete(this, _itemPosition);
                }, null, true)
            });

            return view;
        }
    }
}