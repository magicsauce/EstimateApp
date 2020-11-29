using System;
using System.Collections.Generic;
using System.Windows.Input;
using EstimateApp.Models;
using Xamarin.Forms;

namespace EstimateApp.ViewModels
{
    public class EappViewModel : BaseViewModel
    {
        public ICommand RemoveTicketManagementCommand { get; private set; }
        public ICommand AddTicketManagementCommand { get; private set; }

        public ICommand RemoveSelfTestCommand { get; private set; }
        public ICommand AddSelfTestCommand { get; private set; }

        public ICommand RemovePeerReviewCommand { get; private set; }
        public ICommand AddPeerReviewCommand { get; private set; }

        public ICommand RemoveQACommand { get; private set; }
        public ICommand AddQACommand { get; private set; }

        public ICommand RemoveDeploymentCommand { get; private set; }
        public ICommand AddDeploymentCommand { get; private set; }

        public ICommand RemoveAdjustmentCommand { get; private set; }
        public ICommand AddAdjustmentCommand { get; private set; }

        public EappViewModel()
        {
            Title = "Eapp";

            SetDefaultValue();

            RemoveTicketManagementCommand = new Command(RemoveTicketManagement);
            AddTicketManagementCommand = new Command(AddTicketManagement);

            RemoveSelfTestCommand = new Command(RemoveSelfTest);
            AddSelfTestCommand = new Command(AddSelfTest);

            RemovePeerReviewCommand = new Command(RemovePeerReview);
            AddPeerReviewCommand = new Command(AddPeerReview);

            RemoveQACommand = new Command(RemoveQA);
            AddQACommand = new Command(AddQA);

            RemoveDeploymentCommand = new Command(RemoveDeployment);
            AddDeploymentCommand = new Command(AddDeployment);

            RemoveAdjustmentCommand = new Command(RemoveAdjustment);
            AddAdjustmentCommand = new Command(AddAdjustment);

            IsAddButtonTMVisible = false;
            IsRemoveButtonTMVisible = true;
            IsRowTMVisible = true;

            IsAddButtonSTVisible = false;
            IsRemoveButtonSTVisible = true;
            IsRowSTVisible = true;

            IsAddButtonPRVisible = false;
            IsRemoveButtonPRVisible = true;
            IsRowPRVisible = true;

            IsAddButtonQAVisible = false;
            IsRemoveButtonQAVisible = true;
            IsRowQAVisible = true;

            IsAddButtonDeploymentVisible = false;
            IsRemoveButtonDeploymentVisible = true;
            IsRowDeploymentVisible = true;

            IsAddButtonAdjustmentVisible = false;
            IsRemoveButtonAdjustmentVisible = true;
            IsRowAdjustmentVisible = true;
        }

        private bool isRemoveButtonAdjustmentVisible;
        public bool IsRemoveButtonAdjustmentVisible
        {
            get { return isRemoveButtonAdjustmentVisible; }
            set
            {
                SetProperty(ref isRemoveButtonAdjustmentVisible, value);
            }
        }

        private bool isAddButtonAdjustmentVisible;
        public bool IsAddButtonAdjustmentVisible
        {
            get { return isAddButtonAdjustmentVisible; }
            set
            {
                SetProperty(ref isAddButtonAdjustmentVisible, value);
            }
        }

        private bool isRowAdjustmentVisible;
        public bool IsRowAdjustmentVisible
        {
            get { return isRowAdjustmentVisible; }
            set
            {
                SetProperty(ref isRowAdjustmentVisible, value);
            }
        }

        private void RemoveAdjustment()
        {
            IsRemoveButtonAdjustmentVisible = false;
            IsAddButtonAdjustmentVisible = true;
            IsRowAdjustmentVisible = false;

            Adjustments = 0;
            CalculateLOE();
        }

