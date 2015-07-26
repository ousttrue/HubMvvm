using HubMvvm.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
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
        Task m_task;
        Data.SampleDataGroup m_section3;
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(String propertyname)
        {
            var tmp = PropertyChanged;
            if (tmp == null) return;
            tmp(this, new PropertyChangedEventArgs(propertyname));
        }
        public Data.SampleDataGroup Section3Items
        {
            get
            {
                if(m_section3== null && m_task==null)
                {
                    m_task=Data.SampleDataSource.GetGroupAsync("Group-4").ContinueWith(x =>
                    {
                        Section3Items = x.Result;
                    }, TaskScheduler.FromCurrentSynchronizationContext());
                }
                return m_section3;
            }
            private set
            {
                if (m_section3 == value) return;
                m_section3 = value;
                RaisePropertyChanged("Section3Items");
            }
        }
        #region NavigateToSection
        RelayCommand<HubSectionHeaderClickEventArgs> m_navigateToSectionCommand;
        public ICommand NavigateToSectionCommand
        {
            get
            {
                if (m_navigateToSectionCommand == null)
                {
                    m_navigateToSectionCommand = new RelayCommand<HubSectionHeaderClickEventArgs>(NavigateToSection);
                }
                return m_navigateToSectionCommand;
            }
        }

        void NavigateToSection(HubSectionHeaderClickEventArgs e)
        {
            HubSection section = e.Section;
            var group = section.DataContext;
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
