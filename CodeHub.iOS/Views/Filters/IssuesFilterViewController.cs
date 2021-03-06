//using MonoTouch.Dialog;
//using MonoTouch.UIKit;
//using CodeFramework.iOS.ViewControllers;
//using CodeFramework.Core.ViewModels;
//using CodeHub.Core.Filters;
//
//namespace CodeHub.iOS.Views.Filters
//{
//    public class IssuesFilterViewController : FilterViewController
//    {
//        private readonly string _user;
//        private readonly string _repo;
//        private IssuesFilterModel.MilestoneKeyValue _milestoneHolder;
//
//        private TrueFalseElement _open;
//        private StyledStringElement _milestone;
//        private EntryElement _labels, _mentioned, _creator, _assignee;
//        private EnumChoiceElement<IssuesFilterModel.Sort> _sort;
//        private TrueFalseElement _asc;
//
//        public IssuesFilterViewController(string user, string repo)
//        {
//            _user = user;
//            _repo = repo;
//        }
//
//        public override void ApplyButtonPressed()
//        {
//         //   _filterController.ApplyFilter(CreateFilterModel());
//        }
//
//        private IssuesFilterModel CreateFilterModel()
//        {
//            var model = new IssuesFilterModel();
//            model.Open = _open.Value;
//            model.Labels = _labels.Value;
//            model.SortType = _sort.Value;
//            model.Ascending = _asc.Value;
//            model.Mentioned = _mentioned.Value;
//            model.Creator = _creator.Value;
//            model.Assignee = _assignee.Value;
//            model.Milestone = _milestoneHolder;
//            return model;
//        }
//
//        private void RefreshMilestone()
//        {
//            if (_milestoneHolder == null)
//                _milestone.Value = "None";
//            else
//                _milestone.Value = _milestoneHolder.Name;
//            Root.Reload(_milestone, UITableViewRowAnimation.None);
//        }
//
//        public override void ViewDidLoad()
//        {
//            base.ViewDidLoad();
//            var model = _filterController.Filter.Clone();
//
//            //Load the root
//            var root = new RootElement(Title) {
//                new Section("Filter") {
//                    (_open = new TrueFalseElement("Open?", model.Open)),
//                    (_labels = new InputElement("Labels", "bug,ui,@user", model.Labels) { TextAlignment = UITextAlignment.Right, AutocorrectionType = UITextAutocorrectionType.No, AutocapitalizationType = UITextAutocapitalizationType.None }),
//                    (_mentioned = new InputElement("Mentioned", "User", model.Mentioned) { TextAlignment = UITextAlignment.Right, AutocorrectionType = UITextAutocorrectionType.No, AutocapitalizationType = UITextAutocapitalizationType.None }),
//                    (_creator = new InputElement("Creator", "User", model.Creator) { TextAlignment = UITextAlignment.Right, AutocorrectionType = UITextAutocorrectionType.No, AutocapitalizationType = UITextAutocapitalizationType.None }),
//                    (_assignee = new InputElement("Assignee", "User", model.Assignee) { TextAlignment = UITextAlignment.Right, AutocorrectionType = UITextAutocorrectionType.No, AutocapitalizationType = UITextAutocapitalizationType.None }),
//                    (_milestone = new StyledStringElement("Milestone", "None", UITableViewCellStyle.Value1)),
//                },
//                new Section("Order By") {
//                    (_sort = CreateEnumElement("Field", model.SortType)),
//                    (_asc = new TrueFalseElement("Ascending", model.Ascending))
//                },
//                new Section(string.Empty, "Saving this filter as a default will save it only for this repository.") {
//                    new StyledStringElement("Save as Default", () =>{
//                        _filterController.ApplyFilter(CreateFilterModel(), true);
//                        CloseViewController();
//                    }, Images.Size) { Accessory = UITableViewCellAccessory.None },
//                }
//            };
//
//            RefreshMilestone();
//
//            _milestone.Accessory = UITableViewCellAccessory.DisclosureIndicator;
//            _milestone.Tapped += () => {
//                var ctrl = new IssueMilestonesFilterViewController(_user, _repo, _milestoneHolder != null);
//
//                ctrl.MilestoneSelected = (title, num, val) => {
//                    if (title == null && num == null && val == null)
//                        _milestoneHolder = null;
//                    else
//                        _milestoneHolder = new IssuesFilterModel.MilestoneKeyValue { Name = title, Value = val, IsMilestone = num.HasValue };
//                    RefreshMilestone();
//                    NavigationController.PopViewControllerAnimated(true);
//                };
//                NavigationController.PushViewController(ctrl, true);
//            };
//
//            Root = root;
//        }
//    }
//}
//