        private void AddAdjustment()
        {
            IsRemoveButtonAdjustmentVisible = true;
            IsAddButtonAdjustmentVisible = false;
            IsRowAdjustmentVisible = true;

            CalculatePercentage();
            CalculateLOE();
        }

        private bool isRemoveButtonDeploymentVisible;
        public bool IsRemoveButtonDeploymentVisible
        {
            get { return isRemoveButtonDeploymentVisible; }
            set
            {
                SetProperty(ref isRemoveButtonDeploymentVisible, value);
            }
        }

        private bool isAddButtonDeploymentVisible;
        public bool IsAddButtonDeploymentVisible
        {
            get { return isAddButtonDeploymentVisible; }
            set
            {
                SetProperty(ref isAddButtonDeploymentVisible, value);
            }
        }

        private bool isRowDeploymentVisible;
        public bool IsRowDeploymentVisible
        {
            get { return isRowDeploymentVisible; }
            set
            {
                SetProperty(ref isRowDeploymentVisible, value);
            }
        }

        private void RemoveDeployment()
        {
            IsRemoveButtonDeploymentVisible = false;
            IsAddButtonDeploymentVisible = true;
            IsRowDeploymentVisible = false;

            Deployment = 0;
            CalculateLOE();
        }

        private void AddDeployment()
        {
            IsRemoveButtonDeploymentVisible = true;
            IsAddButtonDeploymentVisible = false;
            IsRowDeploymentVisible = true;

            CalculatePercentage();
            CalculateLOE();
        }

        private bool isRemoveButtonQAVisible;
        public bool IsRemoveButtonQAVisible
        {
            get { return isRemoveButtonQAVisible; }
            set
            {
                SetProperty(ref isRemoveButtonQAVisible, value);
            }
        }

        private bool isAddButtonQAVisible;
        public bool IsAddButtonQAVisible
        {
            get { return isAddButtonQAVisible; }
            set
            {
                SetProperty(ref isAddButtonQAVisible, value);
            }
        }

        private bool isRowQAVisible;
        public bool IsRowQAVisible
        {
            get { return isRowQAVisible; }
            set
            {
                SetProperty(ref isRowQAVisible, value);
            }
        }

        private void RemoveQA()
        {
            IsRemoveButtonQAVisible = false;
            IsAddButtonQAVisible = true;
            IsRowQAVisible = false;

            QaTest = 0;
            CalculateLOE();
        }

        private void AddQA()
        {
            IsRemoveButtonQAVisible = true;
            IsAddButtonQAVisible = false;
            IsRowQAVisible = true;

            CalculatePercentage();
            CalculateLOE();
        }

        private bool isRemoveButtonPRVisible;
        public bool IsRemoveButtonPRVisible
        {
            get { return isRemoveButtonPRVisible; }
            set
            {
                SetProperty(ref isRemoveButtonPRVisible, value);
            }
        }

        private bool isAddButtonPRVisible;
        public bool IsAddButtonPRVisible
        {
            get { return isAddButtonPRVisible; }
            set
            {
                SetProperty(ref isAddButtonPRVisible, value);
            }
        }

        private bool isRowPRVisible;
        public bool IsRowPRVisible
        {
            get { return isRowPRVisible; }
            set
            {
                SetProperty(ref isRowPRVisible, value);
            }
        }

        private void RemovePeerReview()
        {
            IsRemoveButtonPRVisible = false;
            IsAddButtonPRVisible = true;
            IsRowPRVisible = false;

            PeerReview = 0;
            CalculateLOE();
        }

        private void AddPeerReview()
        {
            IsRemoveButtonPRVisible = true;
            IsAddButtonPRVisible = false;
            IsRowPRVisible = true;

            CalculatePercentage();
            CalculateLOE();
        }

        private bool isRemoveButtonSTVisible;
        public bool IsRemoveButtonSTVisible
        {
            get { return isRemoveButtonSTVisible; }
            set
            {
                SetProperty(ref isRemoveButtonSTVisible, value);
            }
        }

