using System;
using CodeHub.Core.ViewModels.Source;
using CodeHub.iOS.TableViewSources;
using ReactiveUI;
using UIKit;
using CodeHub.iOS.ViewComponents;

namespace CodeHub.iOS.Views.Source
{
    public class SourceTreeView : BaseTableViewController<SourceTreeViewModel>
    {
        public SourceTreeView()
        {
            EmptyView = new Lazy<UIView>(() =>
                new EmptyListView(Octicon.FileDirectory.ToImage(64f), "This directory is empty."));

            this.WhenAnyValue(x => x.ViewModel.TrueBranch, y => y.ViewModel.PushAccess, z => z.ViewModel.GoToAddFileCommand)
                .Subscribe(x =>
                {
                    if (x.Item1 && x.Item2.HasValue && x.Item2.Value && x.Item3 != null)
                        NavigationItem.RightBarButtonItem = x.Item3.ToBarButtonItem(UIBarButtonSystemItem.Add);
                    else
                        NavigationItem.RightBarButtonItem = null;
                });
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.Source = new SourceContentTableViewSource(TableView, ViewModel.Content);
        }
    }
}

