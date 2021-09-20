using Business.Constants;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<UserForRegisterDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email).NotEmpty().WithMessage(Messages.EmailNotEmpty);
            RuleFor(user => user.Email).EmailAddress().WithMessage(Messages.NotEmail);
            RuleFor(user => user.FirstName).NotEmpty().WithMessage(Messages.FirstNameMustNotBeEmpty);
            RuleFor(user => user.LastName).NotEmpty().WithMessage(Messages.LastNameMustNotBeEmpty);
            RuleFor(user => user.Password).NotEmpty().WithMessage(Messages.PasswordMustNotBeEmpty);
            RuleFor(user => user.Password).Must(PasswordQualityControl).WithMessage(Messages.PasswordQualityControl);
            RuleFor(user => user.Password).MinimumLength(6).WithMessage(Messages.PasswordMinLengthError);
        }
        private bool PasswordQualityControl(string arg)
        {
            string buyukHarf = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";
            string kucukHarf = "abcçdefgğhıijklmnoöprsştuüvyz";
            string rakam = "0123456789";

            bool buyuk = false;
            bool kucuk = false;
            bool sayi = false;

            foreach (var k in arg)
            {
                foreach (var bh in buyukHarf)
                {
                    if (k == bh)
                    {
                        buyuk = true;
                        break;
                    }
                }

                if (buyuk)
                {
                    break;
                }
            }



            foreach (var k in arg)
            {
                foreach (var kh in kucukHarf)
                {
                    if (k == kh)
                    {
                        kucuk = true;
                        break;
                    }
                }

                if (kucuk)
                {
                    break;
                }
            }





            foreach (var k in arg)
            {
                foreach (var r in rakam)
                {
                    if (k == r)
                    {
                        sayi = true;
                        break;
                    }
                }

                if (sayi)
                {
                    break;
                }
            }
            if (buyuk && kucuk && sayi)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