        private bool isAddButtonSTVisible;
        public bool IsAddButtonSTVisible
        {
            get { return isAddButtonSTVisible; }
            set
            {
                SetProperty(ref isAddButtonSTVisible, value);
            }
        }

        private bool isRowSTVisible;
        public bool IsRowSTVisible
        {
            get { return isRowSTVisible; }
            set
            {
                SetProperty(ref isRowSTVisible, value);
            }
        }

        private void AddSelfTest()
        {
            IsRemoveButtonSTVisible = true;
            IsAddButtonSTVisible = false;
            IsRowSTVisible = true;

            CalculatePercentage();
            CalculateLOE();
        }

        private void RemoveSelfTest()
        {
            IsRemoveButtonSTVisible = false;
            IsAddButtonSTVisible = true;
            IsRowSTVisible = false;

            SelfTest = 0;
            CalculateLOE();
        }

        private bool isRemoveButtonTMVisible;
        public bool IsRemoveButtonTMVisible
        {
            get { return isRemoveButtonTMVisible; }
            set
            {
                SetProperty(ref isRemoveButtonTMVisible, value);
            }
        }

        private bool isAddButtonTMVisible;
        public bool IsAddButtonTMVisible
        {
            get { return isAddButtonTMVisible; }
            set
            {
                SetProperty(ref isAddButtonTMVisible, value);
            }
        }

        private bool isRowTMVisible;
        public bool IsRowTMVisible
        {
            get { return isRowTMVisible; }
            set
            {
                SetProperty(ref isRowTMVisible, value);
            }
        }

        private void RemoveTicketManagement()
        {
            IsRemoveButtonTMVisible = false;
            IsAddButtonTMVisible = true;
            IsRowTMVisible = false;

            TicketManagement = 0;
            CalculateLOE();
        }

        private void AddTicketManagement()
        {
            IsRemoveButtonTMVisible = true;
            IsAddButtonTMVisible = false;
            IsRowTMVisible = true;

            CalculatePercentage();
            CalculateLOE();
        }

        private void SetDefaultValue()
        {
            MinTicketManagement = 2;
            MinSelfTest = 0.5;
            MinPeerReview = 0.5;
            MinQaTest = 0.5;
            MinDeployment = 0.5;
            MinAdjustments = 0.5;

            WarningMessageVisibility = false;
        }

        private void CalculatePercentage()
        {
            TicketManagement = minTicketManagement;
            SelfTest = minSelfTest + (.05 * Development);
            PeerReview = minPeerReview + (.05 * Development);
            QaTest = minQaTest + (.10 * Development);
            Deployment = minDeployment + (.05 * Development);
            Adjustments = minAdjustments + (.10 * Development);
        }

        private bool warningMessageVisibility;
        public bool WarningMessageVisibility
        {
            get { return warningMessageVisibility; }
            set
            {
                SetProperty(ref warningMessageVisibility, value);
            }
        }

        public void SetCriteria()
        {
            try
            {
                string option1 = SelectedFormType.OptionType;
                string option2 = SelectedEappType.OptionType;
                string option3 = SelectedDesignComplexity.OptionType;
                string option4 = SelectedCustomValidation.OptionType;

                string WarningMessage = "Field configuration hasn't been set.";

                if (option1 == "New")
                {
                    if (option2 == "Standard")
                    {
                        Application.Current.MainPage.DisplayAlert("Warning", WarningMessage, "OK");
                    }
                    else if (option2 == "Custom")
                    {
                        if (option3 == "Normal")
                        {
                            if (option4 == "Normal")
                            {
                                Criteria = 1;
                            }
                            if (option4 == "Medium")
                            {
                                Criteria = 2;
                            }
                            else if (option4 == "High")
                            {
                                Criteria = 3;
                            }
                        }
                        else if (option3 == "Medium")
                        {
                            if (option4 == "Normal")
                            {
                                Criteria = 4;
                            }
                            if (option4 == "Medium")
                            {
                                Criteria = 5;
                            }
                            else if (option4 == "High")
                            {
                                Criteria = 6;
                            }
                        }
                        else if (option3 == "High")
                        {
                            Application.Current.MainPage.DisplayAlert("Warning", WarningMessage, "OK");
                        }
                    }
                }
                else if (option1 == "Update")
                {
                    Application.Current.MainPage.DisplayAlert("Warning", WarningMessage, "OK");
                }

                WarningMessageVisibility = false;
            }
            catch (Exception)
            {
                //string message = "Form type needs to be completed.";
                //Application.Current.MainPage.DisplayAlert("Warning", message, "OK");

                WarningMessageVisibility = true;
            }
        }

