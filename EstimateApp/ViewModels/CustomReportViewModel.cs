using System;
using System.Collections.Generic;
using System.Windows.Input;
using EstimateApp.Models;
using Xamarin.Forms;

namespace EstimateApp.ViewModels
{
    public class CustomReportViewModel : BaseViewModel
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

        public CustomReportViewModel()
        {
            Title = "Custom Report";

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

            FilterVisibility = false;
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
                string option2 = SelectedDeliveryType.OptionType;
                string option3 = SelectedReportComplexity.OptionType;

                if (option1 == "New")
                {
                    if (option2 == "via UI/https")
                    {
                        if (option3 == "Normal")
                        {
                            Criteria = 1;
                        }
                        else if (option3 == "Medium")
                        {
                            Criteria = 2;
                        }
                        else if (option3 == "High")
                        {
                            Criteria = 3;
                        }
                    }
                    else if (option2 == "via sFTP")
                    {
                        if (option3 == "Normal")
                        {
                            Criteria = 4;
                        }
                        else if (option3 == "Medium")
                        {
                            Criteria = 5;
                        }
                        else if (option3 == "High")
                        {
                            Criteria = 6;
                        }
                    }
                }
                else if (option1 == "Update")
                {
                    if (option2 == "via UI/https")
                    {
                        if (option3 == "Normal")
                        {
                            Criteria = 1;
                        }
                        else if (option3 == "Medium")
                        {
                            Criteria = 2;
                        }
                        else if (option3 == "High")
                        {
                            Criteria = 3;
                        }
                    }
                    else if (option2 == "via sFTP")
                    {
                        if (option3 == "Normal")
                        {
                            Criteria = 4;
                        }
                        else if (option3 == "Medium")
                        {
                            Criteria = 5;
                        }
                        else if (option3 == "High")
                        {
                            Criteria = 6;
                        }
                    }
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

        double MultiplierStandardFields;
        double MultiplierCustomFields;
        double MultiplierCalculatedFields;
        double MultiplierNumberOfFilters;

        public int Criteria;

        private void CalculateFormElements()
        {
            switch (Criteria)
            {
                //case 1-3
                //New/Update - UI/https - Normal,Medium,High
                case 1:
                    MultiplierStandardFields = 0.125;
                    MultiplierCustomFields = 0.125;
                    MultiplierCalculatedFields = 0.125;
                    MultiplierNumberOfFilters = 0.125;
                    break;
                case 2:
                    MultiplierStandardFields = 0.125;
                    MultiplierCustomFields = 0.125;
                    MultiplierCalculatedFields = 0.25;
                    MultiplierNumberOfFilters = 0.25;
                    break;
                case 3:
                    MultiplierStandardFields = 0.125;
                    MultiplierCustomFields = 0.125;
                    MultiplierCalculatedFields = 0.375;
                    MultiplierNumberOfFilters = 0.375;
                    break;
                //case 4-6
                //New/Update - sFTP - Normal,Medium,High
                case 4:
                    MultiplierStandardFields = 0.125;
                    MultiplierCustomFields = 0.125;
                    MultiplierCalculatedFields = 0.125;
                    MultiplierNumberOfFilters = 1;
                    break;
                case 5:
                    MultiplierStandardFields = 0.125;
                    MultiplierCustomFields = 0.125;
                    MultiplierCalculatedFields = 0.25;
                    MultiplierNumberOfFilters = 1;
                    break;
                case 6:
                    MultiplierStandardFields = 0.125;
                    MultiplierCustomFields = 0.125;
                    MultiplierCalculatedFields = 0.375;
                    MultiplierNumberOfFilters = 1;
                    break;
            }

            double TotalStandardFields = standardFields * MultiplierStandardFields;
            double TotalCustomFields = customFields * MultiplierCustomFields;
            double TotalCalculatedFields = calculatedFields * MultiplierCalculatedFields;
            double TotalNumberOfFilters = numberOfFilters * MultiplierNumberOfFilters;

            Development = TotalStandardFields + TotalCustomFields + TotalCalculatedFields + TotalNumberOfFilters;
        }

        private void CalculateLOE()
        {
            LoeBreakdown = TicketManagement + SelfTest + PeerReview + QaTest + Deployment + Adjustments;
        }

        public void ToggleFilterVisibility()
        {
            if (SelectedDeliveryType.OptionType == "via UI/https")
            {
                FilterVisibility = true;
            }
            else
            {
                FilterVisibility = false;
                NumberOfFilters = 0;
            }
        }

        private bool filterVisibility;
        public bool FilterVisibility
        {
            get { return filterVisibility; }
            set
            {
                SetProperty(ref filterVisibility, value);
            }
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

        public IList<FormType> DeliveryTypes { get { return FormTypeData.DeliveryTypes; } }
        FormType selectedDeliveryType;
        public FormType SelectedDeliveryType
        {
            get { return selectedDeliveryType; }
            set
            {
                if (selectedDeliveryType != value)
                {
                    selectedDeliveryType = value;
                    OnPropertyChanged();
                    SetCriteria();
                    CalculateFormElements();
                    ToggleFilterVisibility();
                }
            }
        }

        public IList<FormType> ReportComplexity { get { return FormTypeData.DesignComplexity; } }
        FormType selectedReportComplexity;
        public FormType SelectedReportComplexity
        {
            get { return selectedReportComplexity; }
            set
            {
                if (selectedReportComplexity != value)
                {
                    selectedReportComplexity = value;
                    OnPropertyChanged();
                    SetCriteria();
                    CalculateFormElements();
                }
            }
        }

        private double standardFields;
        public double StandardFields
        {
            get { return standardFields; }
            set
            {
                SetProperty(ref standardFields, value);
                CalculateFormElements();
            }
        }

        private double customFields;
        public double CustomFields
        {
            get { return customFields; }
            set
            {
                SetProperty(ref customFields, value);
                CalculateFormElements();
            }
        }

        private double calculatedFields;
        public double CalculatedFields
        {
            get { return calculatedFields; }
            set
            {
                SetProperty(ref calculatedFields, value);
                CalculateFormElements();
            }
        }

        private double numberOfFilters;
        public double NumberOfFilters
        {
            get { return numberOfFilters; }
            set
            {
                SetProperty(ref numberOfFilters, value);
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
