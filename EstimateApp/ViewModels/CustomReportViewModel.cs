using System;
using System.Collections.Generic;
using EstimateApp.Models;
using Xamarin.Forms;

namespace EstimateApp.ViewModels
{
    public class CustomReportViewModel : BaseViewModel
    {
        public CustomReportViewModel()
        {
            Title = "Custom Report";

            SetDefaultValue();
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