        double MultiplierPages;
        double MultiplierFields;
        double MultiplierFieldsWithValidation;

        public int Criteria;

        private void CalculateFormElements()
        {
            switch (Criteria)
            {
                case 1:
                    MultiplierPages = 0.5;
                    MultiplierFields = 0.25;
                    MultiplierFieldsWithValidation = 0.25;
                    break;
                case 2:
                    MultiplierPages = 0.5;
                    MultiplierFields = 0.25;
                    MultiplierFieldsWithValidation = 0.5;
                    break;
                case 3:
                    MultiplierPages = 0.5;
                    MultiplierFields = 0.25;
                    MultiplierFieldsWithValidation = 0.75;
                    break;
                case 4:
                    MultiplierPages = 0.75;
                    MultiplierFields = 0.25;
                    MultiplierFieldsWithValidation = 0.25;
                    break;
                case 5:
                    MultiplierPages = 0.75;
                    MultiplierFields = 0.25;
                    MultiplierFieldsWithValidation = 0.5;
                    break;
                case 6:
                    MultiplierPages = 0.5;
                    MultiplierFields = 0.5;
                    MultiplierFieldsWithValidation = 0.75;
                    break;
            }

            double TotalNumberOfPages = numberOfPages * MultiplierPages;
            double TotalNumberOfFields = numberOfFields * MultiplierFields;
            double TotalNumberOfFieldsWithValidation = fieldsWithCustomValidation * MultiplierFieldsWithValidation;

            Development = TotalNumberOfPages + TotalNumberOfFields + TotalNumberOfFieldsWithValidation;
        }

        private void CalculateLOE()
        {
            LoeBreakdown = TicketManagement + SelfTest + PeerReview + QaTest + Deployment + Adjustments;
        }

        public IList<FormType> FormTypes { get { return FormTypeData.FormTypes; } }
        FormType selectedFormType;
        public FormType SelectedFormType
        {
            get { return selectedFormType; }
            set
            {
                if (selectedFormType != value)
                {
                    selectedFormType = value;
                    OnPropertyChanged();
                    SetCriteria();
                    CalculateFormElements();
                }
            }
        }

        public IList<FormType> EappTypes { get { return FormTypeData.EappTypes; } }
        FormType selectedEappType;
        public FormType SelectedEappType
        {
            get { return selectedEappType; }
            set
            {
                if (selectedEappType != value)
                {
                    selectedEappType = value;
                    SetCriteria();
                    CalculateFormElements();
                }
            }
        }

        public IList<FormType> DesignComplexity { get { return FormTypeData.DesignComplexity; } }
        FormType selectedDesignComplexity;
        public FormType SelectedDesignComplexity
        {
            get { return selectedDesignComplexity; }
            set
            {
                if (selectedDesignComplexity != value)
                {
                    selectedDesignComplexity = value;
                    OnPropertyChanged();
                    SetCriteria();
                    CalculateFormElements();
                }
            }
        }

