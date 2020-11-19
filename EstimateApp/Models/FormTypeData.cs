using System;
using System.Collections;
using System.Collections.Generic;

namespace EstimateApp.Models
{
    public class FormTypeData
    {
        public static IList<FormType> FormTypes { get; private set; }
        public static IList<FormType> EformTypes { get; private set; }
        public static IList<FormType> DesignComplexity { get; private set; }
        public static IList<FormType> CustomValidation { get; private set; }
        public static IList<FormType> DeliveryTypes { get; private set; }
        public static IList<FormType> PageTypes { get; private set; }
        public static IList<FormType> EappTypes { get; private set; }

        static FormTypeData()
        {
            FormTypes = new List<FormType>
            {
                new FormType
                {
                    Id = "1",
                    OptionType = "New"
                },

                new FormType
                {
                    Id = "2",
                    OptionType = "Update"
                }
            };

            EformTypes = new List<FormType>
            {
                new FormType
                {
                    Id = "1",
                    OptionType = "Standard"
                },

                new FormType
                {
                    Id = "2",
                    OptionType = "Offer Letter"
                },

                new FormType
                {
                    Id = "3",
                    OptionType = "Multi-Part"
                }
            };

            DesignComplexity = new List<FormType>
            {
                new FormType
                {
                    Id = "1",
                    OptionType = "Normal"
                },

                new FormType
                {
                    Id = "1",
                    OptionType = "Medium"
                },

                new FormType
                {
                    Id = "1",
                    OptionType = "High"
                }
            };

            CustomValidation = new List<FormType>
            {
                new FormType
                {
                    Id = "1",
                    OptionType = "Normal"
                },

                new FormType
                {
                    Id = "1",
                    OptionType = "Medium"
                },

                new FormType
                {
                    Id = "1",
                    OptionType = "High"
                }
            };

            DeliveryTypes = new List<FormType>
            {
                new FormType
                {
                    Id = "1",
                    OptionType = "via UI/https"
                },
                new FormType
                {
                    Id = "2",
                    OptionType = "via sFTP"
                }
            };

            PageTypes = new List<FormType>
            {
                new FormType
                {
                    Id = "1",
                    OptionType = "Standard"
                },
                new FormType
                {
                    Id = "2",
                    OptionType = "Multi-Part"
                }
            };

            EappTypes = new List<FormType>
            {
                new FormType
                {
                    Id =  "1",
                    OptionType = "Standard"
                },
                new FormType
                {
                    Id =  "2",
                    OptionType = "Custom"
                }
            };
        }
    }
}
