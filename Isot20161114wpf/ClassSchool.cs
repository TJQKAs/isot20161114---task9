using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isot20161114wpf
{
    public class ClassSchool:INotifyPropertyChanged
    {
        public ClassSchool()
        {
            //SchoolList = fillUniversity();
            //FilterSchoolList = fillUniversity();
        }

        private int _min_score;

        public int MinScore
        {
            get { return _min_score; }
            set
            {
                _min_score = value;
                OnPropertyChanged("MinScore");
            }
        }

        private int _stud_numb;

        public int StudNumb
        {
            get { return _stud_numb; }
            set { _stud_numb = value;
                OnPropertyChanged("StudNumb");
            }
        }

        private int _stud_count;

        public int StudCount
        {
            get { return _stud_count; }
            set
            {
                _stud_count = value;
                OnPropertyChanged("StudCount");
            }
        }


        private int _count_success_group;

        public int CountSuccessGroup
        {
            get { return _count_success_group; }
            set { _count_success_group = value;
                OnPropertyChanged("CountSuccessGroup");
            }
        }

        private int _count_succes_stud;

        public int CountSuccessStud
        {
            get { return _count_succes_stud; }
            set { _count_succes_stud = value;
                OnPropertyChanged("CountSuccessStud");
            }
        }



        private int _number_of_classes;
        public int NumberOfClasses
        {
            get { return _number_of_classes; }
            set { _number_of_classes = value;
                OnPropertyChanged("NumberOfClasses");
                }
        }


        private ObservableCollection<string> _school_list;

        public ObservableCollection<string> SchoolList
        {
            get { return _school_list; }
            set { _school_list = value; 
            OnPropertyChanged("SchoolList");
          }
        }


        private ObservableCollection<string> _filter_school_list;

        public ObservableCollection<string> FilterSchoolList
        {
            get { return _filter_school_list; }
            set { _filter_school_list = value;
                OnPropertyChanged("FilterSchoolList");
            }
        }

        private RelayCommand addFileCommand;

        public RelayCommand AddFileCommand
        {
            get
            {
                return addFileCommand ??

                   

                  (addFileCommand = new RelayCommand(param =>
                  {
                      try
                      {
                          Task task = new Task(() =>
                          {

                              int avar = 0;
                          int bvar = 0; 
                          SchoolList = fillUniversity(out avar, out bvar);
                          StudCount = avar;
                          CountSuccessStud = bvar;
                          Filter.NoteFile(SchoolList, "full.txt");
                          //CountSuccessGroup = Filter.GetSomeStatData(FilterSchoolList);
                          FilterSchoolList = Filter.WriteFilterCopyFile(MinScore, "full.txt", "short.txt");
                          });
                          task.Start();

                      }
                      catch (Exception ex)
                      {
                         
                      }
                  }));



            }
        }
        public ObservableCollection<string> fillUniversity(out int allstud, out int passStud)
        {
            int xvar = 0;
            allstud = 0;
            passStud = 0;
            ObservableCollection<string> clshool = new ObservableCollection<string>();
            Random rnd = new Random();
            while (xvar < NumberOfClasses)
            {
                int stud = rnd.Next(1, StudNumb);
                int pass = rnd.Next(0, stud);
                passStud = passStud + pass;
                double successStud = Math.Round((Double)pass / (Double)stud * 100, 2);
                string student = String.Format("Класс № {0}, количество студентов {1}, студенты сдавшие экзамен {2} %", xvar+1, stud, successStud);
                clshool.Add(student);
                xvar++;
                allstud = allstud + stud;            
            }
            return clshool;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