        public IList<FormType> CustomValidation { get { return FormTypeData.CustomValidation; } }
        FormType selectedCustomValidation;
        public FormType SelectedCustomValidation
        {
            get { return selectedCustomValidation; }
            set
            {
                if (selectedCustomValidation != value)
                {
                    selectedCustomValidation = value;
                    OnPropertyChanged();
                    SetCriteria();
                    CalculateFormElements();
                }
            }
        }

        private double numberOfPages;
        public double NumberOfPages
        {
            get { return numberOfPages; }
            set
            {
                SetProperty(ref numberOfPages, value);
                CalculateFormElements();
            }
        }

        private double numberOfFields;
        public double NumberOfFields
        {
            get { return numberOfFields; }
            set
            {
                SetProperty(ref numberOfFields, value);
                CalculateFormElements();
            }
        }

        private double fieldsWithCustomValidation;
        public double FieldsWithCustomValidation
        {
            get { return fieldsWithCustomValidation; }
            set
            {
                SetProperty(ref fieldsWithCustomValidation, value);
                CalculateFormElements();
            }
        }

        private double development;
        public double Development
        {
            get { return development; }
            set
            {
                SetProperty(ref development, value);
                ProjectedHours = Development + LoeBreakdown;
                CalculatePercentage();
            }
        }

        private double ticketManagement;
        public double TicketManagement
        {
            get { return ticketManagement; }
            set
            {
                SetProperty(ref ticketManagement, value);
                CalculateLOE();
            }
        }

        private double minTicketManagement;
        public double MinTicketManagement
        {
            get { return minTicketManagement; }
            set
            {
                SetProperty(ref minTicketManagement, value);
                TicketManagement = minTicketManagement;
            }
        }

        private double selfTest;
        public double SelfTest
        {
            get { return selfTest; }
            set
            {
                SetProperty(ref selfTest, value);
                CalculateLOE();
            }
        }

        private double minSelfTest;
        public double MinSelfTest
        {
            get { return minSelfTest; }
            set
            {
                SetProperty(ref minSelfTest, value);
                CalculatePercentage();
            }
        }

        private double peerReview;
        public double PeerReview
        {
            get { return peerReview; }
            set
            {
                SetProperty(ref peerReview, value);
                CalculateLOE();
            }
        }

        private double minPeerReview;
        public double MinPeerReview
        {
            get { return minPeerReview; }
            set
            {
                SetProperty(ref minPeerReview, value);
                CalculatePercentage();
            }
        }

        private double qaTest;
        public double QaTest
        {
            get { return qaTest; }
            set
            {
                SetProperty(ref qaTest, value);
                CalculateLOE();
            }
        }

        private double minQaTest;
        public double MinQaTest
        {
            get { return minQaTest; }
            set
            {
                SetProperty(ref minQaTest, value);
                CalculatePercentage();
            }
        }

        private double deployment;
        public double Deployment
        {
            get { return deployment; }
            set
            {
                SetProperty(ref deployment, value);
                CalculateLOE();
            }
        }

        private double minDeployment;
        public double MinDeployment
        {
            get { return minDeployment; }
            set
            {
                SetProperty(ref minDeployment, value);
                CalculatePercentage();
            }
        }

        private double adjustments;
        public double Adjustments
        {
            get { return adjustments; }
            set
            {
                SetProperty(ref adjustments, value);
                CalculateLOE();
            }
        }

        private double minAdjustments;
        public double MinAdjustments
        {
            get { return minAdjustments; }
            set
            {
                SetProperty(ref minAdjustments, value);
                CalculatePercentage();
            }
        }

        private double loeBreakdown;
        public double LoeBreakdown
        {
            get { return loeBreakdown; }
            set
            {
                SetProperty(ref loeBreakdown, value);
                ProjectedHours = Development + LoeBreakdown;
            }
        }

        private double projectedHours;
        public double ProjectedHours
        {
            get { return projectedHours; }
            set
            {
                SetProperty(ref projectedHours, value);
            }
        }
    }
}
