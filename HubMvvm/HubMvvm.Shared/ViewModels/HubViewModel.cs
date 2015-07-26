using HubMvvm.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace HubMvvm.ViewModels
{
    public class Section
    {
        public String Title
        {
            get;
            set;
        }

        public String SubTitle
        {
            get;
            set;
        }

        public String Body
        {
            get;
            set;
        }
    }

    public class HubViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(String propertyname)
        {
            var tmp = PropertyChanged;
            if (tmp == null) return;
            tmp(this, new PropertyChangedEventArgs(propertyname));
        }

        IEnumerable<Data.SampleDataGroup> m_groups;
        Task m_groupsTask;
        public IEnumerable<Data.SampleDataGroup> Groups
        {
            get
            {
                if (m_groups == null && m_groupsTask == null)
                {
                    m_groupsTask = Data.SampleDataSource.GetGroupsAsync().ContinueWith(x =>
                    {
                        Groups = x.Result;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                return m_groups;
            }
            set
            {
                if (m_groups == value) return;
                m_groups = value;
                RaisePropertyChanged("Groups");
                RaisePropertyChanged("Section1Items");
                RaisePropertyChanged("Section2Items");
                RaisePropertyChanged("Section3Items");
                RaisePropertyChanged("Section4Items");
            }
        }

        #region Section1
        Section m_section1;
        public Section Section1
        {
            get
            {
                if (m_section1 == null)
                {
                    m_section1 = new Section
                    {
                        SubTitle = "謎のXXX. Lorem ipsum dolor sit nonumy sed consectetuer ising elit, sed diam",
                        Body= "Lorem ipsum dolor sit amet, consectetuer ising elit, sed diam nonummy nibh uismod tincidunt ut laoreet suscipit lobortis ni ut wisi quipexerci quis consequat minim veniam, quis nostrud exerci tation ullam corper. Lorem ipsum dolor sit amet, consectetuer ising elit, sed diam nonummy nibh uismod tincidunt ut laoreet suscipit lobortis ni ut wisi quipexerci quis consequat minim veniam, quis nostrud exerci tation ullam corper. ",
                    };
                }
                return m_section1;
            }
        }
        #endregion

        #region Section2
        Section m_section2;
        public Section Section2
        {
            get
            {
                if(m_section2== null)
                {
                    m_section2 = new Section
                    {
                        Title= "Item Title",
                        SubTitle= "Quisque in porta lorem dolor amet sed consectetuer ising elit, sed diam non my nibh uis mod wisi quip.",
                        Body= "Lorem ipsum dolor sit amet, consectetuer ising elit, sed diam nonummy nibh uismod tincidunt ut laoreet suscipit lobortis ni ut wisi quipexerci quis consequat minim veniam, quis nostrud exerci tation ullam corper. Lorem ipsum dolor sit amet, consectetuer ising elit, sed diam nonummy nibh uismod tincidunt ut laoreet suscipit lobortis ni ut wisi quipexerci quis consequat minim veniam, quis nostrud exerci tation ullam corper.",
                    };
                }
                return m_section2;
            }
        }
        #endregion

        #region Section3
        public Data.SampleDataGroup Section3Items
        {
            get
            {
                try
                {
                    return Groups.Skip(2).First();
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }
        #region NavigateToSection
        RelayCommand<HubSectionHeaderClickEventArgs> m_navigateFromHubSectionCommand;
        public ICommand NavigateFromHubSectionCommand
        {
            get
            {
                if (m_navigateFromHubSectionCommand == null)
                {
                    m_navigateFromHubSectionCommand = new RelayCommand<HubSectionHeaderClickEventArgs>(NavigateToSection);
                }
                return m_navigateFromHubSectionCommand;
            }
        }
        void NavigateToSection(HubSectionHeaderClickEventArgs e)
        {
            var group = e.Section.DataContext;
            NavigationService.Instance.Navigate(typeof(Views.SectionPage), group);
        }

        RelayCommand<ItemClickEventArgs> m_navigateFromListViewToSectionCommand;
        public ICommand NavigateFromListViewToSectionCommand
        {
            get
            {
                if (m_navigateFromListViewToSectionCommand == null)
                {
                    m_navigateFromListViewToSectionCommand = new RelayCommand<ItemClickEventArgs>(NavigateFromListViewToSection);
                }
                return m_navigateFromListViewToSectionCommand;
            }
        }
        void NavigateFromListViewToSection(ItemClickEventArgs e)
        {
            var group = e.ClickedItem;
            NavigationService.Instance.Navigate(typeof(Views.SectionPage), group);
        }
        #endregion
        #endregion

        #region Section4
        #endregion

        public HubViewModel()
        {
        }
    }
}
