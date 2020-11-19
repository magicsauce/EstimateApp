using System;
using System.Collections.Generic;
using EstimateApp.Models;
using Xamarin.Forms;

namespace EstimateApp.ViewModels
{
    public class ProfileProviderViewModel : BaseViewModel
    {
        public ProfileProviderViewModel()
        {
            Title = "Profile/Provider Page";

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
                string option2 = SelectedPageType.OptionType;
                string option3 = SelectedDesignComplexity.OptionType;
                string option4 = SelectedCustomValidation.OptionType;

                string WarningMessage = "Field configuration hasn't been set.";

                if (option1 == "New")
                {
                    if (option2 == "Standard")
                    {
                        if (option3 == "Normal")
                        {
                            if (option4 == "Normal")
                            {
                                Criteria = 1;
                            }
                        }
                        else if (option3 == "Medium")
                        {
                            Criteria = 2;
                        }
                        else
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

        double MultiplierFields;
        double MultiplierFieldsWithValidation;

        public int Criteria;

        private void CalculateFormElements()
        {
            switch (Criteria)
            {
                case 1:
                    MultiplierFields = 0.25;
                    MultiplierFieldsWithValidation = 0.5;
                    break;
                case 2:
                    MultiplierFields = 1;
                    MultiplierFieldsWithValidation = 2;
                    break;
            }

            double TotalNumberOfFields = numberOfFields * MultiplierFields;
            double TotalNumberOfFieldsWithValidation = fieldsWithCustomValidation * MultiplierFieldsWithValidation;

            Development =  TotalNumberOfFields + TotalNumberOfFieldsWithValidation;
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

        public IList<FormType> PageTypes { get { return FormTypeData.PageTypes; } }
        FormType selectedPageType;
        public FormType SelectedPageType
        {
            get { return selectedPageType; }
            set
            {
                if (selectedPageType != value)
                {
                    selectedPageType = value;
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
