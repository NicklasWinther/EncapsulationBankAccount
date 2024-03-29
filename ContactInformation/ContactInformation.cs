﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContactInformation
{
        /// <summary>
        /// Represents the contact information for a person.
        /// </summary>
        public class ContactInformation
        {
            #region Fields
            private string privatePhone;
            private string workPhone;
            private string privateEmail;
            private string workEmail;
            #endregion


            #region Constructors
            /// <summary>
            /// Initializes a new <see cref="ContactInformation"/> instance with the provided work phone and email. Private phone and email are initialized to <see cref="String.Empty"/>.
            /// </summary>
            /// <param name="workPhone">The work phone number.</param>
            /// <param name="workEmail">The work email.</param>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="ArgumentException"/>
            public ContactInformation(string workPhone, string workEmail)
                : this(workPhone, workEmail, String.Empty, String.Empty)
            {
                // Leave empty.
            }

            /// <summary>
            /// Initializes a new <see cref="ContactInformation"/> instance with the provided work phone and email and private phone and email.
            /// </summary>
            /// <param name="workPhone">The work phone number.</param>
            /// <param name="workEmail">The work email.</param>
            /// <param name="privateEmail">The private email.</param>
            /// <param name="privatePhone">The private phone.</param>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="ArgumentException"/>
            public ContactInformation(string workPhone, string workEmail, string privatePhone, string privateEmail)
            {
                WorkPhone = workPhone;
                WorkEmail = workEmail;
                PrivatePhone = privatePhone;
                PrivateEmail = privateEmail;
            }
            #endregion


            #region Properties
            /// <summary>
            /// Gets or sets the private phone.
            /// </summary>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="ArgumentException"/>
            public string PrivatePhone
            {
                get
                {
                    return privatePhone;
                }

                set
                {
                    var validationResult = ValidatePhone(value);
                    if (!validationResult.isValid)
                    {
                        if (validationResult.errorMessage == "null")
                        {
                            throw new ArgumentNullException();
                        }
                        else
                        {
                            throw new ArgumentException(validationResult.errorMessage);
                        }
                    }
                    else if (value != privatePhone)
                    {
                        privatePhone = value;
                    }
                }
            }

            /// <summary>
            /// Gets or sets the work phone.
            /// </summary>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="ArgumentException"/>
            public string WorkPhone
            {
                get
                {
                    return workPhone;
                }

                set
                {
                    var validationResult = ValidatePhone(value);
                    if (!validationResult.isValid)
                    {
                        if (validationResult.errorMessage == "null")
                        {
                            throw new ArgumentNullException();
                        }
                        else
                        {
                            throw new ArgumentException(validationResult.errorMessage);
                        }
                    }
                    else if (value != workPhone)
                    {
                        workPhone = value;
                    }
                }
            }

            /// <summary>
            /// Gets or sets the private email.
            /// </summary>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="ArgumentException"/>
            public string PrivateEmail
            {
                get
                {
                    return privateEmail;
                }

                set
                {
                    var validationResult = ValidateMail(value);
                    if (!validationResult.isValid)
                    {
                        if (validationResult.errorMessage == "null")
                        {
                            throw new ArgumentNullException();
                        }
                        else
                        {
                            throw new ArgumentException(validationResult.errorMessage);
                        }
                    }
                    else if (value != privateEmail)
                    {
                        privateEmail = value;
                    }
                }
            }

            /// <summary>
            /// Gets or sets the work email.
            /// </summary>
            /// <exception cref="ArgumentNullException"/>
            /// <exception cref="ArgumentException"/>
            public string WorkEmail
            {
                get
                {
                    return workEmail;
                }

                set
                {
                    var validationResult = ValidateMail(value);
                    if (!validationResult.isValid)
                    {
                        if (validationResult.errorMessage == "null")
                        {
                            throw new ArgumentNullException();
                        }
                        else
                        {
                            throw new ArgumentException(validationResult.errorMessage);
                        }
                    }
                    else if (value != workEmail)
                    {
                        workEmail = value;
                    }
                }
            }
            #endregion


            #region Methods
            /// <summary>
            /// Validates that an email address is either in the correct format or an empty string.
            /// </summary>
            /// <param name="mail">The mail address to validate.</param>
            /// <returns>A <see cref="(bool, string)"/> tuple, indicating the result of the validation.</returns>
            public static (bool isValid, string errorMessage) ValidateMail(string mail)
            {
                if (mail is null)
                {
                    return (false, "null");
                }
                else if (mail == String.Empty)
                {
                    return (true, String.Empty);
                }
                else
                {
                    mail = mail.Trim();
                    try
                    {
                    //MailAddress mailAddress = new MailAddress(mail);
                    string domainPart = ""; //mailAddress.Host/*Address.Split('@')[1]*/;
                        if (!domainPart.Contains("."))
                        {
                            return (false, "Mail address is missing a dot (.) in the domain part.");
                        }
                    }
                    catch (FormatException f)
                    {
                        return (false, $"Incorrect format: {f.Message}");
                    }
                    catch (Exception e)
                    {
                        return (false, $"Mail validation error: {e.Message}");
                    }
                    return (true, String.Empty);
                }
            }

            /// <summary>
            /// validates that a phone number start with either a number or a +, and does not contain other characters than numbers separated by spaces.
            /// </summary>
            /// <param name="phone">The phone number to validate.</param>
            /// <returns>A <see cref="(bool, string)"/> tuple, indicating the result of the validation.</returns>
            public static (bool isValid, string errorMessage) ValidatePhone(string phone)
            {
                if (phone is null)
                {
                    return (false, "null");
                }
                else if (phone == String.Empty)
                {
                    return (true, String.Empty);
                }
                else
                {
                    phone = phone.Trim();
                    if (!(phone.StartsWith("+") || phone.StartsWith("(") || Char.IsNumber(phone[0])))
                    {
                        return (false, "Incorrect format. Must start with either +, ( or a number");
                    }
                    else
                    {
                        for (int i = 1; i < phone.Length; i++)
                        {
                            if (!(Char.IsNumber(phone[i]) || phone[i] == ' ' || phone[i] == ')' || phone[i] == '-'))
                            {
                                return (false, "Contains invalid character(s). Must only contain numbers separated by space character");
                            }
                        }
                        return (true, String.Empty);
                    }
                }
            }
            #endregion
        }
    }

